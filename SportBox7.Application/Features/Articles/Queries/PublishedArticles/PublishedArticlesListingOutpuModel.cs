using SportBox7.Application.Features.Editors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportBox7.Application.Features.Articles.Queries.PublishedArticles
{
    public class PublishedArticlesListingOutpuModel
    {
        private PublishedArticlesListingOutpuModel()
        { }

        public IEnumerable<PublishedArticlesListingModel> PublishedArticles { get; set; } = default!;

        private async Task<PublishedArticlesListingOutpuModel> InitializeAsync(IEditorRepository editorRepository, string userId)
        {
            this.PublishedArticles = await editorRepository.GetPublishedArticlesListingModel(userId);
            return this;
        }

        public static Task<PublishedArticlesListingOutpuModel> CreateAsync(IEditorRepository editorRepository, string userId)
        {
            var publishedAericlesListingOutputModel = new PublishedArticlesListingOutpuModel();
            return publishedAericlesListingOutputModel.InitializeAsync(editorRepository, userId);
        }
    }
}
