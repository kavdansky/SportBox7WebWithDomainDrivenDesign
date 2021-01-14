namespace SportBox7.Application.Features.Articles.Queries.Id
{
    using MediatR;
    using SportBox7.Application.Features.Articles.Contrcts;
    using System.Threading;
    using System.Threading.Tasks;

    public class ArticleByIdQuery : IRequest<ArticleByIdOutputModel>
    {
        public int Id { get; set; }

        public class ListArticlesByIdeHandler : IRequestHandler<ArticleByIdQuery, ArticleByIdOutputModel>
        {
            private readonly IArticleRepository articleRepository;

            public ListArticlesByIdeHandler(IArticleRepository repository) =>
                this.articleRepository = repository;

            public async Task<ArticleByIdOutputModel> Handle(ArticleByIdQuery request, CancellationToken cancellationToken)
            {
                var pagemodel = await ArticleByIdOutputModel.CreateAsync(articleRepository, request.Id);
                return pagemodel;
            }
        }
    }
}
