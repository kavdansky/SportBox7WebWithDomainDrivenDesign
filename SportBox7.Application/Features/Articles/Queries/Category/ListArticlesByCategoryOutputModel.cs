namespace SportBox7.Application.Features.Articles.Queries.Category
{
    using System.Collections.Generic;
    using System.Linq;

    public class ListArticlesByCategoryOutputModel
    {
        internal ListArticlesByCategoryOutputModel(IEnumerable<ArticleByCategoryListingModel> articles)
        {
            this.Articles = articles;          
        }

        public IEnumerable<ArticleByCategoryListingModel> Articles { get; }

        public int Total 
        {
            get
            {
                return Articles.Count();
            }
        }
    }
}
