namespace SportBox7.Application.Features.Articles.Commands.PublishDraft
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Threading;
    using System.Threading.Tasks;


    public class PublishDraftCommand: IRequest<bool>
    {
        public int Id { get; set; }

        public class PublishDraftCommandHandler : IRequestHandler<PublishDraftCommand, bool>
        {
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;

            public PublishDraftCommandHandler(ICurrentUser currentUser, IEditorRepository editorRepository)
            {
                this.currentUser = currentUser;
                this.editorRepository = editorRepository;
            }

            public async Task<bool> Handle(PublishDraftCommand request, CancellationToken cancellationToken)
                => await this.editorRepository.PublishArticle(request.Id, currentUser.UserId);

        }
    }
}
