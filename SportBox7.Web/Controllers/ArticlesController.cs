﻿namespace SportBox7.Web.Controllers
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

    public class ArticlesController: MainController
    {
        private readonly IArticleRepository articleRepository;
        private readonly ISourceRepository sourceRepository;
        private readonly IMapper mapper;

        public ArticlesController(IArticleRepository articleRepository, ISourceRepository sourceRepository, IMapper mapper)
        {
            this.articleRepository = articleRepository;
            this.sourceRepository = sourceRepository;
            this.mapper = mapper;
        }
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

        [Route("/articles/create")]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<CreateDraftArticleOutputModel>> Create(CreateDraftArticleOutputModel model)
        {
            if (model.Errors.Count == 0)
            {
                return View(await CreateDraftArticleOutputModel.CreateAsync(articleRepository, sourceRepository));
            }
            model.Categories = await articleRepository.GetMenuCategories();
            model.Sources = await sourceRepository.GetSources();
            return View(model);
        }
        

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

         
    }
}
