namespace SportBox7.Application.Features.Identity.Queries.RegisterUser
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class RegisterUserQuery: IRequest<RegisterUserInputModel>
    {
        public List<string> Errors { get; set; } = default!;

        public class RegisterUserQueryHandler : IRequestHandler<RegisterUserQuery, RegisterUserInputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;

            public RegisterUserQueryHandler(ICurrentUser currentUser, IEditorRepository editorRepository)
            {
                this.currentUser = currentUser;
                this.editorRepository = editorRepository;
            }
            public async Task<RegisterUserInputModel> Handle(RegisterUserQuery request, CancellationToken cancellationToken)
            {
                var model = await RegisterUserInputModel.CreateAsync(request.Errors);
                model.MenuElements = this.editorRepository.GetEditorMenuModel(this.currentUser.UserId);
                return model;
            }
        }
    }
}
