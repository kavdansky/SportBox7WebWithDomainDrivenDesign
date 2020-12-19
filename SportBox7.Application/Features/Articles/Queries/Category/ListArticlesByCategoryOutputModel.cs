namespace SportBox7.Application.Features.Articles.Queries.Category
{
    using System.Collections.Generic;
    using System.Linq;

    public class ListArticlesByCategoryOutputModel
    {
        internal ListArticlesByCategoryOutputModel(IEnumerable<ArticleListingModel> articles)
        {
            this.Articles = articles;          
        }

        public IEnumerable<ArticleListingModel> Articles { get; }

        public int Total 
        {
            get
            {
                return Articles.Count();
            }
        }
    }
}
