using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yimi.PublishManage.Framework.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Yimi.PublishManage.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment, ILoggerFactory logger)
        {
            //create configuration
            //logger.AddConsole();
            //Console.WriteLine($"GetCurrentDirectory:{AppDomain.CurrentDomain.BaseDirectory}");
            //Console.WriteLine($"ContentRootPath:{environment.ContentRootPath}");
            //environment.ContentRootPath = AppDomain.CurrentDomain.BaseDirectory;
            //environment.WebRootPath = AppDomain.CurrentDomain.BaseDirectory;
            if (!environment.IsDevelopment())
            {
                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            }

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Add services to the application and configure service provider
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.ConfigureApplicationServices(Configuration);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();
           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //string logpath = AppDomain.CurrentDomain.BaseDirectory + "log4net.config";
            loggerFactory.AddLog4Net();

            app.ConfigureRequestPipeline();
        }
    }
}
