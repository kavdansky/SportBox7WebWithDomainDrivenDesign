using SportBox7.Application.Features.Articles.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportBox7.Application.Features.Articles.Queries.HomePage
{
    public class FrontPageOutputModel
    {
        private IArticleRepository articleRepository = default!;

        public FrontPageOutputModel()
        {
           
        }
        public IEnumerable<MenuCategoriesModel> MenuCategories { get; set; } = default!;

        public IEnumerable<LatestNewsModel> LatestNews { get; set; } = default!;

        public IEnumerable<SideBarModel> SideBar { get; set; } = default!;

        public IEnumerable<TopNewsModel> Topnews { get; set; } = default!;

        private async Task<FrontPageOutputModel> InitializeAsync(IArticleRepository articleRepository)
        {
            
            
            this.articleRepository = articleRepository;
            this.MenuCategories = await articleRepository.GetMenuCategories();
            this.LatestNews = await articleRepository.GetLatestNews();
            this.Topnews = await articleRepository.GetTopNews();
            this.SideBar = articleRepository.GetsideBarNews();
            
            return this;
        }

        public static Task<FrontPageOutputModel> CreateAsync(IArticleRepository articleRepository)
        {
            
            var frpgouput = new FrontPageOutputModel();
            return frpgouput.InitializeAsync(articleRepository);
        }




    }
}
