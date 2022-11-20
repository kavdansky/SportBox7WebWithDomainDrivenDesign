namespace SportBox7.Application.Features.Articles.Contrcts
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Models.Articles;
    using Queries.Category;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Articles.Commands.Edit;
    using SportBox7.Application.Features.Articles.Queries.ArticlesByDate;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Articles.Queries.HomePage;
    using SportBox7.Application.Features.Articles.Queries.Id;
    using SportBox7.Domain.Models.Categories;
    using SportBox7.Domain.Models.Editors;
    using SportBox7.Domain.Models.Sources;

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

        Task<List<SideBarModel>> GetsideBarNews();

        Task<List<LatestNewsModel>> GetRunningTextNews();

        Task<List<TopNewsModel>> GetNextDaysNews(DateTime currentDate);

        Task<Editor> GetArticleAuthor(int id);

        Task<int> Total(CancellationToken cancellationToken = default);

        Task<Article> GetArticleObjectById(int id);

        Task UpdateArticle(EditArticleCommand command, Source sourceToEdit);

        Task<IEnumerable<ArticlesByDateListingModel>> GetArticlesByDate(DateTime date);

        Task<IEnumerable<LatestNewsModel>> GetOnTheDayArticles();

    }
}
