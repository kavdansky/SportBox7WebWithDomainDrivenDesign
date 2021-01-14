namespace SportBox7.Application.Features.Articles.Queries.Category
{
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ListArticlesByCategoryOutputModel: PageLayoutOutpuModel, IMetaTagable
    {
        public ListArticlesByCategoryOutputModel()
        {
            this.Articles = new List<ArticleByCategoryListingModel>();
        }

        public IEnumerable<ArticleByCategoryListingModel> Articles { get; set; } = default!;

        public int Total 
        {
            get
            {
                return Articles.Count();
            }
        }
        public string CurrentCategory { get; set; } = default!;

        public string MetaDescription { get; set; } = default!;

        public string MetaKeywords { get; set; } = default!;

        public string MetaTitle { get; set; } = default!;

        private async Task<ListArticlesByCategoryOutputModel> InitializeAsync(IArticleRepository articleRepository, string? category)
        {
            await InitializeLayoutComponentsAsync(articleRepository);
            this.Articles = await articleRepository.GetArticleListingsByCategory(category);
            this.MetaDescription = $"Новини от {this.MetaDescription}";
            this.MetaKeywords = $"новини {this.MetaKeywords}";
            this.MetaTitle = $"Новини от {this.MetaTitle}";
            return this;
        }

        public static Task<ListArticlesByCategoryOutputModel> CreateAsync(IArticleRepository articleRepository, string? category)
        {
            var frpgouput = new ListArticlesByCategoryOutputModel();
            return frpgouput.InitializeAsync(articleRepository, category);
        }
    }
}
