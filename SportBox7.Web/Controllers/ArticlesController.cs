using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SportBox7.Application;
using SportBox7.Application.Contracts;
using SportBox7.Application.Features.Articles.Queries.Category;
using SportBox7.Domain.Factories.Editors;
using SportBox7.Domain.Models.Articles;
namespace SportBox7.Web.Controllers
{
    using SportBox7.Application.Features.Articles.Commands.Create;
    using Microsoft.AspNetCore.Authorization;

    public class ArticlesController: MainController
    {
        [HttpGet]
        public async Task<ActionResult<ListArticlesByCategoryOutputModel>> Category([FromQuery] ListArticlesByCategoryQuery query)
        =>  View(await this.Mediator.Send(query));

        [HttpGet]
        public async Task<ActionResult<ListArticlesByCategoryOutputModel>> Id([FromQuery] ListArticlesByCategoryQuery query)
        => View(await this.Mediator.Send(query));

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateArticleOutputModel>> Create(
            CreateArticleCommand command)
            => await this.Send(command);
    }
}
