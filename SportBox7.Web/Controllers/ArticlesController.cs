namespace SportBox7.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SportBox7.Application.Features.Articles.Queries.Category;
    using SportBox7.Application.Features.Articles.Commands.Create;
    using Microsoft.AspNetCore.Authorization;
    using SportBox7.Application.Features.Articles.Queries.Id;

    [Route("[controller]")]
    public class ArticlesController: MainController
    {
        [HttpGet]
        [Route("/articles")]
        public async Task<ActionResult<ListArticlesByCategoryOutputModel>> Category([FromQuery] ListArticlesByCategoryQuery query)
        => View(await this.Mediator.Send(query));

       
        [Route("/articles/all")]
        [HttpGet]
        public async Task<ActionResult<ArticleByIdOutputModel>> Id([FromQuery] ArticleByIdQuery query)
       => View(await this.Mediator.Send(query));


        

       
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateArticleOutputModel>> Create(
            CreateArticleCommand command)
            => await this.Send(command);
    }
}
