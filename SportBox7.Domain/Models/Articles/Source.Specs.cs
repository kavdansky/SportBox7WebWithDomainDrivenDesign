using FakeItEasy;
using FluentAssertions;
using SportBox7.Domain.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SportBox7.Domain.Models.Articles
{
    public class SourceSpecs
    {
       

        [Fact]
        public void UpdateSourceNameWithInvalidStringShouldThrowException()
        {
            //Arrange
            Source source = new Source(
                    "Gong.bg",
                    "http://gong.bg",
                    "http://gong.bg/images"
                    );

            //Act
            Action act = () => source.UpdateSourceName("mm");

            //Assert
            act.Should().Throw<InvalidSourceException>();
        }

        [Fact]
        public void UpdateSourceNameWithValidStringShouldNotThrowException()
        {
            //Arrange
            Source source = new Source(
                    "Gong.bg",
                    "http://gong.bg",
                    "http://gong.bg/images"
                    );

            //Act
            Action act = () => source.UpdateSourceName("Peho e nomer 1");

            //Assert
            act.Should().NotThrow<InvalidSourceException>();
        }

        [Fact]
        public void UpdateSourceUrlWithValidUrlShouldNotThrowException()
        {
            //Arrange
            Source source = new Source(
                    "Gong.bg",
                    "http://gong.bg",
                    "http://gong.bg/images"
                    );

            //Act
            Action act = () => source.UpdateSourceUrl("http://pik.bg");

            //Assert
            act.Should().NotThrow<InvalidSourceException>();
        }

        [Fact]
        public void UpdateSourceUrlWithInvalidUrlShouldThrowException()
        {
            //Arrange
            Source source = new Source(
                    "Gong.bg",
                    "http://gong.bg",
                    "http://gong.bg/images"
                    );

            //Act
            Action act = () => source.UpdateSourceUrl("http//pik.bg");

            //Assert
            act.Should().Throw<InvalidSourceException>();
        }

        [Fact]
        public void UpdateSourceImageUrlWithValidUrlShouldNotThrowException()
        {
            //Arrange
            Source source = new Source(
                    "Gong.bg",
                    "http://gong.bg",
                    "http://gong.bg/images"
                    );

            //Act
            Action act = () => source.UpdateSourceImageUrl("http://pik.bg");

            //Assert
            act.Should().NotThrow<InvalidSourceException>();
        }

        [Fact]
        public void UpdateSourceImageUrlWithInvalidUrlShouldThrowException()
        {
            //Arrange
            Source source = new Source(
                    "Gong.bg",
                    "http://gong.bg",
                    "http://gong.bg/images"
                    );

            //Act
            Action act = () => source.UpdateSourceImageUrl("http//pik.bg");

            //Assert
            act.Should().Throw<InvalidSourceException>();
        }
    }
}
