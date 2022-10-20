﻿namespace SportBox7.Application.Features.Articles.Queries.Id
{
    using MediatR;
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Categories.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    public class ArticleByIdQuery : IRequest<ArticleByIdOutputModel>
    {
        public int Id { get; set; }

        public class ListArticlesByIdeHandler : IRequestHandler<ArticleByIdQuery, ArticleByIdOutputModel>
        {
            private readonly IArticleRepository articleRepository;
            private readonly ICategoryRepository categoryRepository;
            private readonly ITextManipulationService textManipulationService;

            public ListArticlesByIdeHandler(IArticleRepository articlerepository, ICategoryRepository categoryRepository, ITextManipulationService textManipulationService)
            {
                this.articleRepository = articlerepository;
                this.categoryRepository = categoryRepository;
                this.textManipulationService = textManipulationService;
            }
                

            public async Task<ArticleByIdOutputModel> Handle(ArticleByIdQuery request, CancellationToken cancellationToken)
            {
                var pagemodel = await ArticleByIdOutputModel.CreateAsync(articleRepository, categoryRepository, request.Id);
                return pagemodel;
            }
        }
    }
}
