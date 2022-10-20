namespace SportBox7.Infrastructure.Persistence.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Features.Articles.Queries.Category;
    using Domain.Models.Articles;
    using Microsoft.EntityFrameworkCore;
    using SportBox7.Application.Features.Articles.Commands.Edit;
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Articles.Queries.ArticlesByDate;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Articles.Queries.HomePage;
    using SportBox7.Application.Features.Articles.Queries.Id;
    using SportBox7.Application.Features.Categories.Contracts;
    using SportBox7.Domain.Models.Articles.Enums;
    using SportBox7.Domain.Models.Editors;
    using SportBox7.Domain.Models.Sources;

    internal class ArticleRepository : DataRepository<Article>, IArticleRepository
    {
        private readonly ICategoryRepository categoryRepository;

        public ArticleRepository(SportBox7DbContext db, ICategoryRepository categoryRepository)
            : base(db)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<ArticleByCategoryListingModel>> GetArticleListingsByCategory(
            string? category = default,
            CancellationToken cancellationToken = default)
        {
            var query = this.All();

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query
                    .Where(a => a.Category.CategoryNameEN == category)
                    .Where(a => a.ArticleType == ArticleType.PeriodicArticle)
                    .OrderBy(a => a.TargetDate);
            }

            return await query
                .Select(art => new ArticleByCategoryListingModel(art.Id, art.Title, art.Body, art.ImageUrl,
                    art.Category.CategoryName, art.Category.CategoryNameEN, art.ImageCredit, art.TargetDate))
                .ToListAsync(cancellationToken);
        }

        public async Task<FrontPageOutputModel> GetArticlesForHomePage(CancellationToken cancellationToken = default)
            => await FrontPageOutputModel.CreateAsync(this, categoryRepository);

        public async Task<ArticleByIdOutputModel> GetArticlePage(CancellationToken cancellationToken = default, int id = default)
            => await ArticleByIdOutputModel.CreateAsync(this, categoryRepository, id);

        public async Task<List<SideBarModel>> GetsideBarNews()
        {
            var articles = await SortNextDaysArticles();
            articles.Reverse();
            var passedArticles = articles.Select(a => new SideBarModel(a.Id, a.Title, a.H1Tag, a.Category.CategoryNameEN, a.Category.CategoryName, a.ImageCredit, a.ImageUrl, a.TargetDate)).Take(5).ToList();

            return passedArticles;

        }

        public async Task<ArticleByIdModel> GetArticleById(int id)
        {
            return await this.All().Where(a => a.Id == id).Select(a => new ArticleByIdModel(a.Id, a.Title, a.Body, a.ImageUrl, a.Category.CategoryName, a.Category.CategoryNameEN, a.ImageCredit, a.MetaDescription, a.MetaKeywords, a.Title, a.TargetDate)).FirstOrDefaultAsync();
        }

        public async Task<List<LatestNewsModel>> GetRunningTextNews()
            => await Task.Run(() => SortNextDaysArticles()
            .GetAwaiter()
            .GetResult()
            .Take(5)
            .Select(a =>
            new LatestNewsModel(a.Id, a.Category.CategoryNameEN, a.Title, a.TargetDate))
            .ToList());

        public async Task<List<TopNewsModel>> GetTopNews()
            => await Task.Run(() => SortNextDaysArticles().GetAwaiter().GetResult()
            .Take(5)
            .Select(a => new TopNewsModel(a.Id, a.Title, a.H1Tag, a.Category.CategoryNameEN, a.Category.CategoryName, a.ImageCredit, a.ImageUrl, a.Body, a.TargetDate))
            .ToList());

        public async Task<int> Total(CancellationToken cancellationToken = default)
            => await this
                .All()
                .CountAsync(cancellationToken);

        public async Task<Editor> GetArticleAuthor(int articleId)
            => await this.db.Editors.Where(a => a.Articles.Where(x => x.Id == articleId).Any()).FirstOrDefaultAsync();

        public Task<Article> GetArticleObjectById(int id)
            => this.All().Include(x => x.Source).Include(x => x.Category).Where(a => a.Id == id).FirstOrDefaultAsync();

        public Task UpdateArticle(EditArticleCommand command, Source sourceToEdit)
        {
            command.Body = command.Body.Replace("\r\n", "<br />");
            Article articleToEdit = this.All().Where(a => a.Id == command.Id).FirstOrDefault();
            articleToEdit.UpdateBody(command.Body);
            articleToEdit.UpdateCategory(this.categoryRepository.GetCategoryByName(command.Category).GetAwaiter().GetResult());
            articleToEdit.UpdateArticleType((ArticleType)command.ArticleType);
            articleToEdit.UpdateH1Tag(command.H1Tag);
            articleToEdit.UpdateImageUrl(command.ImageUrl);
            articleToEdit.UpdateMetaDescription(command.MetaDescription);
            articleToEdit.UpdateMetaKeywords(command.MetaKeywords);
            articleToEdit.UpdateImageCredit(command.ImageCredit);
            articleToEdit.UpdateSource(sourceToEdit);
            articleToEdit.UpdateTargetDate(DateTime.Parse(command.TargetDate));
            articleToEdit.UpdateTitle(command.Title);
            this.db.Articles.Update(articleToEdit);
            this.db.SaveChanges();
            return Task.Run(() => true);
        }

        public async Task<IEnumerable<ArticlesByDateListingModel>> GetArticlesByDate(DateTime date)
            => await this.All()
                .Include(a => a.Category)
                .Where(a => a.TargetDate.Day == date.Day && a.TargetDate.Month == date.Month)
                .Select(a => new ArticlesByDateListingModel(a.Id, a.Title, a.Body, a.ImageUrl, a.Category.CategoryName, a.Category.CategoryNameEN, a.ImageCredit, a.TargetDate)).ToListAsync();


        public async Task<IEnumerable<LatestNewsModel>> GetOnTheDayArticles()
        {
            var currentDate = DateTime.Now;
            return await this.All()
                .Include(a => a.Category)
                .Where(a => a.ArticleType == ArticleType.PeriodicArticle && a.TargetDate.Day == currentDate.Day && a.TargetDate.Month == currentDate.Month && a.ArticleState == ArticleState.Published)
                .Select(a => new LatestNewsModel(a.Id, a.Category.CategoryNameEN, a.Title, a.TargetDate))
                .ToListAsync();
        }

        private async Task<List<Article>> SortNextDaysArticles()
        {
            var sortedArticles = await this.db.Articles
                .Where(a=> a.ArticleState == ArticleState.Published && a.ArticleType == ArticleType.PeriodicArticle)
                .Include(c=> c.Category)
                .OrderBy(o => o.TargetDate.Day)
                .OrderBy(o => o.TargetDate.Month).ToListAsync();

            List<Article> resultList = new List<Article>();
            var currentDate = DateTime.Now;
            foreach (var obj in sortedArticles)
            {
                if (obj.TargetDate.Month > currentDate.Month)
                    resultList.Add(obj);
                if (obj.TargetDate.Month == currentDate.Month)
                {
                    if (obj.TargetDate.Day > currentDate.Day)
                        resultList.Add(obj);
                    if (obj.TargetDate.Day == currentDate.Day)
                        resultList.Insert(0, obj);
                }     
            }

            foreach (var obj in sortedArticles)
            {
                if (obj.TargetDate.Month < currentDate.Month)
                    resultList.Add(obj);
                if (obj.TargetDate.Month == currentDate.Month)
                {
                    if (obj.TargetDate.Day < currentDate.Day)
                        resultList.Add(obj);
                }
            }
            return resultList;
        }
    }
}
