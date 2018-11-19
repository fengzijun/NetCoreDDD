using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yimi.PublishManage.Framework.Infrastructure.Extensions;
using Yimi.PublishManage.Core.Infrastructure;
using Yimi.PublishManage.Core.Data;

namespace Yimi.PublishManage.Framework.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring authentication middleware on application startup
    /// </summary>
    public class AuthenticationStartup : IYimiStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration root of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //add data protection
            services.AddYimiDataProtection();
            //add authentication
            services.AddYimiAuthentication();
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
            //check whether database is installed
            if (!DataSettingsHelper.DatabaseIsInstalled())
                return;

            //configure authentication
            application.UseYimiAuthentication();

            //set request culture
            application.UseCulture();
        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order
        {
            //authentication should be loaded before MVC
            get { return 500; }
        }
    }
}
