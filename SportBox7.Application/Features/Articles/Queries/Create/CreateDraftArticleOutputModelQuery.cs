namespace SportBox7.Application.Features.Articles.Queries.Create
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Application.Features.Sources;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateDraftArticleOutputModelQuery: CreateArticleModel, IRequest<CreateDraftArticleOutputModel>
    {
        public class CreateDraftArticleOutputModelQueryHandler : IRequestHandler<CreateDraftArticleOutputModelQuery, CreateDraftArticleOutputModel>
        {
            private readonly IArticleRepository articleRepository;
            private readonly ISourceRepository sourceRepository;
            private readonly IEditorRepository editorRepository;
            private readonly ICurrentUser currentUser;

            public CreateDraftArticleOutputModelQueryHandler(IArticleRepository articleRepository, ISourceRepository sourceRepository, IEditorRepository editorRepository, ICurrentUser currentUser)
            {
                this.articleRepository = articleRepository;
                this.sourceRepository = sourceRepository;
                this.editorRepository = editorRepository;
                this.currentUser = currentUser;
            }

            public async Task<CreateDraftArticleOutputModel> Handle(CreateDraftArticleOutputModelQuery ?request, CancellationToken cancellationToken)
            {
                var model = await CreateDraftArticleOutputModel.CreateAsync(articleRepository, sourceRepository, editorRepository, currentUser);
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
