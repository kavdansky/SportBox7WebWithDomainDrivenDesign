namespace SportBox7.Application.Features.Articles.Queries.Common
{
    using SportBox7.Application.Features.Articles.Contrcts;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SportBox7.Domain.Models.Categories;
    using SportBox7.Application.Features.Sources.Contracts;

    public abstract class PageLayoutOutpuModel
    {
        
        public PageLayoutOutpuModel(){}

        public IEnumerable<MenuCategoriesModel> MenuCategories { get; set; } = default!;

        public IEnumerable<LatestNewsModel> LatestNews { get; set; } = default!;

        public IEnumerable<LatestNewsModel> OnTheDayArticles { get; set; } = default!;

        public IEnumerable<SideBarModel> SideBar { get; set; } = default!;

        public Category CurrentCategory { get; set; } = default!;

        protected async Task<bool> InitializeLayoutComponentsAsync(IArticleRepository articleRepository, ICategoryRepository categoryRepository)
        {
            this.MenuCategories = await categoryRepository.GetMenuCategories();
            this.LatestNews = await articleRepository.GetLatestNews();
            this.OnTheDayArticles = await articleRepository.GetOnTheDayArticles();
            this.SideBar = articleRepository.GetsideBarNews();
            return true;
        }


    }
}
