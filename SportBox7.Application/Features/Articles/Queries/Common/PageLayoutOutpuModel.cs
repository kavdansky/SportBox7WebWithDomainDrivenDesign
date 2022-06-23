namespace SportBox7.Application.Features.Articles.Queries.Common
{
    using SportBox7.Application.Features.Articles.Contrcts;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SportBox7.Domain.Models.Categories;
    using SportBox7.Application.Features.Categories.Contracts;

    public abstract class PageLayoutOutpuModel
    {
        
        public PageLayoutOutpuModel(){}

        public IEnumerable<MenuCategoriesModel> MenuCategories { get; set; } = default!;

        public IEnumerable<LatestNewsModel> RunningTextNews { get; set; } = default!;

        public IEnumerable<SideBarModel> SideBar { get; set; } = default!;

        public Category CurrentCategory { get; set; } = default!;

        protected async Task<bool> InitializeLayoutComponentsAsync(IArticleRepository articleRepository, ICategoryRepository categoryRepository)
        {
            this.MenuCategories = await categoryRepository.GetMenuCategories();
            this.RunningTextNews = await articleRepository.GetRunningTextNews();
            this.SideBar = await articleRepository.GetsideBarNews();
            return true;
        }


    }
}
