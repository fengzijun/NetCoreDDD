using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Framework.Mvc.Routing;
using Yimi.PublishManage.Framework.Themes;
using Yimi.PublishManage.Framework.UI;
using MongoDB.Driver;
using Yimi.PublishManage.Services;
using Yimi.PublishManage.Core.Infrastructure.DependencyManagement;
using Yimi.PublishManage.Core.Infrastructure;
using Yimi.PublishManage.Core.Configuration;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Http;
using Yimi.PublishManage.Core.Data;
using Yimi.PublishManage.Data;
using Yimi.PublishManage.Core.Plugins;
using Yimi.PublishManage.Core.Caching;
using Yimi.PublishManage.Services.Events;
using Yimi.PublishManage.Service;
using Yimi.PublishManage.Service.IService;

namespace Yimi.PublishManage.Framework.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, YimiConfig config)
        {            

            //web helper
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();
            //user agent helper
            builder.RegisterType<UserAgentHelper>().As<IUserAgentHelper>().InstancePerLifetimeScope();
            //powered by
            builder.RegisterType<PoweredByMiddlewareOptions>().As<IPoweredByMiddlewareOptions>().SingleInstance();

            //data layer
            var dataSettingsManager = new DataSettingsManager();
            var dataProviderSettings = dataSettingsManager.LoadSettings();
            builder.Register(c => dataSettingsManager.LoadSettings()).As<DataSettings>();
            builder.Register(x => new MongoDBDataProviderManager(x.Resolve<DataSettings>())).As<BaseDataProviderManager>().InstancePerDependency();
            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerDependency();

            if (dataProviderSettings != null && dataProviderSettings.IsValid())
            {
                builder.Register<IMongoClient>(c => new MongoClient(dataProviderSettings.DataConnectionString)).SingleInstance();
                builder.Register<IMongoDBContext>(c => new MongoDBContext(dataProviderSettings.DataConnectionString)).InstancePerLifetimeScope();
            }
            else
            {
                builder.RegisterType<MongoDBContext>().As<IMongoDBContext>().InstancePerLifetimeScope();
            }

            //MongoDbRepository
            builder.RegisterGeneric(typeof(MongoDBRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //plugins
            builder.RegisterType<PluginFinder>().As<IPluginFinder>().InstancePerLifetimeScope();

            //cache manager
            builder.RegisterType<PerRequestCacheManager>().InstancePerLifetimeScope();

            //cache manager
            if (config.RedisCachingEnabled)
            {
                builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>("Yimi_cache_static").SingleInstance();
                builder.RegisterType<RedisConnectionWrapper>().As<IRedisConnectionWrapper>().SingleInstance();
                builder.RegisterType<RedisCacheManager>().As<ICacheManager>().InstancePerLifetimeScope();
            }
            else
            {
                builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>("Yimi_cache_static").SingleInstance();
            }

            builder.RegisterType<Deafultlogger>().As<ILogger>().InstancePerLifetimeScope();
            builder.RegisterType<PermissionService>().As<IPermissionService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<MenuService>().As<IMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<CookieAuthenticationService>().As<IYimiAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<SqlPublishService>().As<ISqlPublishService>().InstancePerLifetimeScope();
            builder.RegisterType<QuoteService>().As<IQuoteService>().InstancePerLifetimeScope();
            //if (config.RunOnAzureWebApps)
            //{
            //    builder.RegisterType<AzureWebAppsMachineNameProvider>().As<IMachineNameProvider>().SingleInstance();
            //}
            //else
            //{
            //    builder.RegisterType<DefaultMachineNameProvider>().As<IMachineNameProvider>().SingleInstance();
            //}


            //work context
            builder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerLifetimeScope();
            //store context
            //builder.RegisterType<WebStoreContext>().As<IStoreContext>().InstancePerLifetimeScope();

            //services

            //if (config.RedisCachingEnabled)
            //{
            //    builder.RegisterType<SettingService>().As<ISettingService>()
            //        .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("Yimi_cache_static"))
            //        .InstancePerLifetimeScope();

            //    builder.RegisterType<LocalizationService>().As<ILocalizationService>()
            //        .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("Yimi_cache_static"))
            //        .InstancePerLifetimeScope();
            //}
            //else
            //{
            //    builder.RegisterType<SettingService>().As<ISettingService>().InstancePerLifetimeScope();
            //    builder.RegisterType<LocalizationService>().As<ILocalizationService>().InstancePerLifetimeScope();
            //}

            //builder.RegisterSource(new SettingsSource());

            //builder.RegisterType<LanguageService>().As<ILanguageService>().InstancePerLifetimeScope();
            //builder.RegisterType<DownloadService>().As<IDownloadService>().InstancePerLifetimeScope();

            //picture service
            //var useAzureBlobStorage = !String.IsNullOrEmpty(config.AzureBlobStorageConnectionString);
            //var useAmazonBlobStorage = (!String.IsNullOrEmpty(config.AmazonAwsAccessKeyId) && !String.IsNullOrEmpty(config.AmazonAwsSecretAccessKey) && !String.IsNullOrEmpty(config.AmazonBucketName) && !String.IsNullOrEmpty(config.AmazonRegion));

            //if (useAzureBlobStorage)
            //{
            //    //Windows Azure BLOB
            //    builder.RegisterType<AzurePictureService>().As<IPictureService>().InstancePerLifetimeScope();
            //}
            //else if (useAmazonBlobStorage)
            //{
            //    //Amazon S3 Simple Storage Service
            //    builder.RegisterType<AmazonPictureService>().As<IPictureService>().InstancePerLifetimeScope();
            //}
            //else
            //{
            //    //standard file system
            //    builder.RegisterType<PictureService>().As<IPictureService>().InstancePerLifetimeScope();
            //}

            //builder.RegisterType<MessageTemplateService>().As<IMessageTemplateService>().InstancePerLifetimeScope();
            //builder.RegisterType<QueuedEmailService>().As<IQueuedEmailService>().InstancePerLifetimeScope();
            //builder.RegisterType<NewsLetterSubscriptionService>().As<INewsLetterSubscriptionService>().InstancePerLifetimeScope();
            //builder.RegisterType<NewsletterCategoryService>().As<INewsletterCategoryService>().InstancePerLifetimeScope();
            //builder.RegisterType<CampaignService>().As<ICampaignService>().InstancePerLifetimeScope();
            //builder.RegisterType<BannerService>().As<IBannerService>().InstancePerLifetimeScope();
            //builder.RegisterType<PopupService>().As<IPopupService>().InstancePerLifetimeScope();
            //builder.RegisterType<InteractiveFormService>().As<IInteractiveFormService>().InstancePerLifetimeScope();
            //builder.RegisterType<EmailAccountService>().As<IEmailAccountService>().InstancePerLifetimeScope();
            //builder.RegisterType<WorkflowMessageService>().As<IWorkflowMessageService>().InstancePerLifetimeScope();
            //builder.RegisterType<ContactAttributeFormatter>().As<IContactAttributeFormatter>().InstancePerLifetimeScope();
            //builder.RegisterType<ContactAttributeParser>().As<IContactAttributeParser>().InstancePerLifetimeScope();
            //builder.RegisterType<ContactAttributeService>().As<IContactAttributeService>().InstancePerLifetimeScope();
            //builder.RegisterType<MessageTokenProvider>().As<IMessageTokenProvider>().InstancePerLifetimeScope();
            //builder.RegisterType<Tokenizer>().As<ITokenizer>().InstancePerLifetimeScope();
            //builder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerLifetimeScope();
            //builder.RegisterType<HistoryService>().As<IHistoryService>().InstancePerLifetimeScope();
            //builder.RegisterType<CheckoutAttributeFormatter>().As<ICheckoutAttributeFormatter>().InstancePerLifetimeScope();
            //builder.RegisterType<CheckoutAttributeParser>().As<ICheckoutAttributeParser>().InstancePerLifetimeScope();
            //builder.RegisterType<CheckoutAttributeService>().As<ICheckoutAttributeService>().InstancePerLifetimeScope();
            //builder.RegisterType<GiftCardService>().As<IGiftCardService>().InstancePerLifetimeScope();
            //builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();
            //builder.RegisterType<OrderReportService>().As<IOrderReportService>().InstancePerLifetimeScope();
            //builder.RegisterType<OrderProcessingService>().As<IOrderProcessingService>().InstancePerLifetimeScope();
            //builder.RegisterType<OrderTotalCalculationService>().As<IOrderTotalCalculationService>().InstancePerLifetimeScope();
            //builder.RegisterType<ReturnRequestService>().As<IReturnRequestService>().InstancePerLifetimeScope();
            //builder.RegisterType<RewardPointsService>().As<IRewardPointsService>().InstancePerLifetimeScope();
            //builder.RegisterType<ShoppingCartService>().As<IShoppingCartService>().InstancePerLifetimeScope();
            //builder.RegisterType<PaymentService>().As<IPaymentService>().InstancePerLifetimeScope();
            //builder.RegisterType<EncryptionService>().As<IEncryptionService>().InstancePerLifetimeScope();
            //builder.RegisterType<CookieAuthenticationService>().As<IYimiAuthenticationService>().InstancePerLifetimeScope();
            //builder.RegisterType<UrlRecordService>().As<IUrlRecordService>().InstancePerLifetimeScope();
            //builder.RegisterType<ShipmentService>().As<IShipmentService>().InstancePerLifetimeScope();
            //builder.RegisterType<ShippingService>().As<IShippingService>().InstancePerLifetimeScope();
            //builder.RegisterType<TaxCategoryService>().As<ITaxCategoryService>().InstancePerLifetimeScope();
            //builder.RegisterType<TaxService>().As<ITaxService>().InstancePerLifetimeScope();
            //builder.RegisterType<TaxCategoryService>().As<ITaxCategoryService>().InstancePerLifetimeScope();
            //builder.RegisterType<DefaultLogger>().As<ILogger>().InstancePerLifetimeScope();
            //builder.RegisterType<ContactUsService>().As<IContactUsService>().InstancePerLifetimeScope();
            //builder.RegisterType<CustomerActivityService>().As<ICustomerActivityService>().InstancePerLifetimeScope();
            //builder.RegisterType<ActivityKeywordsProvider>().As<IActivityKeywordsProvider>().InstancePerLifetimeScope();

            bool databaseInstalled = DataSettingsHelper.DatabaseIsInstalled();
            //if (!databaseInstalled)
            //{
            //    //installation service
            //    builder.RegisterType<CodeFirstInstallationService>().As<IInstallationService>().InstancePerLifetimeScope();
            //}
            //else
            //{
            //    builder.RegisterType<UpgradeService>().As<IUpgradeService>().InstancePerLifetimeScope();
            //}

            //builder.RegisterType<ForumService>().As<IForumService>().InstancePerLifetimeScope();
            //builder.RegisterType<KnowledgebaseService>().As<IKnowledgebaseService>().InstancePerLifetimeScope();
            //builder.RegisterType<PushNotificationsService>().As<IPushNotificationsService>().InstancePerLifetimeScope();
            //builder.RegisterType<PollService>().As<IPollService>().InstancePerLifetimeScope();
            //builder.RegisterType<BlogService>().As<IBlogService>().InstancePerLifetimeScope();
            //builder.RegisterType<WidgetService>().As<IWidgetService>().InstancePerLifetimeScope();
            //builder.RegisterType<TopicService>().As<ITopicService>().InstancePerLifetimeScope();
            //builder.RegisterType<NewsService>().As<INewsService>().InstancePerLifetimeScope();
            //builder.RegisterType<DateTimeHelper>().As<IDateTimeHelper>().InstancePerLifetimeScope();
            //builder.RegisterType<SitemapGenerator>().As<ISitemapGenerator>().InstancePerLifetimeScope();
            builder.RegisterType<PageHeadBuilder>().As<IPageHeadBuilder>().InstancePerLifetimeScope();
            //builder.RegisterType<ScheduleTaskService>().As<IScheduleTaskService>().InstancePerLifetimeScope();
            //builder.RegisterType<ExportManager>().As<IExportManager>().InstancePerLifetimeScope();
            //builder.RegisterType<ImportManager>().As<IImportManager>().InstancePerLifetimeScope();
            //builder.RegisterType<PdfService>().As<IPdfService>().InstancePerLifetimeScope();
            builder.RegisterType<ThemeProvider>().As<IThemeProvider>().InstancePerLifetimeScope();
            builder.RegisterType<ThemeContext>().As<IThemeContext>().InstancePerLifetimeScope();
            //builder.RegisterType<ExternalAuthenticationService>().As<IExternalAuthenticationService>().InstancePerLifetimeScope();
            //builder.RegisterType<GoogleAnalyticsService>().As<IGoogleAnalyticsService>().InstancePerLifetimeScope();

            builder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();

            //Register event consumers
            var consumers = typeFinder.FindClassesOfType(typeof(IConsumer<>)).ToList();
            foreach (var consumer in consumers)
            {
                builder.RegisterType(consumer)
                    .As(consumer.GetTypeInfo().FindInterfaces((type, criteria) =>
                    {
                        var isMatch = type.GetTypeInfo().IsGenericType && ((Type)criteria).IsAssignableFrom(type.GetGenericTypeDefinition());
                        return isMatch;
                    }, typeof(IConsumer<>)))
                    .InstancePerLifetimeScope();
            }

            builder.RegisterType<EventPublisher>().As<IEventPublisher>().SingleInstance();
            builder.RegisterType<SubscriptionService>().As<ISubscriptionService>().SingleInstance();

            //TASKS
            //builder.RegisterType<QueuedMessagesSendScheduleTask>().InstancePerLifetimeScope();
            //builder.RegisterType<ClearCacheScheduleTask>().InstancePerLifetimeScope();
            //builder.RegisterType<ClearLogScheduleTask>().InstancePerLifetimeScope();
            //builder.RegisterType<CustomerReminderAbandonedCartScheduleTask>().InstancePerLifetimeScope();
            //builder.RegisterType<CustomerReminderBirthdayScheduleTask>().InstancePerLifetimeScope();
            //builder.RegisterType<CustomerReminderCompletedOrderScheduleTask>().InstancePerLifetimeScope();
            //builder.RegisterType<CustomerReminderLastActivityScheduleTask>().InstancePerLifetimeScope();
            //builder.RegisterType<CustomerReminderLastPurchaseScheduleTask>().InstancePerLifetimeScope();
            //builder.RegisterType<CustomerReminderRegisteredCustomerScheduleTask>().InstancePerLifetimeScope();
            //builder.RegisterType<CustomerReminderUnpaidOrderScheduleTask>().InstancePerLifetimeScope();
            //builder.RegisterType<DeleteGuestsScheduleTask>().InstancePerLifetimeScope();
            //builder.RegisterType<UpdateExchangeRateScheduleTask>().InstancePerLifetimeScope();
            //builder.RegisterType<EndAuctionsTask>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// Gets order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    }


    public class SettingsSource : IRegistrationSource
    {
        static readonly MethodInfo BuildMethod = typeof(SettingsSource).GetMethod(
            "BuildRegistration",
            BindingFlags.Static | BindingFlags.NonPublic);

        public IEnumerable<IComponentRegistration> RegistrationsFor(
            Autofac.Core.Service service,
            Func<Autofac.Core.Service, IEnumerable<IComponentRegistration>> registrations)
        {
            var ts = service as TypedService;
            if (ts != null && typeof(ISettings).IsAssignableFrom(ts.ServiceType))
            {
                var buildMethod = BuildMethod.MakeGenericMethod(ts.ServiceType);
                yield return (IComponentRegistration)buildMethod.Invoke(null, null);
            }
        }

        //static IComponentRegistration BuildRegistration<TSettings>() where TSettings : ISettings, new()
        //{
        //    return RegistrationBuilder
        //        .ForDelegate((c, p) =>
        //        {
        //            var currentStoreId = c.Resolve<IStoreContext>().CurrentStore.Id;
        //            return c.Resolve<ISettingService>().LoadSetting<TSettings>(currentStoreId);
        //        })
        //        .InstancePerLifetimeScope()
        //        .CreateRegistration();
        //}

        public bool IsAdapterForIndividualComponents { get { return false; } }
    }

}
