namespace SportBox7.Infrastructure.Persistence.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Features.Articles.Queries.Category;
    using Domain.Models.Articles;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using SportBox7.Application.Contracts;
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
    using SportBox7.Infrastructure.PageHandling;

    internal class ArticleRepository : DataRepository<Article>, IArticleRepository
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IImageManipulationService imageManipulationService;
        private readonly ITextManipulationService textManipulationService;
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public ArticleRepository(SportBox7DbContext db, ICategoryRepository categoryRepository, ITextManipulationService textManipulationService, IImageManipulationService imageManipulationService, IHostingEnvironment hostingEnvironment)
            : base(db)
        {
            this.categoryRepository = categoryRepository;
            this.textManipulationService = textManipulationService;
            this.imageManipulationService = imageManipulationService;
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task<IPaginatedList<ArticleByCategoryListingModel>> GetArticleListingsByCategory(
            string? category, int? pageIndex)
        {
            var query = this.All();

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query
                    .Where(a => a.Category.CategoryNameEN == category)
                    .Where(a => a.ArticleType == ArticleType.PeriodicArticle)
                    .Where(a => a.ArticleState == ArticleState.Published)
                    .OrderBy(a => a.TargetDate);
            }

            var rawArticles = await query
                .Select(art => new ArticleByCategoryListingModel(art.Id, art.Title, art.H1Tag, art.Body, art.ImageUrl,
                    art.Category.CategoryName, art.Category.CategoryNameEN, art.ImageCredit, art.TargetDate))
                .ToListAsync();

            return await PaginatedList<ArticleByCategoryListingModel>.CreateAsync(rawArticles, pageIndex ?? 0);
        }

        public async Task<FrontPageOutputModel> GetArticlesForHomePage(CancellationToken cancellationToken = default)
            => await FrontPageOutputModel.CreateAsync(this, categoryRepository);

        public async Task<ArticleByIdOutputModel> GetArticlePage(CancellationToken cancellationToken = default, int id = default)
            => await ArticleByIdOutputModel.CreateAsync(this, categoryRepository, id, textManipulationService);

        public async Task<List<SideBarModel>> GetsideBarNews()
        {
            var articles = await SortNextDaysArticles(DateTime.Now);
            articles.Reverse();
            var passedArticles = articles.Select(a => new SideBarModel(a.Id, a.Title, a.H1Tag, a.Category.CategoryNameEN, a.Category.CategoryName, a.ImageCredit, a.ImageUrl, a.TargetDate)).Take(5).ToList();

            return passedArticles;

        }

        public async Task<ArticleByIdModel> GetArticleById(int id)
        {
            return await this.All().Where(a => a.Id == id).Select(a => new ArticleByIdModel(a.Id, a.Title, a.H1Tag, a.Body, a.ImageUrl, a.Category.CategoryName, a.Category.CategoryNameEN, a.ImageCredit, a.MetaDescription, a.MetaKeywords, a.Title, a.TargetDate, a.Source.SourceName)).FirstOrDefaultAsync();
        }

        public async Task<List<LatestNewsModel>> GetRunningTextNews()
            => await Task.Run(() => SortNextDaysArticles(DateTime.Now)
            .GetAwaiter()
            .GetResult()
            .Take(5)
            .Select(a =>
            new LatestNewsModel(a.Id, a.Category.CategoryNameEN, a.Title, a.TargetDate))
            .ToList());

        public async Task<List<TopNewsModel>> GetNextDaysNews(DateTime currentDate)
            => await Task.Run(() => SortNextDaysArticles(currentDate).GetAwaiter().GetResult()
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

        [Obsolete]
        public async Task<Article> UpdateArticle(EditArticleCommand command, Source sourceToEdit)
        {
            command.Body = command.Body.Replace("\r\n", "<br />");
            Article articleToEdit = this.All().Where(a => a.Id == command.Id).FirstOrDefault();
            articleToEdit.UpdateBody(command.Body);
            articleToEdit.UpdateCategory(this.categoryRepository.GetCategoryByName(command.Category).GetAwaiter().GetResult());
            articleToEdit.UpdateArticleType((ArticleType)command.ArticleType);
            articleToEdit.UpdateH1Tag(command.H1Tag);
            articleToEdit.UpdateMetaDescription(command.MetaDescription);
            articleToEdit.UpdateMetaKeywords(command.MetaKeywords);
            articleToEdit.UpdateImageCredit(command.ImageCredit);
            articleToEdit.UpdateSource(sourceToEdit);
            articleToEdit.UpdateTargetDate(DateTime.Parse(command.TargetDate));
            articleToEdit.UpdateTitle(command.Title);
            string imageUrl = command.ImageUrl;
            if (command.Image != null)
            {
                imageUrl = imageManipulationService.SaveImageFile(command.Image, hostingEnvironment);
            }
            articleToEdit.UpdateImageUrl(imageUrl);
            this.db.Articles.Update(articleToEdit);
            await this.db.SaveChangesAsync();
            return articleToEdit;
        }

        public async Task<IEnumerable<ArticlesByDateListingModel>> GetArticlesByDate(DateTime date)
        {
            var result = await this.All()
                   .Include(a => a.Category)
                   .Where(a => a.TargetDate.Day == date.Day && a.TargetDate.Month == date.Month)
                   .Select(a => textManipulationService.SetPassedYearsInText(a)).ToListAsync();
                   var result2 = result.Select(a => new ArticlesByDateListingModel(a.Id, a.Title, a.H1Tag, a.Body, a.ImageUrl, a.Category.CategoryName, a.Category.CategoryNameEN, a.ImageCredit, a.TargetDate)).ToList();
            return result2;
        }


        public async Task<IEnumerable<LatestNewsModel>> GetOnTheDayArticles()
        {
            var currentDate = DateTime.Now;
            var result = await this.All()
                .Include(a => a.Category)
                .Where(a => a.ArticleType == ArticleType.PeriodicArticle && a.TargetDate.Day == currentDate.Day && a.TargetDate.Month == currentDate.Month && a.ArticleState == ArticleState.Published)
                .Select(a => textManipulationService.SetPassedYearsInText(a)).ToListAsync();

                var result2 = result.Select(a => new LatestNewsModel(a.Id, a.Category.CategoryNameEN, a.Title, a.TargetDate))
                .ToList();
            
            return result2;
        }

        private async Task<List<Article>> SortNextDaysArticles(DateTime currentDate)
        {
            var sortedArticles = await this.db.Articles
                .Where(a=> a.ArticleState == ArticleState.Published && a.ArticleType == ArticleType.PeriodicArticle)
                .Include(c=> c.Category)
                .OrderBy(o => o.TargetDate.Day)
                .OrderBy(o => o.TargetDate.Month).ToListAsync();

            List<Article> resultList = new List<Article>();
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
