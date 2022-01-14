﻿namespace SportBox7.Application.Features.Articles.Queries.Drafts
{
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Application.Features.Editors.Contracts;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DraftsListingOutputModel: IEditorPage, IMetaTagable
    {
        private DraftsListingOutputModel()
        {}

        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;

        public IEnumerable<DraftsListingModel> Drafts { get; set; } = default!;

        public string MetaDescription => "Editor drafts";

        public string MetaKeywords => "Editor drafts";

        public string MetaTitle => "Editor drafts";

        private async Task<DraftsListingOutputModel> InitializeAsync(IEditorRepository editorRepository, string userId)
        {
            this.Drafts = await editorRepository.GetDraftsOutputModel(userId);
            this.MenuElements = editorRepository.GetEditorMenuModel(userId);
            return this;
        }

        public static Task<DraftsListingOutputModel> CreateAsync(IEditorRepository editorRepository, string userId)
        {
            var draftsListingOutputModel = new DraftsListingOutputModel();
            return draftsListingOutputModel.InitializeAsync(editorRepository, userId);
        }
    }
}
