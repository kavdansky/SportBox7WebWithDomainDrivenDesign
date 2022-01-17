namespace SportBox7.Application.Features.Sources.Queries.Details
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Threading;
    using System.Threading.Tasks;

    public class SourceByIdQuery : IRequest<SourceByIdOutputModel>
    {
        public int Id { get; set; }

        public class SourceByIdQueryHandler : IRequestHandler<SourceByIdQuery, SourceByIdOutputModel>
        {
            private readonly ISourceRepository sourceRepository;
            private readonly IEditorRepository editorRepository;
            private readonly ICurrentUser currentUser;

            public SourceByIdQueryHandler(ISourceRepository sourceRepository, IEditorRepository editorRepository, ICurrentUser currentUser)
            {
                this.sourceRepository = sourceRepository;
                this.editorRepository = editorRepository;
                this.currentUser = currentUser;
            }

            public async Task<SourceByIdOutputModel> Handle(SourceByIdQuery request, CancellationToken cancellationToken)
            {
                var model = await this.sourceRepository.GetSourceById(request.Id);
                model.MenuElements = this.editorRepository.GetEditorMenuModel(currentUser.UserId);
                return model;
            }
        }
    }
}
