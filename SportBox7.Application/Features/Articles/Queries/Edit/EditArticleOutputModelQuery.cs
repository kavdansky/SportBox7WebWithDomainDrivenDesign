namespace SportBox7.Application.Features.Articles.Queries.Edit
{
    using AutoMapper;
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Application.Features.Sources;
    using SportBox7.Application.Features.Sources.Contracts;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditArticleOutputModelQuery: IRequest<EditArticleOutputModel>
    {
        public int Id { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public class EditArticleOutputModelQueryHandler : IRequestHandler<EditArticleOutputModelQuery, EditArticleOutputModel>
        {
            private readonly IArticleRepository articleRepository;
            private readonly ISourceRepository sourceRepository;
            private readonly IMapper mapper;
            private readonly IEditorRepository editorRepository;
            private readonly ICurrentUser currentUser;
            private readonly ICategoryRepository categoryRepository;

            public EditArticleOutputModelQueryHandler(IArticleRepository articleRepository, ISourceRepository sourceRepository, IMapper mapper, IEditorRepository editorRepository, ICurrentUser currentUser, ICategoryRepository categoryRepository)
            {
                this.articleRepository = articleRepository;
                this.sourceRepository = sourceRepository;
                this.mapper = mapper;
                this.editorRepository = editorRepository;
                this.currentUser = currentUser;
                this.categoryRepository = categoryRepository;
            }

            public async Task<EditArticleOutputModel> Handle(EditArticleOutputModelQuery request, CancellationToken cancellationToken)
            {
                var article = await articleRepository.GetArticleObjectById(request.Id);
                var model = this.mapper.Map<EditArticleOutputModel>(article);
                model.Source = article.Source.SourceName;
                model.Errors = request.Errors;
                model.Categories = await categoryRepository.GetMenuCategories();
                model.Sources = await sourceRepository.GetSources();
                model.MenuElements = this.editorRepository.GetEditorMenuModel(this.currentUser.UserId);
                return model;
            }

          
        }

        

        

    }
}
