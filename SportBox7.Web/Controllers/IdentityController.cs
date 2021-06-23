namespace SportBox7.Web.Controllers
{
    using System.Threading.Tasks;
    using Application.Features.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SportBox7.Application.Features.Identity.Commands.CreateUser;
    using SportBox7.Application.Features.Identity.Commands.LoginUser;
    using SportBox7.Application.Features.Identity.Commands.LogoutUser;
    using SportBox7.Application.Features.Identity.Queries.AllUsers;
    using SportBox7.Application.Features.Identity.Queries.LoginUser;
    using SportBox7.Application.Features.Identity.Queries.RegisterUser;
    using SportBox7.Application.Features.Identity.Queries.UserDetails;
    using SportBox7.Domain.Models.Editors;
    using SportBox7.Infrastructure.Identity;

    public class IdentityController : MainController
    {
        [Route("identity/details")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserDetailsOutputModel>> Details([FromQuery] UserDetailsQuery query)
            => View(await this.Mediator.Send(query));

        [Route("identity/editors")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ListUsersOutputModel>> Index([FromQuery] ListUsersQuery query)
            => View(await this.Mediator.Send(query));

        [HttpPost]
        [Route("identity/login")]
        public async Task<ActionResult<LoginOutputModel>> Login(LoginUserCommand command)
        {
            var result = await this.Mediator.Send(command);
            if (!result.Succeeded)
            {
                return RedirectToAction("Login", new { errorMessage = string.Join(", ", result.Errors) });
            }
            return RedirectToAction("Index", "Editors", result.Data ?? new LoginOutputModel("", 0, ""));
        }

        [HttpGet]
        [Route("identity/login")]
        public async Task<ActionResult<LoginUserInputModel>> Login(string? errorMessage)
            => View(await LoginUserInputModel.CreateAsync(errorMessage));

        [Authorize]
        [HttpGet]
        [Route("identity/logout")]
        public async Task<ActionResult> Logout(LogoutUserCommand command)
        {
            await this.Mediator.Send(command);
            return RedirectToAction("Login");
        }

        [Route("identity/register")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RegisterUserInputModel>> Register(string? errorMessage)
          => View(await RegisterUserInputModel.CreateAsync(errorMessage));

        [HttpPost]
        [Route("identity/register")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Register(
            CreateUserCommand command)
        { 
            var result = await this.Send(command);
            //if (!result.Succeeded)
            //{
            //    return RedirectToAction("Register", new { errorMessage = string.Join(", ", result.Errors) });
            //}
            return View();
        } 
    }
}
