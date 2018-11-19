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
    public class PermissionServiceTest
    {
        private IRepository<Permission> _permissionRepository;
        private IRepository<SqlPublishOrder> _sqlpublishorderRepository;
        private IRepository<SqlPublishOrderApproval> _sqlpublishorderapprovalRepository;
        private IRepository<User> _userRepository;
        private IRepository<Role> _roleRepository;
        private IRepository<Menu> _menuRepository;

        private IDataProvider _dataProvider;
        private ICacheManager _cacheManager;
        private IEventPublisher _eventPublisher;
        private IUserService _userService;
        private IMenuService _menuService;
        private IPermissionService _permissionService;
         


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
            _menuRepository = new MongoDBRepository<Menu>();
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
            _menuService = new MenuService(_menuRepository,_userRepository,_permissionRepository,_roleRepository, dataProvider, cacheManager, _eventPublisher);
            _permissionService = new PermissionService(_permissionRepository,_roleRepository,_userRepository, dataProvider, cacheManager, _eventPublisher);
        }


        [TestMethod]
        public void AddPermissionTest()
        {
            var menus = _menuService.GetMenus("");
            Permission permission = new Permission { Createtime = DateTime.Now, Deleted = false, Menus = menus, PermissionType = PermissionType.Menu, Updatetime = DateTime.Now, Name = SystemRoleNames.Administrators };

            _permissionService.AddPermission(permission);

          

            permission = new Permission { Createtime = DateTime.Now, Deleted = false, Menus = menus, PermissionType = PermissionType.Menu, Updatetime = DateTime.Now, Name = SystemRoleNames.Leader };

            _permissionService.AddPermission(permission);


         
            permission = new Permission { Createtime = DateTime.Now, Deleted = false, Menus = menus, PermissionType = PermissionType.Menu, Updatetime = DateTime.Now, Name = SystemRoleNames.Developer };

            _permissionService.AddPermission(permission);

        }

        [TestMethod]
        public void AddRoleTest()
        {
            //List<Permission> list = new List<Permission>();
            //var permission = _permissionService.GetPermission("5b1bfc52e5d30e630c34df2a");
            //list.Add(permission);
            //_roleRepository.Collection.InsertOne(new Role { Createtime = DateTime.Now, Deleted = false, Updatetime = DateTime.Now, Name = SystemRoleNames.Administrators, Permissions = list });

            //List<Permission> list = new List<Permission>();
            //var permission = _permissionService.GetPermission("5b1bfc52e5d30e630c34df2b");
            //list.Add(permission);
            //_roleRepository.Collection.InsertOne(new Role { Createtime = DateTime.Now, Deleted = false, Updatetime = DateTime.Now, Name = SystemRoleNames.Leader, Permissions = list });

            List<Permission> list = new List<Permission>();
            var permission = _permissionService.GetPermission("5b1bfc52e5d30e630c34df2c");
            list.Add(permission);
            _roleRepository.Collection.InsertOne(new Role { Createtime = DateTime.Now, Deleted = false, Updatetime = DateTime.Now, Name = SystemRoleNames.Leader, Permissions = list });


        }


        [TestMethod]
        public void AddMenuTest()
        {
            var menu = new Menu { Createtime = DateTime.Now, Updatetime = DateTime.Now, Name = "系统管理", Deleted = false, ParentId = null, Url = "#" };
            var result = _menuService.AddMenu(menu);
             menu = new Menu { Createtime = DateTime.Now, Updatetime = DateTime.Now, Name = "用户管理", Deleted = false, ParentId = result.Id, Url = "/User/Index" };
            _menuService.AddMenu(menu);
            menu = new Menu { Createtime = DateTime.Now, Updatetime = DateTime.Now, Name = "权限管理", Deleted = false, ParentId = result.Id, Url = "/Persmission/Index" };
            _menuService.AddMenu(menu);
            menu = new Menu { Createtime = DateTime.Now, Updatetime = DateTime.Now, Name = "数据里管理", Deleted = false, ParentId = result.Id, Url = "/SqlPublish/ConnectionManage" };
            _menuService.AddMenu(menu);
        }

    }
}
