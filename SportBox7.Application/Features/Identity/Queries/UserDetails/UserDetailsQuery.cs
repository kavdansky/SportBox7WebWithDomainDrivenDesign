namespace SportBox7.Application.Features.Identity.Queries.UserDetails
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Threading;
    using System.Threading.Tasks;

    public class UserDetailsQuery: IRequest<UserDetailsOutputModel>
    { 
        public int Id { get; set; }

        public class UserDetailsQueryHandler : IRequestHandler<UserDetailsQuery, UserDetailsOutputModel>
        {
            private readonly IIdentity identityService;
            private readonly IEditorRepository editorRepository;
            private readonly ICurrentUser currentUser;

            public UserDetailsQueryHandler(IIdentity identityService, IEditorRepository editorRepository, ICurrentUser currentUser)
            {
                this.identityService = identityService;
                this.editorRepository = editorRepository;
                this.currentUser = currentUser;
            }

            public async Task<UserDetailsOutputModel> Handle(UserDetailsQuery request, CancellationToken cancellationToken)
            {
                var model = await this.identityService.GetUserDetailsByEditorId(request.Id);
                model.MenuElements = this.editorRepository.GetEditorMenuModel(currentUser.UserId);
                return model;
            }
        }
    }
}
