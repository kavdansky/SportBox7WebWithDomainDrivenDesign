namespace SportBox7.Application.Features.Articles.Queries.Category
{
    using SportBox7.Application.Features.Articles.Queries.Common;
    using System;

    public class ArticleByCategoryListingModel: ArticleListingModel
    {
        public ArticleByCategoryListingModel(
            int id, 
            string title,
            string h1,
            string body,
            string imageUrl,
            string category,
            string categoryEn,
            string imageCredit, 
            DateTime targetDate)
            :base(id, title, h1, body, imageUrl, category, categoryEn, imageCredit, targetDate)
        {     }
    }
}
