namespace SportBox7.Application.Features.Identity.Queries.AllUsers
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class ListUsersQuery: IRequest<ListUsersOutputModel>
    {
        public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, ListUsersOutputModel>
        {
            private readonly IIdentity identityService;

            public ListUsersQueryHandler(IIdentity identityService)
                => this.identityService = identityService;

            public async Task<ListUsersOutputModel> Handle(
                ListUsersQuery request,
                CancellationToken cancellationToken)
            {
                var users = await identityService.GetAllSimpleUsers();
                var outputModel = new ListUsersOutputModel()
                {
                    Users = users,
                };

                return outputModel;
            } 
        }
    }
}
