namespace SportBox7.Application.Features.Articles.Queries.HomePage
{
    using MediatR;
    using SportBox7.Application.Features.Articles.Contrcts;
    using System.Threading;
    using System.Threading.Tasks;

    public class ListArticlesForHomepageQuery: IRequest<FrontPageOutputModel>
    {
        public class ListArticlesForHomepageHandler : IRequestHandler<ListArticlesForHomepageQuery, FrontPageOutputModel>
        {
            private readonly IArticleRepository articleRepository;

            public ListArticlesForHomepageHandler(IArticleRepository repository) =>
                this.articleRepository = repository;


            public async Task<FrontPageOutputModel> Handle(ListArticlesForHomepageQuery request, CancellationToken cancellationToken)
            {
                var frontPageModel = await this.articleRepository.GetArticlesForHomePage();

                return frontPageModel;
            }
        }
    }
}
