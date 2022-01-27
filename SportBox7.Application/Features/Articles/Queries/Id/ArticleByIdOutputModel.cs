﻿namespace SportBox7.Application.Features.Articles.Queries.Id
{
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Categories.Contracts;
    using SportBox7.Domain.Models.Editors;
    using System.Threading.Tasks;

    public class ArticleByIdOutputModel : PageLayoutOutpuModel
    {
        public ArticleByIdModel Article { get; set; } = default!;

        public Editor Author { get; set; } = default!;

        private async Task<ArticleByIdOutputModel> InitializeAsync(IArticleRepository articleRepository, ICategoryRepository categoryRepository, int id)
        {
            await InitializeLayoutComponentsAsync(articleRepository, categoryRepository);
            this.CurrentCategory = await categoryRepository.GetCurrentCategory(id);
            this.Article = await articleRepository.GetArticleById(id);
            this.Author = await articleRepository.GetArticleAuthor(id);
            return this;
        }

        public static Task<ArticleByIdOutputModel> CreateAsync(IArticleRepository articleRepository, ICategoryRepository categoryRepository, int id)
        {
            var pgModel = new ArticleByIdOutputModel();
            return pgModel.InitializeAsync(articleRepository, categoryRepository, id);
        }

    }
}
