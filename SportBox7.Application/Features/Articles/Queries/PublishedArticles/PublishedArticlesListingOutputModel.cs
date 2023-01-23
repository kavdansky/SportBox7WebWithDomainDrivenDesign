using SportBox7.Application.Contracts;
using SportBox7.Application.Features.Editors;
using SportBox7.Application.Features.Editors.Contracts;
using SportBox7.Application.Features.Editors.Queries.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportBox7.Application.Features.Articles.Queries.PublishedArticles
{
    public class PublishedArticlesListingOutputModel: IEditorPage
    {
        private PublishedArticlesListingOutputModel()
        { }

        public IPaginatedList<PublishedArticlesListingModel> PublishedArticles { get; set; } = null!;
        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = null!;

        private async Task<PublishedArticlesListingOutputModel> InitializeAsync(IEditorRepository editorRepository, string userId, int? pageIndex)
        {
            this.PublishedArticles = await editorRepository.GetPublishedArticlesListingModel(userId, pageIndex);
            this.MenuElements = editorRepository.GetEditorMenuModel(userId);
            return this;
        }

        public static Task<PublishedArticlesListingOutputModel> CreateAsync(IEditorRepository editorRepository, string userId, int? pageIndex)
        {
            var publishedAericlesListingOutputModel = new PublishedArticlesListingOutputModel();
            return publishedAericlesListingOutputModel.InitializeAsync(editorRepository, userId, pageIndex);
        }
    }
}
