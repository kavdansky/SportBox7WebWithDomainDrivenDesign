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

        public IEnumerable<PublishedArticlesListingModel> PublishedArticles { get; set; } = default!;
        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;

        private async Task<PublishedArticlesListingOutputModel> InitializeAsync(IEditorRepository editorRepository, string userId)
        {
            this.PublishedArticles = await editorRepository.GetPublishedArticlesListingModel(userId);
            this.MenuElements = editorRepository.GetEditorMenuModel(userId);
            return this;
        }

        public static Task<PublishedArticlesListingOutputModel> CreateAsync(IEditorRepository editorRepository, string userId)
        {
            var publishedAericlesListingOutputModel = new PublishedArticlesListingOutputModel();
            return publishedAericlesListingOutputModel.InitializeAsync(editorRepository, userId);
        }
    }
}
