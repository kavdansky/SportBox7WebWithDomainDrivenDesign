namespace SportBox7.Application.Features.Articles.Queries.Create
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Application.Features.Sources;
    using SportBox7.Application.Features.Sources.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateDraftArticleOutputModelQuery: CreateArticleModel, IRequest<CreateDraftArticleOutputModel>
    {
        public class CreateDraftArticleOutputModelQueryHandler : IRequestHandler<CreateDraftArticleOutputModelQuery, CreateDraftArticleOutputModel>
        {
            private readonly ISourceRepository sourceRepository;
            private readonly IEditorRepository editorRepository;
            private readonly ICurrentUser currentUser;
            private readonly ICategoryRepository categoryRepository;

            public CreateDraftArticleOutputModelQueryHandler(ISourceRepository sourceRepository, IEditorRepository editorRepository, ICurrentUser currentUser, ICategoryRepository categoryRepository)
            {
                this.sourceRepository = sourceRepository;
                this.editorRepository = editorRepository;
                this.currentUser = currentUser;
                this.categoryRepository = categoryRepository;
            }

            public async Task<CreateDraftArticleOutputModel> Handle(CreateDraftArticleOutputModelQuery ?request, CancellationToken cancellationToken)
            {
                var model = await CreateDraftArticleOutputModel.CreateAsync(categoryRepository, sourceRepository, editorRepository, currentUser);
                if (request != null)
                {  
                    model.Errors = request.Errors.GetRange(0, request.Errors.Count/2);
                    return model;
                }
                return model;
            }
        }
    }
}
