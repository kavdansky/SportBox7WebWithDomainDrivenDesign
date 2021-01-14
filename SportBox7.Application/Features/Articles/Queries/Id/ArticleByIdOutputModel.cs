namespace SportBox7.Application.Features.Articles.Queries.Id
{
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using System.Threading.Tasks;

    public class ArticleByIdOutputModel : PageLayoutOutpuModel
    {
        public ArticleByIdModel Article { get; set; } = default!;

        private async Task<ArticleByIdOutputModel> InitializeAsync(IArticleRepository articleRepository, int id)
        {
            await InitializeLayoutComponentsAsync(articleRepository);
            this.Article = await articleRepository.GetArticleById(id);
            return this;
        }

        public static Task<ArticleByIdOutputModel> CreateAsync(IArticleRepository articleRepository, int id)
        {
            var pgModel = new ArticleByIdOutputModel();
            return pgModel.InitializeAsync(articleRepository, id);
        }

    }
}
