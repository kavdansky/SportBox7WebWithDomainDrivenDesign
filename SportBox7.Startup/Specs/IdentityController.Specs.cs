﻿namespace SportBox7.Startup.Specs
{
    using Application.Features.Identity.Commands.CreateUser;
    using Application.Features.Identity.Commands.LoginUser;
    using MyTested.AspNetCore.Mvc;
    using Web.Controllers;
    using Xunit;

    public class IdentityControllerSpecs
    {
        [Fact]
        public void RegisterShouldHaveCorrectAttributes()
            => MyController<IdentityController>
                .Calling(c => c
                    .Register(CreateUserCommandFakes.Data.GetCommand()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .SpecifyingRoute("identity/register"));

        [Fact]
        public void LoginShouldHaveCorrectAttributes()
            => MyController<IdentityController>
                .Calling(c => c
                    .Login(With.Default<LoginUserCommand>()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .SpecifyingRoute("identity/login"));

    }
}
