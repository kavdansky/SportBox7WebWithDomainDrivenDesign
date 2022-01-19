namespace SportBox7.Application.Features.Articles.Queries.ArticlesByDate
{
    using MediatR;
    using SportBox7.Application.Features.Articles.Contrcts;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class ArticleByDateQuery: IRequest<ArticlesByDateOutputModel>
    {
        public int Day { get; set; }

        public int Month { get; set; }

        public class ArticleByDateQueryHandler : IRequestHandler<ArticleByDateQuery, ArticlesByDateOutputModel>
        {
            private readonly IArticleRepository articleRepository;

            public ArticleByDateQueryHandler(IArticleRepository articleRepository)
            {
                this.articleRepository = articleRepository;
            }
            public async Task<ArticlesByDateOutputModel> Handle(ArticleByDateQuery request, CancellationToken cancellationToken)
            {
                var targetDate = new DateTime(1000, request.Month+1, request.Day);
                return await ArticlesByDateOutputModel.CreateAsync(articleRepository, targetDate);
            } 
        }
    }
}
