namespace SportBox7.Application.Features.Identity.Commands.LoginUser
{
    using MediatR;
    using SportBox7.Application.Common;
    using SportBox7.Application.Features.Editors;
    using System.Threading;
    using System.Threading.Tasks;

    public class LoginUserCommand: IRequest<Result<LoginOutputModel>>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
        {
            private readonly IIdentity identity;
            private readonly IEditorRepository editorRepository;

            public LoginUserCommandHandler(
                IIdentity identity,
                IEditorRepository editorRepository)
            {
                this.identity = identity;
                this.editorRepository = editorRepository;
            }

            public async Task<Result<LoginOutputModel>> Handle(
                LoginUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Login(request);

                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                var user = result.Data;
                var dealerId = await this.editorRepository.GetEditorId(user.UserId, cancellationToken);

                return new LoginOutputModel(user.Email, dealerId, user.UserId);
            }
        }
    }
}
