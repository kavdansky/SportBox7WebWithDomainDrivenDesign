namespace SportBox7.Application.Features.Dealers.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using SportBox7.Application.Features.Editors;

    public class EditorDetailsQuery : IRequest<EditorDetailsOutputModel>
    {
        public int Id { get; set; }

        public class DealerDetailsQueryHandler : IRequestHandler<EditorDetailsQuery, EditorDetailsOutputModel>
        {
            private readonly IEditorRepository editorRepository;

            public DealerDetailsQueryHandler(IEditorRepository editorRepository) 
                => this.editorRepository = editorRepository;

            public async Task<EditorDetailsOutputModel> Handle(
                EditorDetailsQuery request,
                CancellationToken cancellationToken)
                => await this.editorRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}
