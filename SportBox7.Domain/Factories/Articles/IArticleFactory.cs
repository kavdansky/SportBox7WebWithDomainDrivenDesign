namespace SportBox7.Domain.Factories.Articles
{
    using SportBox7.Domain.Models.Articles;
    using SportBox7.Domain.Models.Articles.Enums;
    using SportBox7.Domain.Models.Categories;
    using SportBox7.Domain.Models.Sources;
    using System;

    public interface IArticleFactory: IFactory<Article>
    {
        IArticleFactory WithTitle(string title);

        IArticleFactory WithBody(string body);

        IArticleFactory WithH1Tag(string h1Tag);

        IArticleFactory WithImageUrl(string imageUrl);

        IArticleFactory WithImageCredit(string ImageCredit);

        IArticleFactory WithMetaDescription(string metaDescription);

        IArticleFactory WithMetaKeywords(string metaKeywords);

        IArticleFactory WithCategory(Category category);

        IArticleFactory WithArticleType(ArticleType articleType);

        IArticleFactory WithTargetDate(DateTime targetDate);

        IArticleFactory WithSource(Source source);

    }
}
