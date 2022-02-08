namespace SportBox7.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SportBox7.Application.Exceptions;
    using SportBox7.Application.Features.Categories.Commands.Create;
    using SportBox7.Application.Features.Categories.Commands.Delete;
    using SportBox7.Application.Features.Categories.Commands.Edit;
    using SportBox7.Application.Features.Categories.Queries.Create;
    using SportBox7.Application.Features.Categories.Queries.Delete;
    using SportBox7.Application.Features.Categories.Queries.Edit;
    using SportBox7.Application.Features.Categories.Queries.Home;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoriesController : MainController
    {
        [Route("/categories")]
        [HttpGet]
        public async Task<ActionResult<CategoryHomePageOutputModel>> Index([FromQuery] CategoryHomePageQuery query)
        => View(await this.Mediator.Send(query));

        [Route("/categories/create")]
        [HttpGet]
        public async Task<ActionResult<CreateCategoryOutputModel>> Create([FromQuery]CreateCategoryModelQuery query)
        => View(await this.Mediator.Send(query));

        [Route("/categories/create")]
        [HttpPost]
        public async Task<ActionResult<CreatedCategoryOutputModel>> Create(CreateCategoryCommand command)
        {
            try
            {
                await this.Mediator.Send(command);
                return Redirect("/categories");
            }
            catch (ModelValidationException ex)
            {
                command.Errors = ex.Errors;
                return RedirectToAction("Create", command);
            }
        }

        [Route("/categories/delete")]
        [HttpGet]
        public async Task<ActionResult<DeleteCategoryOutputModel>> Delete([FromQuery] DeleteCategoryQuery query)
        => View(await this.Mediator.Send(query));

        [Route("/categories/delete")]
        [HttpPost]
        public async Task<ActionResult<bool>> Delete(DeleteCategoryCommand command)
        {
            await this.Mediator.Send(command);
            return RedirectToAction("Index");
        }

        [Route("/categories/edit")]
        [HttpGet]
        public async Task<ActionResult<EditCategoryOutputModel>> Edit(EditCategoryQuery query)
        => View(await this.Mediator.Send(query));

        [Route("/categories/edit")]
        [HttpPost]
        public async Task<ActionResult<EditedCategoryOutputModel>> Edit(EditCategoryCommand command)
        {
            try
            {
                await this.Mediator.Send(command);
                return RedirectToAction("Index");
            }
            catch (ModelValidationException ex)
            {
                command.Errors = ex.Errors;
                return RedirectToAction("Edit", command);
            }
            
        } 
    }
}
