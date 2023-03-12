namespace SportBox7.Web
{
    using Microsoft.Extensions.DependencyInjection;
    using SportBox7.Application.Contracts;
    using SportBox7.Web.Services;
    using FluentValidation.AspNetCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SportBox7.Application.Common;
    using SportBox7.Application.Exceptions;

    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services
                .AddScoped<ICurrentUser, CurrentUserService>()
                .AddControllers()
                .AddFluentValidation(validation => validation
                    .RegisterValidatorsFromAssemblyContaining<Result>())
                .AddNewtonsoftJson();

            services.AddRazorPages();

            return services;
        }
    }
}
