namespace SportBox7.Application.Features.Articles.Queries.Category
{
    using SportBox7.Application.Features.Articles.Queries.Common;
    using System;

    public class ArticleByCategoryListingModel: ArticleListingModel
    {
        public ArticleByCategoryListingModel(
            int id, 
            string title,
            string body,
            string imageUrl,
            string category,
            string categoryEn,
            string imageCredit, 
            DateTime targetDate)
            :base(id, title, body, imageUrl, category, categoryEn, imageCredit, targetDate)
        {     }
    }
}
