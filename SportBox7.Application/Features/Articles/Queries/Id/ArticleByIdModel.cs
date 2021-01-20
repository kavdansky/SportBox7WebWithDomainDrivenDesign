namespace SportBox7.Application.Features.Articles.Queries.Id
{
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Articles.Queries.Common;

    public class ArticleByIdModel: ArticleListingModel, IMetaTagable
    {
        public ArticleByIdModel(
            int id,
            string title,
            string body,
            string imageUrl,
            string category,
            string categoryEn,
            string seoUrl,
            string metaDescription,
            string metaKeywords,
            string metaTitle)
            : base(id, title, body, imageUrl, category, categoryEn, seoUrl)
        {
            this.MetaDescription = metaDescription;
            this.MetaKeywords = metaKeywords;
            this.MetaTitle = metaTitle;
        }

        public string MetaDescription { get; set; } = default!;

        public string MetaKeywords { get; set; } = default!;

        public string MetaTitle { get; set; } = default!;
    }
}
