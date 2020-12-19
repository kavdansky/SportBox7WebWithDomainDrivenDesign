using MediatR;
using SportBox7.Application.Common;
using SportBox7.Application.Contracts;
using SportBox7.Application.Features.Editors;
using SportBox7.Application.Features.Identity.Commands.LoginUser;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportBox7.Application.Features.Identity.Commands.LoginUser
{
    public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
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

                return new LoginOutputModel(user.Token, dealerId);
            }
        }
    }
}
