namespace SportBox7.Application.Features.Articles.Queries.Id
{
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using System;

    public class ArticleByIdModel: ArticleListingModel, IMetaTagable
    {
        public ArticleByIdModel(
            int id,
            string title,
            string h1,
            string body,
            string imageUrl,
            string category,
            string categoryEn,
            string imageCredit,
            string metaDescription,
            string metaKeywords,
            string metaTitle,
            DateTime targetDate,
            string source)
            : base(id, title, h1, body, imageUrl, category, categoryEn, imageCredit, targetDate)
        {
            this.MetaDescription = metaDescription;
            this.MetaKeywords = metaKeywords;
            this.MetaTitle = metaTitle;
            this.Source = source;
        }
        
        public string MetaDescription { get; set; } = default!;

        public string MetaKeywords { get; set; } = default!;

        public string MetaTitle { get; set; } = default!;

        public string Source { get; set; } = default!;

    }
}
