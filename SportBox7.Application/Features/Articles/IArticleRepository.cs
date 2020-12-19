namespace SportBox7.Application.Features.Articles
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Domain.Models.Articles;
    using Queries.Category;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Articles.Queries.HomePage;

    public interface IArticleRepository : IRepository<Article>
    {
        Task<IEnumerable<ArticleListingModel>> GetArticleListingsByCategory(
            string? category = default,
            CancellationToken cancellationToken = default);

        Task<FrontPageOutputModel> GetArticlesForHomePage(
            CancellationToken cancellationToken = default);

        Task<Category> GetCategory(
            int categoryId,
            CancellationToken cancellationToken = default);

        Task<List<MenuCategoriesModel>> GetMenuCategories();

        public List<SideBarModel> GetsideBarNews();

        Task<List<LatestNewsModel>> GetLatestNews();

        Task<List<TopNewsModel>> GetTopNews();



        Task<int> Total(CancellationToken cancellationToken = default);
    }
}
