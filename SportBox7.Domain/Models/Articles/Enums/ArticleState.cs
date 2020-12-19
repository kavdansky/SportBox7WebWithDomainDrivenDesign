using SportBox7.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Models.Articles.Enums
{
    public enum ArticleState 
    {
        RawArticle = 0,
        Draft = 1,
        ForReview = 2,
        Published = 3
    }
}
