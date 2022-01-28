namespace SportBox7.Application.Features.Categories.Queries.Create
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCategoryModelQuery: IRequest<CreateCategoryOutputModel>
    {
        public class CreateCategoryModelQueryHandler : IRequestHandler<CreateCategoryModelQuery, CreateCategoryOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;

            public CreateCategoryModelQueryHandler(IEditorRepository editorRepository, ICurrentUser currentUser)
            {
                this.editorRepository = editorRepository;
                this.currentUser = currentUser;
            }
            public async Task<CreateCategoryOutputModel> Handle(CreateCategoryModelQuery request, CancellationToken cancellationToken)
                => await CreateCategoryOutputModel.CreateAsync(editorRepository, currentUser);
        }
    }
}
