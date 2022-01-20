namespace SportBox7.Application.Features.Articles.Queries.HomePage
{
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FrontPageOutputModel: PageLayoutOutpuModel, IMetaTagable
    {
        public FrontPageOutputModel()
        {
            this.MetaTitle = "Новини от спорта - sportbox7.com";
            this.MetaDescription = "Последни новини и събития от спорта- информация, мнения и социални мрежи.";
            this.MetaKeywords = "спорт, спортни новини, футбол, баскетбол, волейбол, бойни спортове";
        }

        public IEnumerable<TopNewsModel> Topnews { get; set; } = default!;

        public string MetaDescription { get; set; } = default!;

        public string MetaKeywords { get; set; } = default!;

        public string MetaTitle { get; set; } = default!;

        public DateTime TargetDate { get; set; }

        private async Task<FrontPageOutputModel> InitializeAsync(IArticleRepository articleRepository)
        {
            await InitializeLayoutComponentsAsync(articleRepository);
            this.Topnews = await articleRepository.GetTopNews();
            this.TargetDate = DateTime.Now;
            return this;
        }

        public static Task<FrontPageOutputModel> CreateAsync(IArticleRepository articleRepository)
        {
            var frpgouput = new FrontPageOutputModel();
            return frpgouput.InitializeAsync(articleRepository);
        }
    }
}
