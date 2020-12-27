using FluentAssertions;
using SportBox7.Domain.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SportBox7.Domain.Models.Articles
{
    public class SocialSignalSpecs
    {
        [Fact]
        public void CreateObjectWithInvalidIpShouldThrowException()
        {
            //Arrange and Act
            Action act = () => new SocialSignal("18", false);

            act.Should().Throw<InvalidSocialSignalException>();
            //Assert
        }

        [Fact]
        public void CreateObjectWithValidIpShouldNotThrowException()
        {
            //Arrange and Act
            Action act = () => new SocialSignal("188.255.202.141", false);

            act.Should().NotThrow<InvalidSocialSignalException>();
            //Assert
        }
    }
}
