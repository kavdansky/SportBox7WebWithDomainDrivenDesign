using Microsoft.Extensions.DependencyInjection;
using SportBox7.Application.Contracts;
using SportBox7.Web.Services;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Text;
using SportBox7.Application.Common;

namespace SportBox7.Web
{
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

            return services;
        }
    }
}
