namespace SportBox7.Application.Features.Identity
{
    using SportBox7.Application.Common;
    using SportBox7.Application.Features.Identity.Commands;
    using SportBox7.Application.Features.Identity.Commands.CreateUser;
    using SportBox7.Application.Features.Identity.Commands.EditUser;
    using SportBox7.Application.Features.Identity.Commands.LoginUser;
    using SportBox7.Application.Features.Identity.Queries.AllUsers;
    using SportBox7.Application.Features.Identity.Queries.EditUser;
    using SportBox7.Application.Features.Identity.Queries.UserDetails;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result<IUser>> Register(CreateUserCommand userInput);

        Task<Result<LoginSuccessModel>> Login(LoginUserCommand userInput);

        Task<List<SimpleUserListingModel>> GetAllSimpleUsers();

        Task<Result> Logout();

        Task<UserDetailsOutputModel> GetUserDetailsByEditorId(int id);

        Task<EditUserInputModel> GetUserToEdit(int id);

        Task<EditUserOutputModel> EditUser(EditUserCommand userData);

        bool CheckPermitForEdit(string userId, int editorId);
    }
}
