namespace SportBox7.Application.Features.Articles.Queries.ArticlesByDate
{
    using SportBox7.Application.Features.Articles.Queries.Common;
    using System;

    public class ArticlesByDateListingModel: ArticleListingModel
    {
        public ArticlesByDateListingModel(
            int id,
            string title,
            string h1,
            string body,
            string imageUrl,
            string category,
            string categoryEn,
            string ImageCredit,
            DateTime targetDate)
            : base(id, title, h1, body, imageUrl, category, categoryEn, ImageCredit, targetDate)
        {
            this.TargetDate = targetDate;
        }
    }
}
