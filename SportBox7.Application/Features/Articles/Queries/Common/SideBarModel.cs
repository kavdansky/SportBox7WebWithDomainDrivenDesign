using System;

namespace SportBox7.Application.Features.Articles.Queries.Common
{
    public class SideBarModel: BaseArticleModel
    {
        public SideBarModel(int id, string title, string categoryEN, string categoryName, string ImageCredit, string imageUrl, DateTime targetDate)
            :base(id, title, categoryEN, categoryName, ImageCredit, imageUrl, targetDate)
        {
        }
    }
}
