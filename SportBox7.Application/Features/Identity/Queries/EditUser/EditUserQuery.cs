namespace SportBox7.Application.Features.Identity.Queries.EditUser
{
    using MediatR;
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

            public EditUserQueryHandler(IIdentity identityService)
            {
                this.identityService = identityService;
            }
            public async Task<EditUserInputModel> Handle(EditUserQuery request, CancellationToken cancellationToken)
            {
                var model = await identityService.GetUserToEdit(request.Id);
                model.ErrorMessage = request.Errors;
                return model;
            }
        }
    }
}

