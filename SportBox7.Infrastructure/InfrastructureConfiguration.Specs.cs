namespace SportBox7.Infrastructure
{
    using System;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;
    using SportBox7.Application.Features.Articles;
    using SportBox7.Application.Features.Articles.Contrcts;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<SportBox7DbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()));

            // Act
            var services = serviceCollection
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IArticleRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
