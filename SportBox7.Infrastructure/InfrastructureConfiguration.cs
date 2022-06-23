namespace SportBox7.Infrastructure
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Identity;
    using SportBox7.Infrastructure.Identity;
    using SportBox7.Infrastructure.ImageHandling;
    using SportBox7.Infrastructure.TextHandling;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddRepositories()
                .AddIdentity()
                .AddImageManipulationProvider()
                .AddTextManipulationProvider();


        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<SportBox7DbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(SportBox7DbContext)
                                .Assembly.FullName)))
            .AddTransient<IInitializer, SportBox7DbInitializer>();
            

        internal static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IRepository<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime());

        private static IServiceCollection AddIdentity(
            this IServiceCollection services)
        {
            
            services.AddHttpContextAccessor();

            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SportBox7DbContext>()
                .AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddTransient<SignInManager<User>>();
            services.AddTransient<UserManager<User>>();
            services.AddTransient<RoleManager<IdentityRole>>();
            services.AddTransient<IIdentity, IdentityService>();
           
            return services;
        }

        private static IServiceCollection AddImageManipulationProvider(this IServiceCollection services)
            => services.AddTransient<IImageManipulationService, ImageManipulationService>();

        private static IServiceCollection AddTextManipulationProvider(this IServiceCollection services)
            => services.AddTransient<ITextManipulationService, TextManipulationService>();
    }
}
