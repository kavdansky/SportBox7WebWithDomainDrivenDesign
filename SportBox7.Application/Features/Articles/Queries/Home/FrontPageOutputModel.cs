using SportBox7.Application.Features.Articles.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportBox7.Application.Features.Articles.Queries.HomePage
{
    public class FrontPageOutputModel: PageLayoutOutpuModel
    {
        private IArticleRepository articleRepository = default!;

        public FrontPageOutputModel()
        {
           
        }
        public IEnumerable<TopNewsModel> Topnews { get; set; } = default!;

        private async Task<FrontPageOutputModel> InitializeAsync(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
            await InitializeLayoutComponentsAsync(articleRepository);
            this.Topnews = await articleRepository.GetTopNews();
            
            return this;
        }

        public static Task<FrontPageOutputModel> CreateAsync(IArticleRepository articleRepository)
        {
            
            var frpgouput = new FrontPageOutputModel();
            return frpgouput.InitializeAsync(articleRepository);
        }




    }
}
