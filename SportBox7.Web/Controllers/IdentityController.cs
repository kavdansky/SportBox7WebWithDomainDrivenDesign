namespace SportBox7.Web.Controllers
{
    using System.Threading.Tasks;
    using Application.Features.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SportBox7.Application.Features.Identity.Commands.CreateUser;
    using SportBox7.Application.Features.Identity.Commands.LoginUser;
    using SportBox7.Application.Features.Identity.Queries.LoginUser;

    public class IdentityController : MainController
    {
        private readonly IIdentity identity;

        public IdentityController(IIdentity identity) 
            => this.identity = identity;

        [HttpPost]
        [Route("identity/register")]
        public async Task<ActionResult> Register(
            CreateUserCommand command)
            => await this.Send(command);

        [HttpPost]
        [Route("identity/login")]
        public async Task<ActionResult<LoginOutputModel>> Login(LoginUserCommand command)
        {
            var result = await this.Mediator.Send(command);
            if (!result.Succeeded)
            {
                return RedirectToAction("Login", new { errorMessage = string.Join(", ", result.Errors) });
                
            }
            return RedirectToAction("Index", "Editors");
        }
      

        [HttpGet]
        [Route("identity/login")]
        public async Task<ActionResult<LoginUserInputModel>> Login(string? errorMessage)
            => View(await LoginUserInputModel.CreateAsync(errorMessage));

    }
}
