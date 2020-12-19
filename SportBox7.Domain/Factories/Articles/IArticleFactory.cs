using SportBox7.Domain.Models.Articles;
using SportBox7.Domain.Models.Articles.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Factories.Articles
{
    public interface IArticleFactory: IFactory<Article>
    {
        IArticleFactory WithTitle(string title);

        IArticleFactory WithBody(string body);

        IArticleFactory WithH1Tag(string h1Tag);

        IArticleFactory WithImageUrl(string imageUrl);

        IArticleFactory WithSeoUrl(string seoUrl);

        IArticleFactory WithMetaDescription(string metaDescription);

        IArticleFactory WithMetaKeywords(string metaKeywords);

        IArticleFactory WithCategory(string name, string nameEn);

        IArticleFactory WithArticleType(ArticleType articleType);

        IArticleFactory WithTargetDate(DateTime targetDate);

    }
}
