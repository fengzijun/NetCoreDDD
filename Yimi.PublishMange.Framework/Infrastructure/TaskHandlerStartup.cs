using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yimi.PublishManage.Core.Infrastructure;
using Yimi.PublishManage.Core.Data;
using FluentScheduler;
using System;
using Yimi.PublishManage.Core;

namespace Yimi.PublishManage.Framework.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring task on application startup
    /// </summary>
    public class TaskHandlerStartup : IYimiStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration root of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
            if (DataSettingsHelper.DatabaseIsInstalled())
            {
                var logger = EngineContext.Current.Resolve<ILogger>();
                //database is already installed, so start scheduled tasks
                try
                {
                    JobManager.UseUtcTime();
                    JobManager.JobException += info => logger.WriteError(info.Exception);
                    //var scheduleTasks = ScheduleTaskManager.Instance.LoadScheduleTasks();       //load records from db to collection
                    //JobManager.Initialize(new RegistryYimiNode(scheduleTasks));                //init registry and start scheduled tasks
                }
                catch (Exception ex)
                {
                    logger.WriteError(ex);
                }
            }


        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order
        {
            //task handlers should be loaded last
            get { return 500; }
        }
    }
}
