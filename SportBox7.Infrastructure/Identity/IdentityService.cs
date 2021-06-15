namespace SportBox7.Infrastructure.Identity
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Application;
    using Application.Features.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using SportBox7.Application.Common;
    using SportBox7.Application.Features.Identity.Commands;
    using SportBox7.Application.Features.Identity.Commands.LoginUser;

    public class IdentityService : IIdentity
    {
        private const string InvalidLoginErrorMessage = "Invalid credentials.";

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityService(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<Result<LoginSuccessModel>> Login(UserInputModel userInput)
        {
            if (userInput.Email == null)
            {
                return InvalidLoginErrorMessage;
            }
            var user = await this.userManager.FindByEmailAsync(userInput.Email);

            if (user == null)
            {
                return InvalidLoginErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return InvalidLoginErrorMessage;
            }

            await this.signInManager.SignInAsync(user, false);

            return new LoginSuccessModel(user.Id, user.Email);
        }

        public async Task<Result> Logout()
        {
            await this.signInManager.SignOutAsync();
            return Result.Success;
        }

        public async Task<Result<IUser>> Register(UserInputModel userInput)
        {
            var user = new User(userInput.Email);

            var identityResult = await this.userManager.CreateAsync(user, userInput.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result<IUser>.SuccessWith(user)
                : Result<IUser>.Failure(errors);
        }    
    }
}
