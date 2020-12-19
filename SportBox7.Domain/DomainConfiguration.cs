using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using SportBox7.Domain.Common;
using SportBox7.Domain.Factories;
using SportBox7.Domain.Models.Articles;

namespace SportBox7.Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IFactory<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime())
            .AddTransient<IInitialData, ArticleData>();
    }
}
