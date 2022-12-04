using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using ShortLinkService.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using ShortLinkService.Web.Infrastructure;
using System;

namespace ShortLinkService.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _appSettings = configuration.ConfigureAppSettings();
        }

        private readonly AppSettings _appSettings;
        private readonly IConfiguration _configuration;


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddLocalizations();
            services.AddFactoryContext(_appSettings.ConnectionString);
            services.MigrateDb();
            services.AddServices(_appSettings);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.AddAllowedCultures();
            app.UseRouting();
            app.UseMiddleware<ExceptionHandler>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Main}/{action=Index}");
                endpoints.MapGet("/favicon.ico", async (context) =>
                {
                    context.Response.StatusCode = 404;
                });
                endpoints.MapRazorPages();
            });
        }
    }
}
