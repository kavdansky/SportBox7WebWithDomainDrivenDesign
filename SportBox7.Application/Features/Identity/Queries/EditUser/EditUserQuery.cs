namespace SportBox7.Application.Features.Identity.Queries.EditUser
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditUserQuery: IRequest<EditUserInputModel>
    {
        public int Id { get; set; }

        public class EditUserQueryHandler : IRequestHandler<EditUserQuery, EditUserInputModel>
        {
            private readonly IIdentity identityService; 

            public EditUserQueryHandler(IIdentity identityService)
            {
                this.identityService = identityService;
            }
            public Task<EditUserInputModel> Handle(EditUserQuery request, CancellationToken cancellationToken)
            {
                return identityService.GetUserToEdit(request.Id);
            }
        }
    }
}

