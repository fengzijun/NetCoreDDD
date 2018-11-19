using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Net.Http.Headers;
using Yimi.PublishManage.Framework.Infrastructure.Extensions;
using Yimi.PublishManage.Core.Infrastructure;
using Yimi.PublishManage.Core.Configuration;

namespace Yimi.PublishManage.Framework.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring common features and middleware on application startup
    /// </summary>
    public class YimiCommonStartup : IYimiStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration root of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //compression
            services.AddResponseCompression();

            //add options feature
            services.AddOptions();
            
            //add memory cache
            services.AddMemoryCache();

            //add distributed memory cache
            services.AddDistributedMemoryCache();
                        
            //add HTTP sesion state feature
            services.AddHttpSession();

            //add anti-forgery
            services.AddAntiForgery();

            //add localization
            services.AddLocalization();

            //add theme support
            services.AddThemes();
            
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
            var YimiConfig = EngineContext.Current.Resolve<YimiConfig>();

            //compression
            if (YimiConfig.UseResponseCompression)
            {
                //gzip by default
                application.UseResponseCompression();
            }

            //static files
            application.UseStaticFiles(new StaticFileOptions
            {
                //TODO duplicated code (below)
                OnPrepareResponse = ctx =>
                {
                    if (!String.IsNullOrEmpty(YimiConfig.StaticFilesCacheControl))
                        ctx.Context.Response.Headers.Append(HeaderNames.CacheControl, YimiConfig.StaticFilesCacheControl);
                }
            });
            //themes
            application.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Themes")),
                RequestPath = new PathString("/Themes"),
                OnPrepareResponse = ctx =>
                {
                    if (!String.IsNullOrEmpty(YimiConfig.StaticFilesCacheControl))
                        ctx.Context.Response.Headers.Append(HeaderNames.CacheControl, YimiConfig.StaticFilesCacheControl);
                }
            });
            //plugins
            application.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Plugins")),
                RequestPath = new PathString("/Plugins"),
                OnPrepareResponse = ctx =>
                {
                    if (!String.IsNullOrEmpty(YimiConfig.StaticFilesCacheControl))
                        ctx.Context.Response.Headers.Append(HeaderNames.CacheControl, YimiConfig.StaticFilesCacheControl);
                }
            });

            //browser compent
            application.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"bower_components")),
                RequestPath = new PathString("/bower_components"),
                OnPrepareResponse = ctx =>
                {
                    if (!String.IsNullOrEmpty(YimiConfig.StaticFilesCacheControl))
                        ctx.Context.Response.Headers.Append(HeaderNames.CacheControl, YimiConfig.StaticFilesCacheControl);
                }
            });

            //browser compent
            application.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"content")),
                RequestPath = new PathString("/content"),
                OnPrepareResponse = ctx =>
                {
                    if (!String.IsNullOrEmpty(YimiConfig.StaticFilesCacheControl))
                        ctx.Context.Response.Headers.Append(HeaderNames.CacheControl, YimiConfig.StaticFilesCacheControl);
                }
            });

            //browser compent
            application.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"upload")),
                RequestPath = new PathString("/upload"),
                OnPrepareResponse = ctx =>
                {
                    if (!String.IsNullOrEmpty(YimiConfig.StaticFilesCacheControl))
                        ctx.Context.Response.Headers.Append(HeaderNames.CacheControl, YimiConfig.StaticFilesCacheControl);
                }
            });

            //check whether database is installed
            if (!YimiConfig.IgnoreInstallUrlMiddleware)
                application.UseInstallUrl();

            //use HTTP session
            application.UseSession();

            //use request localization
            application.UseRequestLocalization();

            //use powered by
            if (!YimiConfig.IgnoreUsePoweredByMiddleware)
                application.UsePoweredBy();
        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order
        {
            //common services should be loaded after error handlers
            get { return 100; }
        }
    }
}
