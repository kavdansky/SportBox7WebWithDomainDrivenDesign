namespace SportBox7.Domain.Factories.Sources
{
    using FluentAssertions;
    using SportBox7.Domain.Exeptions;
    using SportBox7.Domain.Models.Sources;
    using System;
    using Xunit;

    public class SourceFactorySpecs
    {
        [Fact]
        public void BuildShouldThrowExceptionIfSourceNameIsNotSet()
        {
            // Assert
            var sourceFactory = new SourceFactory();

            // Act
            Action act = () => sourceFactory
            .WithSourceImageUrl("http://jijojo.bg")
            .WithSourceUrl("http://jijojo.bg")
            .Build();
             
            // Assert
            act.Should().Throw<InvalidSourceException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfSourceImageUrlIsNotSet()
        {
            // Assert
            var sourceFactory = new SourceFactory();

            // Act
            Action act = () => sourceFactory
            .WithSourceName("Sportal")
            .WithSourceUrl("http://jijojo.bg")
            .Build();

            // Assert
            act.Should().Throw<InvalidSourceException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfSourceUrlIsNotSet()
        {
            // Assert
            var sourceFactory = new SourceFactory();

            // Act
            Action act = () => sourceFactory
            .WithSourceName("Sportal")
            .WithSourceImageUrl("http://jijojo.bg")
            .Build();

            // Assert
            act.Should().Throw<InvalidSourceException>();
        }
    }
}
