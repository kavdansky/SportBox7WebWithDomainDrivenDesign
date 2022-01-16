namespace SportBox7.Application.Features.Identity.Queries.AllUsers
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Threading;
    using System.Threading.Tasks;

    public class ListUsersQuery: IRequest<ListUsersOutputModel>
    {
        public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, ListUsersOutputModel>
        {
            private readonly IIdentity identityService;
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;

            public ListUsersQueryHandler(IIdentity identityService, ICurrentUser currentUser, IEditorRepository editorRepository)
            {
                this.identityService = identityService;
                this.editorRepository = editorRepository;
                this.currentUser = currentUser;
            } 

            public async Task<ListUsersOutputModel> Handle(
                ListUsersQuery request,
                CancellationToken cancellationToken)
            {
                var users = await identityService.GetAllSimpleUsers();
                var outputModel = new ListUsersOutputModel()
                {
                    Users = users,
                };

                outputModel.MenuElements = editorRepository.GetEditorMenuModel(this.currentUser.UserId);
                return outputModel;
            } 
        }
    }
}
