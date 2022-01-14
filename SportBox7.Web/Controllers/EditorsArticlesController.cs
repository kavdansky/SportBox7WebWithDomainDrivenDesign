﻿namespace SportBox7.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Exceptions;
    using SportBox7.Application.Features.Articles.Commands.Create;
    using SportBox7.Application.Features.Articles.Commands.Edit;
    using SportBox7.Application.Features.Articles.Commands.Publish;
    using SportBox7.Application.Features.Articles.Commands.RevertAsDraft;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Articles.Queries.Create;
    using SportBox7.Application.Features.Articles.Queries.Drafts;
    using SportBox7.Application.Features.Articles.Queries.Edit;
    using SportBox7.Application.Features.Articles.Queries.PublishedArticles;
    using SportBox7.Application.Features.Sources;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EditorsArticlesController : MainController
    {
        private readonly IArticleRepository articleRepository;
        private readonly ISourceRepository sourceRepository;
        private readonly IMapper mapper;
        private readonly ICurrentUser currentUser;

        public EditorsArticlesController(IArticleRepository articleRepository, ISourceRepository sourceRepository, IMapper mapper, ICurrentUser currentUser)
        {
            this.articleRepository = articleRepository;
            this.sourceRepository = sourceRepository;
            this.mapper = mapper;
            this.currentUser = currentUser;
        }

        [Route("/editorsarticles/create")]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<CreateDraftArticleOutputModel>> Create(CreateDraftArticleOutputModelQuery query)
        {
            
            return View(await this.Mediator.Send(query));
        }

        [Route("/editorsarticles/create")]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateArticleOutputModel>> Create(CreateArticleCommand command)
        {
            try
            {
                var result = await this.Send(command);
                return result;
            }
            catch (ModelValidationException ex)
            {
                command.Errors = ex.Errors;
                return RedirectToAction("Create", command);
            }

        }

        [Route("/editorsarticles/edit")]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<EditArticleOutputModel>> Edit([FromQuery] EditArticleOutputModelQuery query)
        {
            try
            {
                var model = await this.Mediator.Send(query);
                model.Categories = await articleRepository.GetMenuCategories();
                model.Sources = await sourceRepository.GetSources();
                return View(model);
            }
            catch (NullReferenceException)
            {
                return Redirect("/Home/NotFound");
            }
        }

        [Route("/editorsarticles/edit")]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<EditArticleOutputModel>> Edit(EditArticleCommand command)
        {
            try
            {
                var model = await this.Mediator.Send(command);
                return model;
            }
            catch (ModelValidationException ex)
            {
                return RedirectToAction("Edit", new EditArticleOutputModelQuery() { Id = command.Id, Errors = ex.Errors });
            }
        }

        [Route("/editorsarticles/drafts")]
        [Authorize]
        public async Task<ActionResult<DraftsListingOutputModel>> Drafts(DraftListingQuery query)
        {
            return View(await this.Mediator.Send(query));
        }

        [Route("/editorsarticles/publishedarticles")]
        [Authorize]
        public async Task<ActionResult<PublishedArticlesListingOutpuModel>> PublishedArticles(PublishedArticlesListingQuery query)
            => View(await this.Mediator.Send(query));

        [Route("/editorsarticles/publishdraft")]
        [Authorize]
        public async Task<ActionResult<bool>> PublishDraft([FromQuery]PublishDraftCommand command)
        {
            var result = await this.Mediator.Send(command);
            if (result)
            {
                return RedirectToAction("PublishedArticles");
            }
            return RedirectToAction("Drafts");
        }

        [Route("/editorsarticles/revertasdraft")]
        [Authorize]
        public async Task<ActionResult<bool>> RevertAsDraft([FromQuery] RevertAsDraftCommand command)
        {
            var result = await this.Mediator.Send(command);
            if (result)
            {
                return RedirectToAction("Drafts");
            }
            return RedirectToAction("PublishedArticles");
        }
    }
}
