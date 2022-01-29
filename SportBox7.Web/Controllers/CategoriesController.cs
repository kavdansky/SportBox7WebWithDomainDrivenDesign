﻿namespace SportBox7.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SportBox7.Application.Exceptions;
    using SportBox7.Application.Features.Categories.Commands.Create;
    using SportBox7.Application.Features.Categories.Queries.Create;
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
    }
}
