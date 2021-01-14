using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using SportBox7.Application;
using SportBox7.Domain;
using SportBox7.Infrastructure;
using SportBox7.Web;

namespace SportBox7.Startup
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDomain();
            services.AddApplication(this.Configuration);
            services.AddInfrastructure(this.Configuration);
            services.AddWebComponents();
            services.AddRazorPages();
        }

        



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app
                //.UseValidationExceptionHandler()
                .UseHttpsRedirection()
                .UseAuthentication()
                .UseAuthorization()
                .UseStaticFiles(new StaticFileOptions()
                 {
                     FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory().Replace("Startup", "Web"), "wwwroot")),
                 })
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                
                .Initialize();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
                endpoints.MapRazorPages();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "articlesById",
                   pattern: "{controller=Articles}/all/{action=Id}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "articlesByCategory",
                    pattern: "{controller=Articles}/{action=Category}/{category?}");
            });

            
        }
    }
}