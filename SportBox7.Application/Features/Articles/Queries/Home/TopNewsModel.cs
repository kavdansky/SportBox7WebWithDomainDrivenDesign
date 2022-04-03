using SportBox7.Application.Features.Articles.Queries.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Application.Features.Articles.Queries.HomePage
{
    public class TopNewsModel: BaseArticleModel
    {
        
        public TopNewsModel(int id, string title, string categoryEN, string categoryName, string imageCredit, string imageUrl, string body)
            :base(id, title, categoryEN, categoryName, imageCredit, imageUrl)
        {
            this.Body = body;
        }

        public string Body { get; set; }

    }
}
