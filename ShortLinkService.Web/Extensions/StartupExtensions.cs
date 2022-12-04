using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShortLinkService.Dto.Interfaces;
using ShortLinkService.Web.Entities;
using ShortLinkService.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ShortLinkService.Web.Extensions
{
    public static class StartupExtensions
    {
        public static void AddAllowedCultures(this IApplicationBuilder app)
        {
            IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("ru-RU")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
        }

        public static void AddLocalizations(this IServiceCollection services)
        {
            services.AddLocalization(opt => 
            {
                opt.ResourcesPath = "Resources"; 
            });
        }
        
        public static void AddServices(this IServiceCollection services, AppSettings appSettings) 
        {
            var generator = Create<IBitmapCodeGenerator>(appSettings.CodeGenerationType);
            var factory = services.BuildServiceProvider().GetService<DbFactory<ShortLinkServiceDbContext>>();
            var linkService = Create<IShortLinkService>(appSettings.LinkServiceImplementation, generator, factory);

            services.AddSingleton(generator);
            services.AddSingleton(linkService);
        }

        public static void AddFactoryContext(this IServiceCollection services, string connectionString)
        {
            var optBuilder = new DbContextOptionsBuilder<ShortLinkServiceDbContext>();
            optBuilder.UseSqlServer(connectionString);
            optBuilder.EnableSensitiveDataLogging();

            var factory = new DbFactory<ShortLinkServiceDbContext>(() =>
            {
                return new ShortLinkServiceDbContext(optBuilder.Options);
            });
            services.AddSingleton(factory);
        }

        public static void MigrateDb(this IServiceCollection services)
        {
            var factory = services.BuildServiceProvider().GetService<DbFactory<ShortLinkServiceDbContext>>();
            var context = factory.Create();
            var mingations = context.Database.GetService<IMigrator>();
            mingations.Migrate();
        }

        public static AppSettings ConfigureAppSettings(this IConfiguration Configuration)
        {
            AppSettings sett = Configuration.GetSection("AppSettings").Get<AppSettings>();
            return sett;
        }

        private static T Create<T>(string implementation, params object[] parameters)
        {
            Type type = Type.GetType(implementation);
            return (T)Activator.CreateInstance(type, parameters);
        }
    }
}
