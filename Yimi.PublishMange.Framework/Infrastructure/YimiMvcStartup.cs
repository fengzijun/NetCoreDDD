using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yimi.PublishManage.Core.Infrastructure;
using Yimi.PublishManage.Framework.Infrastructure.Extensions;

namespace Yimi.PublishManage.Framework.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring MVC on application startup
    /// </summary>
    public class YimiMvcStartup : IYimiStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration root of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //add MiniProfiler services
            services.AddMiniProfiler();

            //add and configure MVC feature
            services.AddYimiMvc();

            //add custom redirect result executor
            services.AddYimiRedirectResultExecutor();
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
            //add MiniProfiler
            //application.UseMiniProfiler();

            //MVC routing
            application.UseYimiMvc();
        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order
        {
            //MVC should be loaded last
            get { return 1000; }
        }
    }
}
