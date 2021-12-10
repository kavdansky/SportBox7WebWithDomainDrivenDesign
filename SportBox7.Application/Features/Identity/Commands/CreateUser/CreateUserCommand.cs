namespace SportBox7.Application.Features.Identity.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using SportBox7.Application.Common;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Domain.Factories.Editors;

    public class CreateUserCommand: IRequest<Result<CreateUserOutputModel>>
    {
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<CreateUserOutputModel>>
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

            public async Task<Result<CreateUserOutputModel>> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                var user = result.Data;

                var editor = this.editorFactory
                    .WithFirstName(request.FirstName)
                    .WithLastName(request.LastName)
                    .Build();

                user.BecomeEditor(editor);

                await this.editorRepository.Save(editor, cancellationToken);

                return await Task.Run(()=> new CreateUserOutputModel(request.Email));
            }
        }
    }
}