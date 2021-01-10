namespace SportBox7.Application.Features.Articles.Queries.Id
{
    using SportBox7.Application.Features.Articles.Queries.Common;

    public class ArticleByIdListingModel: ArticleListingModel
    {
        public ArticleByIdListingModel(
            int id,
            string title,
            string body,
            string imageUrl,
            string category,
            string seoUrl)
            : base(id, title, body, imageUrl, category, seoUrl)
        { }
    }
}
