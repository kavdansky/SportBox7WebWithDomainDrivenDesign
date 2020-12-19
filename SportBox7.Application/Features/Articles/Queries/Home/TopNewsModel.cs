using SportBox7.Application.Features.Articles.Queries.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Application.Features.Articles.Queries.HomePage
{
    public class TopNewsModel: BasicNewsModel
    {
        
        public TopNewsModel(int id, string title, string categoryEN, string categoryName, string seoUrl, string imageUrl, string body)
            :base(title, categoryEN, categoryName, seoUrl, imageUrl)
        {
            this.Body = body;
        }

        public string Body { get; set; }

    }
}
