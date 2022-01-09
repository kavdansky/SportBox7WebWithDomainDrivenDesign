namespace SportBox7.Application.Features.Articles.Queries.Drafts
{
    using SportBox7.Application.Features.Editors;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DraftsListingOutputModel
    {
        private DraftsListingOutputModel()
        {}

        public IEnumerable<DraftsListingModel> Drafts { get; set; } = default!;

        private async Task<DraftsListingOutputModel> InitializeAsync(IEditorRepository editorRepository, string userId)
        {
            this.Drafts = await editorRepository.GetDraftsOutputModel(userId);
            return this;
        }

        public static Task<DraftsListingOutputModel> CreateAsync(IEditorRepository editorRepository, string userId)
        {
            var draftsListingOutputModel = new DraftsListingOutputModel();
            return draftsListingOutputModel.InitializeAsync(editorRepository, userId);
        }
    }
}
