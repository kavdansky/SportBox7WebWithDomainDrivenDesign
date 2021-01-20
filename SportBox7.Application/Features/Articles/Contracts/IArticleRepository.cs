namespace SportBox7.Application.Features.Articles.Contrcts
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Models.Articles;
    using Queries.Category;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Articles.Queries.HomePage;
    using SportBox7.Application.Features.Articles.Queries.Id;
    using SportBox7.Domain.Models.Editors;

    public interface IArticleRepository : IRepository<Article>
    {
        Task<ArticleByIdOutputModel> GetArticlePage(CancellationToken cancellationToken = default,
            int id = default);

        Task<IEnumerable<ArticleByCategoryListingModel>> GetArticleListingsByCategory(
            string? category = default,
            CancellationToken cancellationToken = default);

        Task<FrontPageOutputModel> GetArticlesForHomePage(
            CancellationToken cancellationToken = default);

        Task<ArticleByIdModel> GetArticleById(int id);

        Task<Category> GetCategory(
            int categoryId,
            CancellationToken cancellationToken = default);

        Task<List<MenuCategoriesModel>> GetMenuCategories();

        public List<SideBarModel> GetsideBarNews();

        Task<List<LatestNewsModel>> GetLatestNews();

        Task<List<TopNewsModel>> GetTopNews();

        Task<Editor> GetArticleAuthor(int id);

        Task<Category> GetCategoryByName(string? name);

        Task<int> Total(CancellationToken cancellationToken = default);
    }
}
