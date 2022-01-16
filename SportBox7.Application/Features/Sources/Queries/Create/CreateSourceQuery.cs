namespace SportBox7.Application.Features.Sources.Queries.Create
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateSourceQuery: IRequest<CreateSourceInputModel>
    {
        public string Errors { get; set; } = default!;

        public class CreateSourceQueryHandler : IRequestHandler<CreateSourceQuery, CreateSourceInputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;

            public CreateSourceQueryHandler(ICurrentUser currentUser, IEditorRepository editorRepository)
            {
                this.editorRepository = editorRepository;
                this.currentUser = currentUser;
            }
            public async Task<CreateSourceInputModel> Handle(CreateSourceQuery request, CancellationToken cancellationToken)
            {
                var model = await CreateSourceInputModel.CreateAsync(request.Errors);
                model.MenuElements = this.editorRepository.GetEditorMenuModel(currentUser.UserId);
                return model;
            }
        }
    }
}
