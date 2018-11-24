using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Yimi.PublishManage.Framework.FluentValidation;
using Yimi.PublishManage.Framework.Mvc.ModelBinding;
using Yimi.PublishManage.Framework.Themes;
using FluentValidation.AspNetCore;
using System.Linq;
using Yimi.PublishManage.Core;
using System.IO;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc.Internal;
using Yimi.PublishManage.Framework.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Yimi.PublishManage.Core.Configuration;
using Yimi.PublishManage.Core.Infrastructure;
using Yimi.PublishManage.Core.Data;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Service;
using Microsoft.AspNetCore.Http.Features;

namespace Yimi.PublishManage.Framework.Infrastructure.Extensions
{
    /// <summary>
    /// Represents extensions of IServiceCollection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services to the application and configure service provider
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration root of the application</param>
        /// <returns>Configured service provider</returns>
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //add YimiConfig configuration parameters
            services.ConfigureStartupConfig<YimiConfig>(configuration.GetSection("YimiConfig"));
            //add hosting configuration parameters
            services.ConfigureStartupConfig<HostingConfig>(configuration.GetSection("Hosting"));
            //add accessor to HttpContext
            services.AddHttpContextAccessor();

            services.Configure<FormOptions>(x=> {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
            });
        
            //create, initialize and configure the engine
            var engine = EngineContext.Create();
            engine.Initialize(services);
            var serviceProvider = engine.ConfigureServices(services, configuration);

            if (DataSettingsHelper.DatabaseIsInstalled())
            {
                //log application start
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger?.Writelog("Application started");
            }

            return serviceProvider;
        }

        /// <summary>
        /// Create, bind and register as service the specified configuration parameters 
        /// </summary>
        /// <typeparam name="TConfig">Configuration parameters</typeparam>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Set of key/value application configuration properties</param>
        /// <returns>Instance of configuration parameters</returns>
        public static TConfig ConfigureStartupConfig<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            //create instance of config
            var config = new TConfig();

            //bind it to the appropriate section of configuration
            configuration.Bind(config);

            //and register it as a service
            services.AddSingleton(config);

            return config;
        }

        /// <summary>
        /// Register HttpContextAccessor
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }

        /// <summary>
        /// Adds services required for anti-forgery support
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddAntiForgery(this IServiceCollection services)
        {
            //override cookie name
            services.AddAntiforgery(options =>
            {
                options.Cookie = new CookieBuilder()
                {
                    Name = ".Yimi.PublishManage.Antiforgery"
                };
                if (DataSettingsHelper.DatabaseIsInstalled())
                {
                    //whether to allow the use of anti-forgery cookies from SSL protected page on the other store pages which are not
                    //options.Cookie.SecurePolicy = EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                    //? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                }
            });
        }

        /// <summary>
        /// Adds services required for application session state
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddHttpSession(this IServiceCollection services)
        {
            //services.AddSession(options =>
            //{
            //    options.Cookie = new CookieBuilder()
            //    {
            //        Name = ".Yimi.PublishManage.Session",
            //        HttpOnly = true,
            //    };
            //    if (DataSettingsHelper.DatabaseIsInstalled())
            //    {
            //        //whether to allow the use of session values from SSL protected page on the other store pages which are not
            //        //options.Cookie.SecurePolicy = EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
            //        //    ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
            //        options.Cookie.SecurePolicy = CookieSecurePolicy.None;
            //    }
            //});
            services.AddSession();
        }

        /// <summary>
        /// Adds services required for themes support
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddThemes(this IServiceCollection services)
        {
            if (!DataSettingsHelper.DatabaseIsInstalled())
                return;

            //themes support
            services.Configure<RazorViewEngineOptions>(options =>
            {
               // options.ViewLocationExpanders.Add(new ThemeableViewLocationExpander());
            });
        }

        /// <summary>
        /// Adds data protection services
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddYimiDataProtection(this IServiceCollection services)
        {
            var dataProtectionKeysPath = CommonHelper.MapPath("~/App_Data/DataProtectionKeys");
            var dataProtectionKeysFolder = new DirectoryInfo(dataProtectionKeysPath);

            //configure the data protection system to persist keys to the specified directory
            services.AddDataProtection().PersistKeysToFileSystem(dataProtectionKeysFolder);
        }

        /// <summary>
        /// Adds authentication service
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddYimiAuthentication(this IServiceCollection services)
        {
            //set default authentication schemes
            var authenticationBuilder = services.AddAuthentication(options =>
            {
                options.DefaultScheme = YimiCookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = YimiCookieAuthenticationDefaults.ExternalAuthenticationScheme;
               
            });

            //add main cookie authentication
            authenticationBuilder.AddCookie(YimiCookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.Name = YimiCookieAuthenticationDefaults.CookiePrefix + YimiCookieAuthenticationDefaults.AuthenticationScheme;
                options.Cookie.HttpOnly = true;
                options.LoginPath = YimiCookieAuthenticationDefaults.LoginPath;
                options.AccessDeniedPath = YimiCookieAuthenticationDefaults.AccessDeniedPath;

                //whether to allow the use of authentication cookies from SSL protected page on the other store pages which are not
                //options.Cookie.SecurePolicy = DataSettingsHelper.DatabaseIsInstalled() && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                //    ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.None;
            });

            //add external authentication
            authenticationBuilder.AddCookie(YimiCookieAuthenticationDefaults.ExternalAuthenticationScheme, options =>
            {
                options.Cookie.Name = YimiCookieAuthenticationDefaults.CookiePrefix + YimiCookieAuthenticationDefaults.ExternalAuthenticationScheme;
                options.Cookie.HttpOnly = true;
                options.LoginPath = YimiCookieAuthenticationDefaults.LoginPath;
                options.AccessDeniedPath = YimiCookieAuthenticationDefaults.AccessDeniedPath;

                //whether to allow the use of authentication cookies from SSL protected page on the other store pages which are not
                //options.Cookie.SecurePolicy = DataSettingsHelper.DatabaseIsInstalled() && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                //    ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.None;
            });
            /*
            //enable main cookie authentication
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = YimiCookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(YimiCookieAuthenticationDefaults.AuthenticationScheme,
                options =>
                {
                    options.ClaimsIssuer = YimiCookieAuthenticationDefaults.ClaimsIssuer;
                    options.Cookie = new CookieBuilder()
                    {
                        Name = YimiCookieAuthenticationDefaults.CookiePrefix + YimiCookieAuthenticationDefaults.AuthenticationScheme,
                        HttpOnly = true,
                    };
                    options.LoginPath = YimiCookieAuthenticationDefaults.LoginPath;
                    options.AccessDeniedPath = YimiCookieAuthenticationDefaults.AccessDeniedPath;
                    options.LogoutPath = YimiCookieAuthenticationDefaults.LogoutPath;
                    if (DataSettingsHelper.DatabaseIsInstalled())
                    {
                        //whether to allow the use of authentication cookies from SSL protected page on the other store pages which are not
                        options.Cookie.SecurePolicy = EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                        ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
                    }
                }
            );

            //enable external authentication
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = YimiCookieAuthenticationDefaults.ExternalAuthenticationScheme;
            })
            .AddCookie(YimiCookieAuthenticationDefaults.ExternalAuthenticationScheme,
                options =>
                {
                    options.ClaimsIssuer = YimiCookieAuthenticationDefaults.ClaimsIssuer;
                    options.Cookie = new CookieBuilder()
                    {
                        Name = YimiCookieAuthenticationDefaults.CookiePrefix + YimiCookieAuthenticationDefaults.AuthenticationScheme,
                        HttpOnly = true,
                    };
                    options.LoginPath = YimiCookieAuthenticationDefaults.LoginPath;
                    options.AccessDeniedPath = YimiCookieAuthenticationDefaults.AccessDeniedPath;
                    options.LogoutPath = YimiCookieAuthenticationDefaults.LogoutPath;

                    // whether to allow the use of authentication cookies from SSL protected page on the other store pages which are not
                    if (DataSettingsHelper.DatabaseIsInstalled())
                    {
                        options.Cookie.SecurePolicy = EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                         ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
                    }
                }
            );
            */

            //register external authentication plugins now
            //var typeFinder = new WebAppTypeFinder();
            //var externalAuthConfigurations = typeFinder.FindClassesOfType<IExternalAuthenticationRegistrar>();
            ////create and sort instances of external authentication configurations
            //var externalAuthInstances = externalAuthConfigurations
            //    .Where(x => PluginManager.FindPlugin(x)?.Installed ?? true) //ignore not installed plugins
            //    .Select(x => (IExternalAuthenticationRegistrar)Activator.CreateInstance(x))
            //    .OrderBy(x => x.Order);

            ////configure services
            //foreach (var instance in externalAuthInstances)
            //    instance.Configure(authenticationBuilder);


        }

        /// <summary>
        /// Add and configure MVC for the application
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <returns>A builder for configuring MVC services</returns>
        public static IMvcBuilder AddYimiMvc(this IServiceCollection services)
        {
            //add basic MVC feature
            var mvcBuilder = services.AddMvc();

            //MVC now serializes JSON with camel case names by default, use this code to avoid it
            mvcBuilder.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            //add custom display metadata provider
            mvcBuilder.AddMvcOptions(options => options.ModelMetadataDetailsProviders.Add(new YimiMetadataProvider()));

            //add fluent validation
            mvcBuilder.AddFluentValidation(configuration => configuration.ValidatorFactoryType = typeof(YimiValidatorFactory));

            return mvcBuilder;
        }

        /// <summary>
        /// Register custom RedirectResultExecutor
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddYimiRedirectResultExecutor(this IServiceCollection services)
        {
            //we use custom redirect executor as a workaround to allow using non-ASCII characters in redirect URLs
            services.AddSingleton<RedirectResultExecutor, YimiRedirectResultExecutor>();
        }
    }
}
