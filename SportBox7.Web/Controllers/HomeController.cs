namespace SportBox7.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SportBox7.Application.Features.Articles.Queries.HomePage;
    using System.Threading.Tasks;

    public class HomeController: MainController
    {
        [HttpGet]
        public async Task<ActionResult<FrontPageOutputModel>> Index([FromQuery] ListArticlesForHomepageQuery query)
        {
            var result = await this.Mediator.Send(query);
            return View(result);
        } 

        [HttpGet]
        public async Task<ActionResult<FrontPageOutputModel>> NotFound([FromQuery] ListArticlesForHomepageQuery query)
        => View(await this.Mediator.Send(query));
    }
}
