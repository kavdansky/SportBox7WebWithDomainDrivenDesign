namespace SportBox7.Application.Features.Articles.Queries.Category
{
    using MediatR;
    using SportBox7.Application.Features.Articles.Contrcts;
    using System.Threading;
    using System.Threading.Tasks;

    public class ListArticlesByCategoryQuery : IRequest<ListArticlesByCategoryOutputModel>
    {
        public string? Category { get; set; }

        public class ListArticleByCategotyHandler : IRequestHandler<ListArticlesByCategoryQuery, ListArticlesByCategoryOutputModel>
        {
            private readonly IArticleRepository articleRepository;

            public ListArticleByCategotyHandler(IArticleRepository repository) 
                => this.articleRepository = repository;
           

            public async Task<ListArticlesByCategoryOutputModel> Handle(ListArticlesByCategoryQuery request, CancellationToken cancellationToken)
                => await ListArticlesByCategoryOutputModel.CreateAsync(this.articleRepository, request.Category);
            
        }
    }
}
