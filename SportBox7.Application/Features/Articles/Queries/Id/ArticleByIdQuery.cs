﻿namespace SportBox7.Application.Features.Articles.Queries.Id
{
    using MediatR;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Sources.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    public class ArticleByIdQuery : IRequest<ArticleByIdOutputModel>
    {
        public int Id { get; set; }

        public class ListArticlesByIdeHandler : IRequestHandler<ArticleByIdQuery, ArticleByIdOutputModel>
        {
            private readonly IArticleRepository articleRepository;
            private readonly ICategoryRepository categoryRepository;

            public ListArticlesByIdeHandler(IArticleRepository articlerepository, ICategoryRepository categoryRepository)
            {
                this.articleRepository = articlerepository;
                this.categoryRepository = categoryRepository;
            }
                

            public async Task<ArticleByIdOutputModel> Handle(ArticleByIdQuery request, CancellationToken cancellationToken)
            {
                var pagemodel = await ArticleByIdOutputModel.CreateAsync(articleRepository, categoryRepository, request.Id);
                return pagemodel;
            }
        }
    }
}
