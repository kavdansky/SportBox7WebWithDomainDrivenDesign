namespace SportBox7.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SportBox7.Application.Features.Identity.Commands.LoginUser;
    using System.Threading.Tasks;

    public class EditorsController: MainController
    {
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Index(string email, int editorId, string userId)
            => View(await Task.Run(()=> new LoginOutputModel(email, editorId, userId)));
    }
}
 