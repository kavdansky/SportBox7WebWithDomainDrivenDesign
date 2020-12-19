namespace SportBox7.Application.Features.Identity.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using MediatR;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Domain.Factories.Editors;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;
            private readonly IEditorFactory editorFactory;
            private readonly IEditorRepository editorRepository;

            public CreateUserCommandHandler(
                IIdentity identity,
                IEditorFactory editorFactory,
                IEditorRepository editorRepository)
            {
                this.identity = identity;
                this.editorFactory = editorFactory;
                this.editorRepository = editorRepository;
            }

            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                var user = result.Data;

                var editor = this.editorFactory
                    .WithFirstName(request.FirstName)
                    .WithLastName(request.LastName)
                    .Build();

                user.BecomeEditor(editor);

                await this.editorRepository.Save(editor, cancellationToken);

                return result;
            }
        }
    }
}