﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Application.Features.Articles.Queries.Common
{
    public abstract class ArticleListingModel
    {
        public ArticleListingModel(
            int id,
            string title,
            string h1,
            string body,
            string imageUrl,
            string category,
            string categoryEn,
            string imageCredit,
            DateTime tagetDate)
        {
            this.Id = id;
            this.Title = title;
            this.H1 = h1;
            this.Body = body;
            this.ImageUrl = imageUrl;
            this.Category = category;
            this.CategoryEn = categoryEn;
            this.ImageCredit = imageCredit;
            this.TargetDate = tagetDate;
        }

        public int Id { get; }

        public string Title { get; }

        public string H1 { get; set; }

        public string Body { get; }

        public string ImageUrl { get; }

        public string Category { get; }

        public string CategoryEn { get; set; }

        public string ImageCredit { get; set; }

        public DateTime TargetDate { get; set; }
    }
}
