namespace SportBox7.Application.Features.Editors
{
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Articles.Queries.Drafts;
    using SportBox7.Application.Features.Articles.Queries.PublishedArticles;
    using SportBox7.Application.Features.Dealers.Queries.Common;
    using SportBox7.Application.Features.Dealers.Queries.Details;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using SportBox7.Domain.Models.Editors;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IEditorRepository: IRepository<Editor>
    {
        Task<Editor> FindByUser(string userId, CancellationToken cancellationToken = default);

        Task<int> GetEditorId(string userId, CancellationToken cancellationToken = default);

        Task<bool> HasArticle(int dealerId, int articleId, CancellationToken cancellationToken = default);

        Task<EditorDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<EditorOutputModel> GetDetailsByArticleId(int articleId, CancellationToken cancellationToken = default);

        Task<Editor> GetEditorById(int editorId, CancellationToken cancellationToken = default);

        Task<bool> UpdateEditor(Editor editor);

        Task<IPaginatedList<DraftsListingModel>> GetDraftsOutputModel(string userId, int? pageIndex);

        Task<IPaginatedList<PublishedArticlesListingModel>> GetPublishedArticlesListingModel(string userId, int? pageIndex);

        Task<bool> PublishArticle(int articleId, string userId);

        Task<bool> RevertAsDraft(int articleId, string userId);

        IEnumerable<EditorMenuElement> GetEditorMenuModel(string userId);
    }
}
