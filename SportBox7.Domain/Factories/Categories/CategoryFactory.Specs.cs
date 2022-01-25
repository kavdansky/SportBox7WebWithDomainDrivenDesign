namespace SportBox7.Domain.Factories.Categories
{
    using FluentAssertions;
    using SportBox7.Domain.Exeptions;
    using System;
    using Xunit;

    public class CategoryFactorySpecs
    {
        [Fact]
        public void BuildShouldNotThrowExceptionIfEverythingIsFine()
        {
            // Assert
            var categoryFactory = new CategoryFactory();

            // Act
            Action act = () => categoryFactory
                .WithCategoryName("Крикет")
                .WithCategoryNameEN("Cricket")
                .Build();

            // Assert
            act.Should().NotThrow<InvalidCategoryException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfCategoryNameIsMissing()
        {
            // Assert
            var categoryFactory = new CategoryFactory();

            // Act
            Action act = () => categoryFactory
                .WithCategoryNameEN("Cricket")
                .Build();

            // Assert
            act.Should().Throw<InvalidCategoryException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfCategoryNameEnIsMissing()
        {
            // Assert
            var categoryFactory = new CategoryFactory();

            // Act
            Action act = () => categoryFactory
                .WithCategoryName("Крикет")
                .Build();

            // Assert
            act.Should().Throw<InvalidCategoryException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfCategoryNameAndCategoryNameEnAreMissing()
        {
            // Assert
            var categoryFactory = new CategoryFactory();

            // Act
            Action act = () => categoryFactory
                .Build();

            // Assert
            act.Should().Throw<InvalidCategoryException>();
        }
    }
}
