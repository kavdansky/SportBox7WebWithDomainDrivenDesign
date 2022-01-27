namespace SportBox7.Application.Features.Articles.Queries.ArticlesByDate
{
    using MediatR;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Categories.Contracts;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class ArticleByDateQuery: IRequest<ArticlesByDateOutputModel>
    {
        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public class ArticleByDateQueryHandler : IRequestHandler<ArticleByDateQuery, ArticlesByDateOutputModel>
        {
            private readonly IArticleRepository articleRepository;
            private readonly ICategoryRepository categoryRepository;

            public ArticleByDateQueryHandler(IArticleRepository articleRepository, ICategoryRepository categoryRepository)
            {
                this.articleRepository = articleRepository;
                this.categoryRepository = categoryRepository;
            }
            public async Task<ArticlesByDateOutputModel> Handle(ArticleByDateQuery request, CancellationToken cancellationToken)
            {
                var targetDate = new DateTime(request.Year, request.Month+1, request.Day);
                return await ArticlesByDateOutputModel.CreateAsync(articleRepository, categoryRepository, targetDate);
            } 
        }
    }
}
