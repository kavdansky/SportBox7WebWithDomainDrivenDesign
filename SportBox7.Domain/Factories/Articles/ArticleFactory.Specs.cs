namespace SportBox7.Domain.Factories.Articles
{
    using FluentAssertions;
    using SportBox7.Domain.Exeptions;
    using SportBox7.Domain.Models.Articles.Enums;
    using SportBox7.Domain.Models.Categories;
    using SportBox7.Domain.Models.Sources;
    using System;
    using Xunit;

    public class ArticleFactorySpecs
    {
        [Fact]
        public void BuildShouldThrowExceptionIfTitleIsNotSet()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            Action act = () => articleFactory
                .WithArticleType(ArticleType.NewsArticle)
                .WithBody("Test Body body")
                .WithCategory(new Category("Футбол", "Football"))
                .WithH1Tag("Test H1 tag")
                .WithImageUrl("https://imgurl")
                .WithMetaDescription("test meta descr")
                .WithMetaKeywords("Meta keywords test")
                .WithTargetDate(new DateTime(2020, 11, 8))
                .WithImageCredit("https://ImageCredit")
                .WithSource(new Source("sportbox7", "https://imgurl", "https://imgurl"))
                .Build();

            // Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfBodyIsNotSet()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            Action act = () => articleFactory
                .WithArticleType(ArticleType.NewsArticle)
                .WithCategory(new Category("Футбол", "Football"))
                .WithH1Tag("Test H1 tag")
                .WithImageUrl("https://imgurl")
                .WithMetaDescription("test meta descr")
                .WithMetaKeywords("Meta keywords test")
                .WithTargetDate(new DateTime(2020, 11, 8))
                .WithImageCredit("https://ImageCredit")
                .WithTitle("Test title")
                .WithSource(new Source("sportbox7", "https://imgurl", "https://imgurl"))
                .Build();

            // Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfCategoryIsNotSet()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            Action act = () => articleFactory
                .WithArticleType(ArticleType.NewsArticle)
                .WithBody("Test Body body")
                .WithH1Tag("Test H1 tag")
                .WithImageUrl("https://imgurl")
                .WithMetaDescription("test meta descr")
                .WithMetaKeywords("Meta keywords test")
                .WithTargetDate(new DateTime(2020, 11, 8))
                .WithImageCredit("https://ImageCredit")
                .WithTitle("Test title")
                .WithSource(new Source("sportbox7", "https://imgurl", "https://imgurl"))
                .Build();

            // Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfH1IsNotSet()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            Action act = () => articleFactory
                .WithArticleType(ArticleType.NewsArticle)
                .WithBody("Test Body body")
                .WithCategory(new Category("Футбол", "Football"))
                .WithImageUrl("https://imgurl")
                .WithMetaDescription("test meta descr")
                .WithMetaKeywords("Meta keywords test")
                .WithTargetDate(new DateTime(2020, 11, 8))
                .WithImageCredit("https://ImageCredit")
                .WithTitle("Test title")
                .WithSource(new Source("sportbox7", "https://imgurl", "https://imgurl"))
                .Build();

            // Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfImageUrlNotSet()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            Action act = () => articleFactory
                .WithArticleType(ArticleType.NewsArticle)
                .WithBody("Test Body body")
                .WithCategory(new Category("Футбол", "Football"))
                .WithH1Tag("Test H1 tag")
                .WithMetaDescription("test meta descr")
                .WithMetaKeywords("Meta keywords test")
                .WithTargetDate(new DateTime(2020, 11, 8))
                .WithImageCredit("https://ImageCredit")
                .WithTitle("Test title")
                .WithSource(new Source("sportbox7", "https://imgurl", "https://imgurl"))
                .Build();

            // Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfMetaDescriptionIsNotSet()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            Action act = () => articleFactory
                .WithArticleType(ArticleType.NewsArticle)
                .WithBody("Test Body body")
                .WithCategory(new Category("Футбол", "Football"))
                .WithH1Tag("Test H1 tag")
                .WithImageUrl("https://imgurl")
                .WithMetaKeywords("Meta keywords test")
                .WithTargetDate(new DateTime(2020, 11, 8))
                .WithImageCredit("https://ImageCredit")
                .WithTitle("Test title")
                .WithSource(new Source("sportbox7", "https://imgurl", "https://imgurl"))
                .Build();

            // Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfMetaKeywordsIsNotSet()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            Action act = () => articleFactory
                .WithArticleType(ArticleType.NewsArticle)
                .WithBody("Test Body body")
                .WithCategory(new Category("Футбол", "Football"))
                .WithH1Tag("Test H1 tag")
                .WithImageUrl("https://imgurl")
                .WithMetaDescription("test meta descr")
                .WithTargetDate(new DateTime(2020, 11, 8))
                .WithImageCredit("https://ImageCredit")
                .WithTitle("Test title")
                .WithSource(new Source("sportbox7", "https://imgurl", "https://imgurl"))
                .Build();

            // Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfImageCreditIsNotSet()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            Action act = () => articleFactory
                .WithArticleType(ArticleType.NewsArticle)
                .WithBody("Test Body body")
                .WithCategory(new Category("Футбол", "Football"))
                .WithH1Tag("Test H1 tag")
                .WithImageUrl("https://imgurl")
                .WithMetaDescription("test meta descr")
                .WithMetaKeywords("Meta keywords test")
                .WithTargetDate(new DateTime(2020, 11, 8))
                .WithTitle("Test title")
                .WithSource(new Source("sportbox7", "https://imgurl", "https://imgurl"))
                .Build();

            // Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfSourceIsNotSet()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            Action act = () => articleFactory
                .WithArticleType(ArticleType.NewsArticle)
                .WithBody("Test Body body")
                .WithCategory(new Category("Футбол", "Football"))
                .WithH1Tag("Test H1 tag")
                .WithImageUrl("https://imgurl")
                .WithMetaDescription("test meta descr")
                .WithMetaKeywords("Meta keywords test")
                .WithTargetDate(new DateTime(2020, 11, 8))
                .WithTitle("Test title")
                .WithImageCredit("https://ImageCredit")
                .Build();

            // Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void BuildShouldNotThrowExceptionIfEverithingIsFine()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            Action act = () => articleFactory
                .WithArticleType(ArticleType.NewsArticle)
                .WithBody("Test Body body")
                .WithCategory(new Category("Футбол", "Football"))
                .WithH1Tag("Test H1 tag")
                .WithImageUrl("https://imgurl")
                .WithMetaDescription("test meta descr")
                .WithMetaKeywords("Meta keywords test")
                .WithTargetDate(new DateTime(2020, 11, 8))
                .WithTitle("Test title")
                .WithImageCredit("https://ImageCredit")
                .WithSource(new Source("sportbox7", "https://imgurl", "https://imgurl"))
                .Build();

            // Assert
            act.Should().NotThrow<InvalidArticleException>();
        }


    }
}
