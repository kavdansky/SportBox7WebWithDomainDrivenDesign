using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Application.Features.Articles.Queries.Common
{
    public class LatestNewsModel
    {
        public LatestNewsModel(int articleId, string categoryNameEn, string title, DateTime targeTDate)
        {
            this.ArticleId = articleId;
            this.CategoryNameEn = categoryNameEn;
            this.Title = title;
            this.TargetDate = targeTDate;
        }
        public DateTime TargetDate { get; set; }

        public int ArticleId { get; set; }

        public string CategoryNameEn { get; set; }

        public string Title { get; set; }

    }
}
