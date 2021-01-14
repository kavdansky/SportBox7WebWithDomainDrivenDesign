namespace SportBox7.Application.Features.Articles.Queries.Common
{
    using SportBox7.Application.Features.Articles.Contrcts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public abstract class PageLayoutOutpuModel
    {
        
        public PageLayoutOutpuModel()
        {
        }
        public IEnumerable<MenuCategoriesModel> MenuCategories { get; set; } = default!;

        public IEnumerable<LatestNewsModel> LatestNews { get; set; } = default!;

        public IEnumerable<SideBarModel> SideBar { get; set; } = default!;

        protected async Task<bool> InitializeLayoutComponentsAsync(IArticleRepository articleRepository)
        {
            this.MenuCategories = await articleRepository.GetMenuCategories();
            this.LatestNews = await articleRepository.GetLatestNews();
            this.SideBar = articleRepository.GetsideBarNews();
            return true;
        }


    }
}
