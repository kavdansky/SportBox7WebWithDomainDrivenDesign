namespace SportBox7.Application.Features.Articles.Queries.Id
{
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Categories.Contracts;
    using SportBox7.Domain.Models.Articles;
    using SportBox7.Domain.Models.Editors;
    using System.Threading.Tasks;

    public class ArticleByIdOutputModel : PageLayoutOutpuModel
    {
        public ArticleByIdModel Article { get; set; } = default!;

        public Editor Author { get; set; } = default!;

        private async Task<ArticleByIdOutputModel> InitializeAsync(IArticleRepository articleRepository, ICategoryRepository categoryRepository, ITextManipulationService textManipulationService, int id)
        {
            await InitializeLayoutComponentsAsync(articleRepository, categoryRepository);
            this.CurrentCategory = await categoryRepository.GetCurrentCategory(id);
            Article rawArticle = await articleRepository.GetArticleObjectById(id);
            rawArticle = textManipulationService.SetPassedYearsInText(rawArticle);
            this.Article = new ArticleByIdModel(rawArticle.Id, rawArticle.Title, rawArticle.Body, rawArticle.ImageUrl, rawArticle.Category.CategoryName, rawArticle.Category.CategoryNameEN, rawArticle.ImageCredit, rawArticle.MetaDescription, rawArticle.MetaKeywords, rawArticle.Title, rawArticle.TargetDate);
           
            this.Author = await articleRepository.GetArticleAuthor(id);
            return this;
        }

        public static Task<ArticleByIdOutputModel> CreateAsync(IArticleRepository articleRepository, ICategoryRepository categoryRepository, ITextManipulationService textManipulationService, int id)
        {
            var pgModel = new ArticleByIdOutputModel();
            return pgModel.InitializeAsync(articleRepository, categoryRepository, textManipulationService, id);
        }

    }
}
