namespace SportBox7.Application.Features.Identity.Queries.EditUser
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditUserQuery: IRequest<EditUserInputModel>
    {
        public int Id { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public class EditUserQueryHandler : IRequestHandler<EditUserQuery, EditUserInputModel>
        {
            private readonly IIdentity identityService;
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;

            public EditUserQueryHandler(IIdentity identityService, ICurrentUser currentUser, IEditorRepository editorRepository)
            {
                this.identityService = identityService;
                this.editorRepository = editorRepository;
                this.currentUser = currentUser;
            }
            public async Task<EditUserInputModel> Handle(EditUserQuery request, CancellationToken cancellationToken)
            {
                var model = await identityService.GetUserToEdit(request.Id);
                model.ErrorMessage = request.Errors;
                model.MenuElements = this.editorRepository.GetEditorMenuModel(currentUser.UserId);
                return model;
            }
        }
    }
}

