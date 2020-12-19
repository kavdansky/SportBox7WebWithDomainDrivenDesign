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
using SportBox7.Domain.Models.Editors;
using SportBox7.Web.Common;
using SportBox7.Application.Features.Articles.Commands.Create;
using Microsoft.AspNetCore.Authorization;
using SportBox7.Web;

namespace SportBox7.Web.Controllers
{
    
   
    public class ArticlesController: MainController
    {
        [HttpGet]
        public async Task<ActionResult<ListArticlesByCategoryOutputModel>> Category([FromQuery] ListArticlesByCategoryQuery query)
        =>  View(await this.Mediator.Send(query));
        


       // [HttpGet]
       // public async Task<ActionResult<SearchArticleOutputModel>> Search(
       //      [FromQuery] ListArticlesByCategoryQuery query)
       //    => (SearchArticleOutputModel)await this.Mediator.Send(query);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateArticleOutputModel>> Create(
            CreateArticleCommand command)
            => await this.Send(command);
    }
}
