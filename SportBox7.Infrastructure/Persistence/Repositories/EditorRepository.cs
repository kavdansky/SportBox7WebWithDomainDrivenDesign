using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportBox7.Application.Features.Dealers.Queries.Common;
using SportBox7.Application.Features.Dealers.Queries.Details;
using SportBox7.Application.Features.Editors;
using SportBox7.Domain.Exeptions;
using SportBox7.Domain.Models.Editors;
using SportBox7.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportBox7.Infrastructure.Persistence.Repositories
{
    internal class EditorRepository: DataRepository<Editor>, IEditorRepository
    {
        private readonly IMapper mapper;

        public EditorRepository(SportBox7DbContext db, IMapper mapper)
            : base(db)
        {
            this.mapper = mapper;
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

        
    }
}
