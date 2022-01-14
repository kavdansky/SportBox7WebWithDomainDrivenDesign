namespace SportBox7.Application.Features.Articles.Queries.Create
{
    using AutoMapper;
    using SportBox7.Application.Features.Articles.Commands.Create;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Sources;
    using System.Threading.Tasks;
    using SportBox7.Application.Features.Editors.Contracts;
    using System.Collections.Generic;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Application.Contracts;

    public class CreateDraftArticleOutputModel: CreateArticleModel, IEditorPage
    {
        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;

        public string MetaTitle => "Create article draft";

        public CreateDraftArticleOutputModel()
        {
        }

        private async Task<CreateDraftArticleOutputModel> InitializeAsync(IArticleRepository articleRepository, ISourceRepository sourceRepository, IEditorRepository editorRepository, ICurrentUser currentUser)
        {
            this.MenuElements = editorRepository.GetEditorMenuModel(currentUser.UserId);
            this.Categories = await articleRepository.GetMenuCategories();
            this.Sources = await sourceRepository.GetSources();
            return this;
        }

        public static Task<CreateDraftArticleOutputModel> CreateAsync(IArticleRepository articleRepository, ISourceRepository sourceRepository, IEditorRepository editorRepository, ICurrentUser currentUser)
        {
            var outputModel = new CreateDraftArticleOutputModel();
            return outputModel.InitializeAsync(articleRepository, sourceRepository, editorRepository, currentUser);
        }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<CreateArticleCommand, CreateDraftArticleOutputModel>()
                .IncludeBase<CreateArticleCommand, CreateArticleModel>();

    }
}
