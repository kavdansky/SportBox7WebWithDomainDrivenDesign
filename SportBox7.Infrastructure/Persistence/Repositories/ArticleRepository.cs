namespace SportBox7.Infrastructure.Persistence.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Features.Articles.Queries.Category;
    using Domain.Models.Articles;
    using Microsoft.EntityFrameworkCore;
    using SportBox7.Application.Features.Articles.Commands.Edit;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Articles.Queries.ArticlesByDate;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Articles.Queries.HomePage;
    using SportBox7.Application.Features.Articles.Queries.Id;
    using SportBox7.Application.Features.Categories.Contracts;
    using SportBox7.Domain.Models.Articles.Enums;
    using SportBox7.Domain.Models.Categories;
    using SportBox7.Domain.Models.Editors;
    using SportBox7.Domain.Models.Sources;

    internal class ArticleRepository : DataRepository<Article>, IArticleRepository
    {
        private readonly ICategoryRepository categoryRepository;

        public ArticleRepository(SportBox7DbContext db, ICategoryRepository categoryRepository)
            : base(db)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<ArticleByCategoryListingModel>> GetArticleListingsByCategory(
            string? category = default,
            CancellationToken cancellationToken = default)
        {
            var query = this.All();

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query
                    .Where(a => a.Category.CategoryNameEN == category)
                    .Where(a => a.ArticleType == ArticleType.PeriodicArticle)
                    .OrderBy(a => a.TargetDate);
            }

            return await query
                .Select(art => new ArticleByCategoryListingModel(
                    art.Id,
                    art.Title,
                    art.Body,
                    art.ImageUrl,
                    art.Category.CategoryName,
                    art.Category.CategoryNameEN,
                    art.ImageCredit))
                .ToListAsync(cancellationToken);
        }

        public async Task<FrontPageOutputModel> GetArticlesForHomePage(CancellationToken cancellationToken = default)
            => await FrontPageOutputModel.CreateAsync(this, categoryRepository);

        public async Task<ArticleByIdOutputModel> GetArticlePage(CancellationToken cancellationToken = default, int id = default)
            => await ArticleByIdOutputModel.CreateAsync(this, categoryRepository, id);

        public List<SideBarModel> GetsideBarNews()
            => this.All().Where(a => DateTime.Compare(DateTime.Now, a.TargetDate) > 0).Take(5).Select(a => new SideBarModel(a.Id, a.Title, a.Category.CategoryNameEN, a.Category.CategoryName, a.ImageCredit, a.ImageUrl, a.TargetDate)).ToList();

        public async Task<ArticleByIdModel> GetArticleById(int id)
        {
            return await this.All().Where(a => a.Id == id).Select(a=> new ArticleByIdModel(a.Id, a.Title, a.Body, a.ImageUrl, a.Category.CategoryName, a.Category.CategoryNameEN, a.ImageCredit, a.MetaDescription, a.MetaKeywords, a.Title)).FirstOrDefaultAsync();
        }

        public async Task<List<LatestNewsModel>> GetLatestNews()
            => await this.All()
            .OrderByDescending(a => a.CreationDate)
            .Take(100).OrderByDescending(a => a.CreationDate)
            .Select(a =>
            new LatestNewsModel(a.Id, a.Category.CategoryNameEN, a.Title))
            .ToListAsync();
        
        public async Task<List<TopNewsModel>> GetTopNews()
            => await this.All()
            .OrderByDescending(x => x.CreationDate)
            .Take(5)
            .Select(a => new TopNewsModel(a.Id, a.Title, a.Category.CategoryNameEN, a.Category.CategoryName, a.ImageCredit, a.ImageUrl, a.Body, a.TargetDate))
            .ToListAsync();

        public async Task<int> Total(CancellationToken cancellationToken = default)
            => await this
                .All()
                .CountAsync(cancellationToken);

        public async Task<Editor> GetArticleAuthor(int articleId)
            => await this.db.Editors.Where(a => a.Articles.Where(x => x.Id == articleId).Any()).FirstOrDefaultAsync();

        public Task<Article> GetArticleObjectById(int id)
            => this.All().Include(x=> x.Source).Include(x=> x.Category).Where(a => a.Id == id).FirstOrDefaultAsync();

        public Task UpdateArticle(EditArticleCommand command, Source sourceToEdit)
        {
            Article articleToEdit = this.All().Where(a => a.Id == command.Id).FirstOrDefault();
            articleToEdit.UpdateBody(command.Body);
            articleToEdit.UpdateCategory(this.categoryRepository.GetCategoryByName(command.Category).GetAwaiter().GetResult());
            articleToEdit.UpdateArticleType((ArticleType)command.ArticleType);
            articleToEdit.UpdateH1Tag(command.H1Tag);
            articleToEdit.UpdateImageUrl(command.ImageUrl);
            articleToEdit.UpdateMetaDescription(command.MetaDescription);
            articleToEdit.UpdateMetaKeywords(command.MetaKeywords);
            articleToEdit.UpdateImageCredit(command.ImageCredit);
            articleToEdit.UpdateSource(sourceToEdit);
            articleToEdit.UpdateTargetDate(DateTime.Parse(command.TargetDate));
            articleToEdit.UpdateTitle(command.Title);
            this.db.Articles.Update(articleToEdit);
            this.db.SaveChanges();
            return Task.Run(() => true);
        }

        public async Task<IEnumerable<ArticlesByDateListingModel>> GetArticlesByDate(DateTime date)
        {
            var articlesOnThisTargetDate = await this.All().Include(a=> a.Category).Where(a => a.TargetDate.Day == date.Day && a.TargetDate.Month == date.Month).ToListAsync();
            var articlesToReturn = new List<ArticlesByDateListingModel>();
            foreach (var article in articlesOnThisTargetDate)
            {
                articlesToReturn.Add(new ArticlesByDateListingModel(article.Id, article.Title, article.Body, article.ImageUrl, article.Category.CategoryName, article.Category.CategoryNameEN, article.ImageCredit, article.TargetDate));
            }
            return articlesToReturn;
        }

        public async Task<IEnumerable<LatestNewsModel>> GetOnTheDayArticles()
        {
            var currentDate = DateTime.Now;
            var articlesOnThisDay = await this.All()
                .Include(a=> a.Category)
                .Where(a => a.ArticleType == ArticleType.PeriodicArticle && a.TargetDate.Day == currentDate.Day && a.TargetDate.Month == currentDate.Month && a.ArticleState == ArticleState.Published)
                .Select(a=> new LatestNewsModel(a.Id, a.Category.CategoryNameEN, a.Title ))
                .ToListAsync();
            return articlesOnThisDay;
        }
    }
}
