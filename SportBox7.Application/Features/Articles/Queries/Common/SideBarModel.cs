using System;

namespace SportBox7.Application.Features.Articles.Queries.Common
{
    public class SideBarModel: BaseArticleModel
    {
        public SideBarModel(int id, string title,string h1Tag, string categoryEN, string categoryName, string ImageCredit, string imageUrl, DateTime targetDate)
            :base(id, title, h1Tag, categoryEN, categoryName, ImageCredit, imageUrl, targetDate)
        {
        }
    }
}
