namespace SportBox7.Application.Features.Identity
{
    using SportBox7.Application.Common;
    using SportBox7.Application.Features.Identity.Commands;
    using SportBox7.Application.Features.Identity.Commands.LoginUser;
    using SportBox7.Application.Features.Identity.Queries.AllUsers;
    using SportBox7.Application.Features.Identity.Queries.UserDetails;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<List<SimpleUserListingModel>> GetAllSimpleUsers();

        Task<Result> Logout();

        Task<UserDetailsOutputModel> GetUserDetailsByEditorId(int id);
    }
}
