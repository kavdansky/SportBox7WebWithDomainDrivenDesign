using FluentAssertions;
using SportBox7.Domain.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SportBox7.Domain.Models.Articles
{
    public class CategorySpecs
    {
        [Fact]
        public void CreateCategoryWithInvalidNameShouldThrowException()
        {
            //Arrange and Act 
            Action act = () => new Category("", "Valleyball");

            //Assert
            act.Should().Throw<InvalidCategoryException>();
        }

        [Fact]
        public void CreateCategoryWithInvalidNameENShouldThrowException()
        {
            //Arrange and Act 
            Action act = () => new Category("Valleyball", "..");

            //Assert
            act.Should().Throw<InvalidCategoryException>();
        }

        [Fact]
        public void CreateCategoryWithValidNamesShouldNotThrowException()
        {
            //Arrange and Act 
            Action act = () => new Category("Волейбол", "Valleyball");

            //Assert
            act.Should().NotThrow<InvalidCategoryException>();
        }
    }
}
