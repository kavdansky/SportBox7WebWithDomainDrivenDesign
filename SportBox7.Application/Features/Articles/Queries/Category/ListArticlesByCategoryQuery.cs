namespace SportBox7.Application.Features.Articles.Queries.Category
{
    using MediatR;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Categories.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    public class ListArticlesByCategoryQuery : IRequest<ListArticlesByCategoryOutputModel>
    {
        public string? Category { get; set; }

        public int? PageIndex { get; set; }

        public class ListArticleByCategotyHandler : IRequestHandler<ListArticlesByCategoryQuery, ListArticlesByCategoryOutputModel>
        {
            private readonly IArticleRepository articleRepository;
            private readonly ICategoryRepository categoryRepository;

            public ListArticleByCategotyHandler(IArticleRepository repository, ICategoryRepository categoryRepository)
            {
                this.articleRepository = repository;
                this.categoryRepository = categoryRepository;
            }
           
            public async Task<ListArticlesByCategoryOutputModel> Handle(ListArticlesByCategoryQuery request, CancellationToken cancellationToken)
                => await ListArticlesByCategoryOutputModel.CreateAsync(this.articleRepository, categoryRepository, request.Category, request.PageIndex);
            
        }
    }
}
