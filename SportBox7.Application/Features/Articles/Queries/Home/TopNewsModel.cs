using SportBox7.Application.Features.Articles.Queries.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Application.Features.Articles.Queries.HomePage
{
    public class TopNewsModel: BaseArticleModel
    {
        
        public TopNewsModel(int id, string title, string h1Tag, string categoryEN, string categoryName, string imageCredit, string imageUrl, string body, DateTime targetDate)
            :base(id, title, h1Tag, categoryEN, categoryName, imageCredit, imageUrl, targetDate)
        {
            this.Body = body;
        }

        public string Body { get; set; }

        public int PasedYears
        {
            get
            {
                return DateTime.Now.Year - this.TargetDate.Year;
            }
        }

    }
}
