using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Application.Features.Articles.Queries.Common
{
    public abstract class BaseArticleModel
    {
        public BaseArticleModel(int id, string title, string categoryEN, string categoryName, string seoUrl, string imageUrl)
        {
            this.Id = id;
            this.Title = title;
            this.CategoryEN = categoryEN;
            this.CategoryName = categoryName;
            this.SeoUrl = seoUrl;
            this.ImageUrl = imageUrl;

        }
        public int Id { get; set; }

        public string Title { get; set; } = default!;

        public string CategoryEN { get; set; } = default!;

        public string CategoryName { get; set; } = default!;

        public string SeoUrl { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;
    }
}
