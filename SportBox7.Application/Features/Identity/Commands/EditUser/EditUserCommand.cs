namespace SportBox7.Application.Features.Identity.Commands.EditUser
{
    using MediatR;
    using SportBox7.Application.Common;
    using SportBox7.Application.Features.Identity.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditUserCommand : UserInputModel,  IRequest<EditUserOutputModel>
    {

        public class EditUserCommandHandler : IRequestHandler<EditUserCommand, EditUserOutputModel>
        {
            private readonly IIdentity identity;

            public EditUserCommandHandler(IIdentity identity)
            {
                this.identity = identity;
            }

            public async Task<EditUserOutputModel> Handle(EditUserCommand request, CancellationToken cancellationToken)
            {
                return await identity.EditUser(request);
            }
        }
    }
}

