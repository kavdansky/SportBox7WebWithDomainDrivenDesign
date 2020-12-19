using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportBox7.Application.Features.Articles.Queries.Category
{
    public class ListArticlesByCategoryQuery : IRequest<ListArticlesByCategoryOutputModel>
    {
        public string? Category { get; set; }

        public class ListArticleByCategotyHandler : IRequestHandler<ListArticlesByCategoryQuery, ListArticlesByCategoryOutputModel>
        {
            private readonly IArticleRepository articleRepository;

            public ListArticleByCategotyHandler(IArticleRepository repository) =>
                this.articleRepository = repository;
           

            public async Task<ListArticlesByCategoryOutputModel> Handle(ListArticlesByCategoryQuery request, CancellationToken cancellationToken)
            {
                var articleList = await this.articleRepository.GetArticleListingsByCategory(request.Category);
                
                return new ListArticlesByCategoryOutputModel(articleList);
            }
        }
    }
}
