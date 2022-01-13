namespace SportBox7.Application.Features.Articles.Commands.RevertAsDraft
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Threading;
    using System.Threading.Tasks;

    public class RevertAsDraftCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public class RevertAsDraftCommandHandler : IRequestHandler<RevertAsDraftCommand, bool>
        {
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;

            public RevertAsDraftCommandHandler(ICurrentUser currentUser, IEditorRepository editorRepository)
            {
                this.currentUser = currentUser;
                this.editorRepository = editorRepository;
            }

            public async Task<bool> Handle(RevertAsDraftCommand request, CancellationToken cancellationToken)
                => await this.editorRepository.RevertAsDraft(request.Id, currentUser.UserId);

        }

    }
}
