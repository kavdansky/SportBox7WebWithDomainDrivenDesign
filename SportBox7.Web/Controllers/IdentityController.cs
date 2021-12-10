namespace SportBox7.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Features.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SportBox7.Application.Common;
    using SportBox7.Application.Exceptions;
    using SportBox7.Application.Features.Identity.Commands.CreateUser;
    using SportBox7.Application.Features.Identity.Commands.EditUser;
    using SportBox7.Application.Features.Identity.Commands.LoginUser;
    using SportBox7.Application.Features.Identity.Commands.LogoutUser;
    using SportBox7.Application.Features.Identity.Queries.AllUsers;
    using SportBox7.Application.Features.Identity.Queries.EditUser;
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

        [Route("identity/edit")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<EditUserInputModel>> Edit(EditUserQuery query)
          => View(await this.Mediator.Send(query));
        
        [HttpPost]
        [Route("identity/edit")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<EditUserOutputModel>> Edit(EditUserCommand command)
          => View(await this.Mediator.Send(command));

        [Route("identity/register")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RegisterUserInputModel>> Register(List<string>? errorMessage)
          => View(await RegisterUserInputModel.CreateAsync(errorMessage!));

        [HttpPost]
        [Route("identity/register")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CreateUserOutputModel>> Register(
            CreateUserCommand command)
        {
            try
            {
                var result = await this.Mediator.Send(command);
                if (result.Errors.Count > 0)
                {
                    return RedirectToAction("Register", await RegisterUserInputModel.CreateAsync(result.Errors));
                }
                return RedirectToAction("RegisterUserSuccess", result);
            }
            catch (ModelValidationException ex )
            {
                return RedirectToAction("Register", await RegisterUserInputModel.CreateAsync(ex.Errors));
            }
            
        }

        [Route("identity/registerSucsess")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> RegisterUserSuccess(CreateUserOutputModel model)
          => await Task.Run(()=> View(model)) ;
    }
}
