namespace SportBox7.Application.Features.Categories.Queries.Create
{
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Application.Features.Editors.Contracts;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CreateCategoryOutputModel: CreateCategoryModel, IEditorPage, IMetaTagable
    {

        public List<string> Errors { get; set; } = default!;

        public string MetaDescription => "Create Category page";

        public string MetaKeywords => "Create Category";

        public string MetaTitle => "Create Category";



        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;

        private async Task<CreateCategoryOutputModel> InitializeAsync(IEditorRepository editorRepository, ICurrentUser currentUser)
        {
            this.Errors = new List<string>();
            this.MenuElements = editorRepository.GetEditorMenuModel(currentUser.UserId);
            return await Task.Run(()=> this);
        }

        public static Task<CreateCategoryOutputModel> CreateAsync(IEditorRepository editorRepository, ICurrentUser currentUser)
        {
            var outputModel = new CreateCategoryOutputModel();
            return outputModel.InitializeAsync(editorRepository, currentUser);
        }
    }
}
