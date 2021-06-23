namespace SportBox7.Application.Features.Identity.Queries.UserDetails
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UserDetailsQuery: IRequest<UserDetailsOutputModel>
    { 
        public int Id { get; set; }

        public class UserDetailsQueryHandler : IRequestHandler<UserDetailsQuery, UserDetailsOutputModel>
        {
            private readonly IIdentity identityService;

            public UserDetailsQueryHandler(IIdentity identityService)
            {
                this.identityService = identityService;
            }

            public Task<UserDetailsOutputModel> Handle(UserDetailsQuery request, CancellationToken cancellationToken)
            {
                return this.identityService.GetUserDetailsByEditorId(request.Id);
            }
        }
    }
}
