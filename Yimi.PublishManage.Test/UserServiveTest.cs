using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Caching;
using Yimi.PublishManage.Core.Data;
using Yimi.PublishManage.Core.Domain;
using Yimi.PublishManage.Core.Infrastructure;
using Yimi.PublishManage.Data;
using Yimi.PublishManage.Service;
using Yimi.PublishManage.Service.IService;
using Yimi.PublishMange.Core.Caching;


namespace Yimi.PublishManage.Test
{
    [TestClass]
    public class UserServiveTest
    {
        private IRepository<Permission> _permissionRepository;
        private IRepository<SqlPublishOrder> _sqlpublishorderRepository;
        private IRepository<SqlPublishOrderApproval> _sqlpublishorderapprovalRepository;
        private IRepository<User> _userRepository;
        private IRepository<Role> _roleRepository;
        private IDataProvider _dataProvider;
        private ICacheManager _cacheManager;
        private IEventPublisher _eventPublisher;
        private IUserService _userService;


        [TestInitialize]
        public void TestInitialize()
        {
            var dataSettingsManager = new DataSettingsManager();
            
            CommonHelper.BaseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            var dataProviderSettings = dataSettingsManager.LoadSettings();

            MongoDBDataProviderManager baseDataProviderManager = new MongoDBDataProviderManager(dataProviderSettings);
            IDataProvider dataProvider = baseDataProviderManager.LoadDataProvider();
            dataProvider.InitDatabase();
            _permissionRepository = new MongoDBRepository<Permission>();
            _sqlpublishorderRepository = new MongoDBRepository<SqlPublishOrder>();
            _sqlpublishorderapprovalRepository = new MongoDBRepository<SqlPublishOrderApproval>();
            _userRepository = new MongoDBRepository<User>();
            _roleRepository = new MongoDBRepository<Role>();


            var tempEventPublisher = new Mock<IEventPublisher>();
            {
                tempEventPublisher.Setup(x => x.Publish(It.IsAny<object>()));
                _eventPublisher = tempEventPublisher.Object;
            }

            var cacheManager = new YimiNullCache();
         
            //builder.Register(c => dataSettingsManager.LoadSettings()).As<DataSettings>();
            //builder.Register(x => new MongoDBDataProviderManager(x.Resolve<DataSettings>())).As<BaseDataProviderManager>().InstancePerDependency();
            //builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerDependency();

            //if (dataProviderSettings != null && dataProviderSettings.IsValid())
            //{
            //    builder.Register<IMongoClient>(c => new MongoClient(dataProviderSettings.DataConnectionString)).SingleInstance();
            //    builder.Register<IMongoDBContext>(c => new MongoDBContext(dataProviderSettings.DataConnectionString)).InstancePerLifetimeScope();
            //}
            //else
            //{
            //    builder.RegisterType<MongoDBContext>().As<IMongoDBContext>().InstancePerLifetimeScope();
            //}
            _userService = new UserService(_userRepository, _permissionRepository, _roleRepository, _sqlpublishorderRepository, _sqlpublishorderapprovalRepository, dataProvider, cacheManager, _eventPublisher);
        }


        [TestMethod]
        public void AdduserTest()
        {

            Role role = new Role { Updatetime = DateTime.Now, Name = "Administrator", Deleted = false, Createtime = DateTime.Now };
            List<Role> roles = new List<Role>();
            roles.Add(role);
            _userService.AddUser(new User { Actived = true, Createtime = DateTime.Now, Deleted = false, Email = "12321321@111.com", LastLoginIp = "1111", Mobile = "1302312312", Name = "aaaaaa", Password = "12312", Updatetime = DateTime.Now, Roles = roles });

        }


        [TestMethod]
        public void GetUserTest()
        {
            var user = _userService.GetUserByName("aaaaaa");
            Assert.IsNotNull(user);

            var users = _userService.GetUsers();
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void GetDingdingUserTest()
        {
            var users = _userService.GetDingDingUserList();
            Assert.IsNotNull(users);
        }

    }
}
