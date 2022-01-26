namespace SportBox7.Application.Features.Articles.Queries.Category
{
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Sources.Contracts;
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

        public string MetaDescription { get; set; } = default!;

        public string MetaKeywords { get; set; } = default!;

        public string MetaTitle { get; set; } = default!;

        private async Task<ListArticlesByCategoryOutputModel> InitializeAsync(IArticleRepository articleRepository, ICategoryRepository categoryRepository, string? category)
        {
            await InitializeLayoutComponentsAsync(articleRepository, categoryRepository);
            this.Articles = await articleRepository.GetArticleListingsByCategory(category);
            this.CurrentCategory = await categoryRepository.GetCategoryByName(category);
            if (this.CurrentCategory == null)
            {
                this.MetaDescription = $"Последни новини от sportbox7.com";
                this.MetaKeywords = $"Последни новини спорт";
                this.MetaTitle = $"Последни новини от sportbox7.com";
            }
            else
            {
                this.MetaDescription = $"Новини от {this.CurrentCategory.CategoryName}";
                this.MetaKeywords = $"новини от {this.CurrentCategory.CategoryName}";
                this.MetaTitle = $"Новини от {this.CurrentCategory.CategoryName}";
            }
            
            return this;
        }

        public static Task<ListArticlesByCategoryOutputModel> CreateAsync(IArticleRepository articleRepository, ICategoryRepository categoryRepository, string? category)
        {
            var frpgouput = new ListArticlesByCategoryOutputModel();
            return frpgouput.InitializeAsync(articleRepository, categoryRepository, category);
        }
    }
}
