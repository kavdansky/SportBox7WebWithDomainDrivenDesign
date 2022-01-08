namespace SportBox7.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SportBox7.Application.Features.Articles.Queries.Category;
    using SportBox7.Application.Features.Articles.Commands.Create;
    using Microsoft.AspNetCore.Authorization;
    using SportBox7.Application.Features.Articles.Queries.Id;
    using SportBox7.Application.Features.Articles.Queries.Create;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Sources;
    using SportBox7.Application.Exceptions;
    using AutoMapper;
    using SportBox7.Application.Features.Articles.Queries.Edit;
    using System;
    using SportBox7.Application.Features.Articles.Commands.Edit;

    public class ArticlesController: MainController
    {

        [HttpGet]
        [Route("/articles")]
        public async Task<ActionResult<ListArticlesByCategoryOutputModel>> Category([FromQuery] ListArticlesByCategoryQuery query)
        {
            var model = await this.Mediator.Send(query);
            if (model.CurrentCategory != null)
            {
                return View(model);
            }
            return Redirect("/Home/NotFound");
        }

       

        [Route("/articles/all")]
        [HttpGet]
        public async Task<ActionResult<ArticleByIdOutputModel>> Id([FromQuery] ArticleByIdQuery query)
        {
            var model = await this.Mediator.Send(query);
            if (model.Article != null)
            {
                return View(model);
            }
            return Redirect("/Home/NotFound"); 
        }     
    }
}
