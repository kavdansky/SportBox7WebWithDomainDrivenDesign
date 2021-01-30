namespace SportBox7.Application.Features.Identity.Commands.LogoutUser
{
    using MediatR;
    using SportBox7.Application.Common;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class LogoutUserCommand: IRequest<Result>
    {
        public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand, Result>
        {
            private readonly IIdentity identity;

            public LogoutUserCommandHandler(IIdentity identity)
            {
                this.identity = identity;
            }

            public async Task<Result> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
                => await this.identity.Logout();


        }
    }
}
