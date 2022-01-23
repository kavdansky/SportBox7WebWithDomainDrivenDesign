namespace SportBox7.Startup
{
    using System;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Domain.Factories.Editors;
    using SportBox7.Domain.Models.Editors;
    using SportBox7.Infrastructure.Identity;
    using SportBox7.Infrastructure.Persistence;

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
                    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    var editorFactory = serviceProvider.GetRequiredService<IEditorFactory>();
                    var editorRepository = serviceProvider.GetRequiredService<IEditorRepository>();
                    UserAndRoleDataInitializer.SeedData(userManager, roleManager, editorFactory, editorRepository);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
