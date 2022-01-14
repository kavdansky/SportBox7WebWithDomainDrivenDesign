namespace SportBox7.Infrastructure.Persistence.Repositories
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SportBox7.Application.Features.Articles.Queries.Drafts;
    using SportBox7.Application.Features.Articles.Queries.PublishedArticles;
    using SportBox7.Application.Features.Dealers.Queries.Common;
    using SportBox7.Application.Features.Dealers.Queries.Details;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using SportBox7.Application.Features.Editors.Queries.Common.Constants;
    using SportBox7.Domain.Exeptions;
    using SportBox7.Domain.Models.Articles;
    using SportBox7.Domain.Models.Articles.Enums;
    using SportBox7.Domain.Models.Editors;
    using SportBox7.Infrastructure.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EditorRepository: DataRepository<Editor>, IEditorRepository
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public EditorRepository(SportBox7DbContext db, IMapper mapper, UserManager<User> userManager)
            : base(db)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<bool> HasArticle(int editorId, int articleId, CancellationToken cancellationToken = default)
            => await this
                .All()
                .Where(e => e.Id == editorId)
                .AnyAsync(d => d.Articles
                    .Any(c => c.Id == articleId), cancellationToken);

        public async Task<EditorDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<EditorDetailsOutputModel>(this
                    .All()
                    .Where(d => d.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<EditorOutputModel> GetDetailsByArticleId(int articleId, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<EditorOutputModel>(this
                    .All()
                    .Where(d => d.Articles.Any(c => c.Id == articleId)))
                .SingleOrDefaultAsync(cancellationToken);

        public Task<int> GetEditorId(
            string userId,
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, user => user.Editor!.Id, cancellationToken);

        public Task<Editor> FindByUser(
            string userId,
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, user => user.Editor!, cancellationToken);

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<User, T>> selector,
            CancellationToken cancellationToken = default)
        {
            var authorData = await this
                .db
                .Users
                .Where(u => u.Id == userId)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);

            if (authorData == null)
            {
                throw new InvalidEditorException("This user is not an author.");
            }

            return authorData;
        }

        public Task<Editor> GetEditorById(int editorId, CancellationToken cancellationToken = default)
            => Task.Run(()=> this.All().Where(e => e.Id == editorId).FirstOrDefault());

        public async Task<bool> UpdateEditor(Editor editor)
        {
            var editorToEdit = this.db.Editors.Find(editor.Id);
            editorToEdit.UpdateFirstName(editor.FirstName);
            editorToEdit.UpdateLastName(editor.LastName);
            await this.Save(editorToEdit);

            return await Task.Run(() => true);
        }

        public Task<List<DraftsListingModel>> GetDraftsOutputModel(string userId)
        {
            var editorDrafts = GetUserArticlesById(userId).Where(a=> a.ArticleState == ArticleState.Draft);
            var result = new List<DraftsListingModel>();
            
            foreach (var article in editorDrafts)
            {
                var model = new DraftsListingModel() { Title = article.Title, Id = article.Id };
                result.Add(model);
                
            }
            return Task.Run( ()=> result);
        }

        private IEnumerable<Article> GetUserArticlesById(string userId)
        {
            var editorId = this.GetEditorId(userId).GetAwaiter().GetResult();
            var result = this.db.Editors.Include(e => e.Articles).Where(e => e.Id == editorId).FirstOrDefault().Articles.Select(x => x).ToList();
            return result;
        }

        public Task<List<PublishedArticlesListingModel>> GetPublishedArticlesListingModel(string userId)
        {
            var editorPublishedArticles = GetUserArticlesById(userId).Where(a => a.ArticleState == ArticleState.Published);
            var result = new List<PublishedArticlesListingModel>();

            foreach (var article in editorPublishedArticles)
            {
                var model = new PublishedArticlesListingModel() { Title = article.Title, Id = article.Id };
                result.Add(model);

            }
            return Task.Run(() => result);
        }

        public async Task<bool> PublishArticle(int articleId, string userId)
        {
            if (await CheckUserPermissionToChangeArticleStatus(articleId, userId))
            {
                this.db.Articles.Where(a => a.Id == articleId).FirstOrDefault().UpdateArticleState(ArticleState.Published);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> RevertAsDraft(int articleId, string userId)
        {
            if (await CheckUserPermissionToChangeArticleStatus(articleId, userId))
            {
                this.db.Articles.Where(a => a.Id == articleId).FirstOrDefault().UpdateArticleState(ArticleState.Draft);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<EditorMenuElement> GetEditorMenuModel(string userId)
        {
            if (this.userManager.IsInRoleAsync(userManager.FindByIdAsync(userId).GetAwaiter().GetResult(), "Admin").GetAwaiter().GetResult())
            {
                return new AdminMenuModel().MenuElements;
            }
            return new EditorMenuModel().MenuElements;
        }

        private async Task<bool> CheckUserPermissionToChangeArticleStatus(int articleId, string userId)
            => await this.HasArticle(FindByUser(userId).GetAwaiter().GetResult().Id, articleId);

        
    }
}
