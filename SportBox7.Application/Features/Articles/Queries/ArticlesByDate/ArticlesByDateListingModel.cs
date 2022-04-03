namespace SportBox7.Application.Features.Articles.Queries.ArticlesByDate
{
    using SportBox7.Application.Features.Articles.Queries.Common;
    using System;

    public class ArticlesByDateListingModel: ArticleListingModel
    {
        public ArticlesByDateListingModel(
            int id,
            string title,
            string body,
            string imageUrl,
            string category,
            string categoryEn,
            string ImageCredit,
            DateTime targetDate)
            : base(id, title, body, imageUrl, category, categoryEn, ImageCredit)
        {
            this.TargetDate = targetDate;
        }

        public DateTime TargetDate { get; set; }
    }
}
