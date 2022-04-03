using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Application.Features.Articles.Queries.Common
{
    public abstract class ArticleListingModel
    {
        public ArticleListingModel(
            int id,
            string title,
            string body,
            string imageUrl,
            string category,
            string categoryEn,
            string imageCredit)
        {
            this.Id = id;
            this.Title = title;
            this.Body = body;
            this.ImageUrl = imageUrl;
            this.Category = category;
            this.CategoryEn = categoryEn;
            this.ImageCredit = imageCredit;
        }

        public int Id { get; }

        public string Title { get; }

        public string Body { get; }

        public string ImageUrl { get; }

        public string Category { get; }

        public string CategoryEn { get; set; }

        public string ImageCredit { get; set; }
    }
}
