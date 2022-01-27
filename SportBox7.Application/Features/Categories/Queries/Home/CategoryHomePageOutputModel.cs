namespace SportBox7.Application.Features.Categories.Queries.Home
{
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Application.Features.Editors.Contracts;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using SportBox7.Application.Features.Categories.Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryHomePageOutputModel: IEditorPage, IMetaTagable
    {
        public List<CategoryListingModel> Categories { get; set; } = default!;

        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;

        public string MetaDescription => "Categories";

        public string MetaKeywords => "Categories";

        public string MetaTitle => "Categories";

        private async Task<CategoryHomePageOutputModel> InitializeAsync(ICategoryRepository categoryRepository, IEditorRepository editorRepository, ICurrentUser currentUser)
        {
            this.MenuElements = editorRepository.GetEditorMenuModel(currentUser.UserId);
            this.Categories = await categoryRepository.GetCategoriesListingModel();
            return this;
        }

        public static Task<CategoryHomePageOutputModel> CreateAsync(ICategoryRepository categoryRepository, IEditorRepository editorRepository, ICurrentUser currentUser)
        {
            var outputModel = new CategoryHomePageOutputModel();
            return outputModel.InitializeAsync(categoryRepository, editorRepository, currentUser);
        }
    }
}
