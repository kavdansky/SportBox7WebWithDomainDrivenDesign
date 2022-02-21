using FakeItEasy;
using FluentAssertions;
using SportBox7.Domain.Exeptions;
using SportBox7.Domain.Models.Articles.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SportBox7.Domain.Models.Articles
{
    public class ArticleSpecs
    {
        [Fact]
        public void NewsArticleTypeShouldHaveNullTargetDate()
        {
            //Arrange
            Article article = A.Dummy<Article>();

            //Act
            article.TargetDate.Should().Equals(null); 
        }

        [Fact]
        public void UpdateArticleTitleWithInvalidStringShouldThrowException()
        {
            //Arrange
            Article article = A.Dummy<Article>();

            //Act
            Action act = () => article.UpdateTitle("a");

            //Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void UpdateArticleTitleWithValidStringShouldSaveNewData()
        {
            //Arrange
            Article article = A.Dummy<Article>();

            //Act
            article.UpdateTitle("Unique title");

            //Assert
            article.Title.Should().Equals("Unique title");           
        }

        [Fact]
        public void UpdateBodyTitleWithInvalidStringShouldThrowException()
        {
            //Arrange
            Article article = A.Dummy<Article>();

            //Act
            Action act = () => article.UpdateBody("a");

            //Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void UpdateBodyTitleWithValidStringShouldSaveNewData()
        {
            //Arrange
            Article article = A.Dummy<Article>();

            //Act
            article.UpdateTitle("Unique title");

            //Assert
            article.Title.Should().Equals("Unique title");
        }

        [Fact]
        public void UpdateH1TagWithInvalidStringShouldThrowException()
        {
            //Arrange
            Article article = A.Dummy<Article>();

            //Act
            Action act = () => article.UpdateH1Tag("a");

            //Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void UpdateH1TagWithValidStringShouldSaveNewData()
        {
            //Arrange
            Article article = A.Dummy<Article>();

            //Act
            article.UpdateH1Tag("Unique title");

            //Assert
            article.Title.Should().Equals("Unique title");
        }

        [Fact]
        public void UpdateImageUrlWithEmtyStringShouldThrowException()
        {
            //Arrange
            Article article = A.Dummy<Article>();

            //Act
            Action act = () => article.UpdateImageUrl(string.Empty);

            //Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void UpdateImageUrlWithValidStringShouldSaveNewData()
        {
            //Arrange
            Article article = A.Dummy<Article>();

            //Act
            article.UpdateImageUrl("https://oop.bg");

            //Assert
            article.Title.Should().Equals("https://oop.bg");
        }

        [Fact]
        public void UpdateSeoUrlWithInvalidUrlShouldThrowException()
        {
            //Arrange
            Article article = A.Dummy<Article>();

            //Act
            Action act = () => article.UpdateSeoUrl("a");

            //Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void UpdateSeoUrlWithValidUrlShouldSaveNewData()
        {
            //Arrange
            Article article = A.Dummy<Article>();

            //Act
            Action act = () => article.UpdateSeoUrl("https://oop.bg");

            //Assert
            act.Should().Equals("https://oop.bg");
        }

        [Fact]
        public void UpdateMetaDescriptionWithInvalidStringShouldThrowException()
        {
            //Arrange
            Article article = A.Dummy<Article>();

            //Act
            Action act = () => article.UpdateMetaDescription("a");

            //Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void UpdateMetaDescriptionWithValidStringShouldSaveNewData()
        {
            //Arrange
            Article article = A.Dummy<Article>();

            //Act
            article.UpdateMetaDescription("Unique title");

            //Assert
            article.Title.Should().Equals("Unique title");
        }

        [Fact]
        public void UpdateMetaKeywordsWithInvalidStringShouldThrowException()
        {
            //Arrange
            Article article = A.Dummy<Article>();

            //Act
            Action act = () => article.UpdateMetaKeywords("a");

            //Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void UpdateMetaKeywordsWithValidStringShouldSaveNewData()
        {
            //Arrange
            Article article = A.Dummy<Article>();

            //Act
            article.UpdateMetaKeywords("Unique title");

            //Assert
            article.Title.Should().Equals("Unique title");
        }
    }
}
