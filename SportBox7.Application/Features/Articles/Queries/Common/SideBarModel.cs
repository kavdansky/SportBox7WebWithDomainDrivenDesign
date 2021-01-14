using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Application.Features.Articles.Queries.Common
{
    public class SideBarModel: BaseArticleModel
    {
        public SideBarModel(int id, string title, string categoryEN, string categoryName, string seoUrl, string imageUrl)
            :base(id, title, categoryEN, categoryName, seoUrl, imageUrl)
        {
        }
        

        


    }
}
