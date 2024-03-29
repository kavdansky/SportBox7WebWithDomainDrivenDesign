﻿namespace SportBox7.Application.Features.Articles.Queries.ArticlesByDate
{
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Articles.Queries.HomePage;
    using SportBox7.Application.Features.Categories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ArticlesByDateOutputModel : PageLayoutOutpuModel, IMetaTagable
    {
        public ArticlesByDateOutputModel()
        {
            this.Articles = new List<ArticlesByDateListingModel>();
        }
        public DateTime TargetDate { get; set; }

        public IEnumerable<ArticlesByDateListingModel> Articles { get; set; } = default!;

        public List<TopNewsModel> NextDaysArticles { get; set; } = default!;

        public string MetaDescription => "На този ден";

        public string MetaKeywords => "На този ден";

        public string MetaTitle => "На този ден";

        private async Task<ArticlesByDateOutputModel> InitializeAsync(IArticleRepository articleRepository, ICategoryRepository categoryRepository, DateTime date)
        {
            await InitializeLayoutComponentsAsync(articleRepository, categoryRepository);
            this.Articles = await articleRepository.GetArticlesByDate(date);
            this.NextDaysArticles = await articleRepository.GetNextDaysNews(date);
            this.TargetDate = date;
            return this;
        }

        public static Task<ArticlesByDateOutputModel> CreateAsync(IArticleRepository articleRepository, ICategoryRepository categoryRepository, DateTime date)
        {
            var frpgouput = new ArticlesByDateOutputModel();
            return frpgouput.InitializeAsync(articleRepository, categoryRepository, date);
        }
    }
}
