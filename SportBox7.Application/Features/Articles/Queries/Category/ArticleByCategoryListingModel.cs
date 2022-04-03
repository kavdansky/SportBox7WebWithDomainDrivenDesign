namespace SportBox7.Application.Features.Articles.Queries.Category
{
    using SportBox7.Application.Features.Articles.Queries.Common;

    public class ArticleByCategoryListingModel: ArticleListingModel
    {
        public ArticleByCategoryListingModel(
            int id, 
            string title,
            string body,
            string imageUrl,
            string category,
            string categoryEn,
            string ImageCredit)
            :base(id, title, body, imageUrl, category, categoryEn, ImageCredit)
        {     }
    }
}
