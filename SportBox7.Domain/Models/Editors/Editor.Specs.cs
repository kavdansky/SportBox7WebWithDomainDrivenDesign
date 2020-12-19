using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FakeItEasy;
using FluentAssertions;
using SportBox7.Domain.Exeptions;
using SportBox7.Domain.Models.Articles;
using SportBox7.Domain.Models.Articles.Enums;
using Xunit;

namespace SportBox7.Domain.Models.Editors
{
    public class EditorSpecs
    {
        [Fact]
        public void AddArticleShouldSaveArticle()
        {
            // Arrange
            var editor = new Editor("Lyubomir", "+Kavdansky");
            var article = A.Dummy<Article>();
            editor.Articles.Append(article);
            // Act
            editor.AddArticle(article);

            // Assert
            editor.Articles.Should().Contain(article);
        }

        [Fact]
        public void ValidEditorShouldNotThrowException()
        {
            //Act
            Action act = () => new Editor("Lyubomir", "+Kavdansky");
            //Assert
            act.Should().NotThrow<InvalidEditorException>();


        }

        [Fact]
        public void InvalidEditorShouldThrowException()
        {
            //Act
            Action act = () => new Editor("Ly", "+Kavdansky");
            //Assert
            act.Should().Throw<InvalidEditorException>();
        }
    }
}