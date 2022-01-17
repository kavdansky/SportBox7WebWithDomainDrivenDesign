namespace SportBox7.Application.Features.Editors.Queries.Index
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Identity;
    using SportBox7.Application.Features.Identity.Commands.LoginUser;
    using System.Threading;
    using System.Threading.Tasks;

    public class LoginOutputModelQuery: IRequest<LoginOutputModel>
    {
        public class LoginOutputModelQueryHandler : IRequestHandler<LoginOutputModelQuery, LoginOutputModel>
        {
            private readonly IEditorRepository editorRepository;
            private readonly ICurrentUser currentUser;
            private readonly IIdentity identityService;

            public LoginOutputModelQueryHandler(IEditorRepository editorRepository, ICurrentUser currentUser, IIdentity identityService)
            {
                this.currentUser = currentUser;
                this.editorRepository = editorRepository;
                this.identityService = identityService;
            }
            public async Task<LoginOutputModel> Handle(LoginOutputModelQuery request, CancellationToken cancellationToken)
            {
                var editorId = await this.editorRepository.GetEditorId(currentUser.UserId);
                var editorEmail = this.identityService.GetUserToEdit(editorId).GetAwaiter().GetResult().Email;
                var model = new LoginOutputModel(editorEmail, editorId, currentUser.UserId)
                {
                    MenuElements = editorRepository.GetEditorMenuModel(currentUser.UserId)
                };
                return model;
            }
        }
    }
}
