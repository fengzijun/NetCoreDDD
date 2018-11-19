using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core.Caching;
using Yimi.PublishManage.Core.Data;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Domain;
using Yimi.PublishManage.Service.IService;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using System.Linq;
using Yimi.PublishManage.Services.Events;

namespace Yimi.PublishManage.Service
{
    public class MenuService : IMenuService
    {

        #region Fields

        private readonly IRepository<Menu> _menuRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IDataProvider _dataProvider;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<Permission> _permissionRepository;

        #endregion

        public MenuService(IRepository<Menu> menuRepository, IRepository<User> userRepository,IRepository<Permission> permissionRepository, IRepository<Role> roleRepository, IDataProvider dataProvider, ICacheManager cacheManager, IEventPublisher eventPublisher)
        {
            _menuRepository = menuRepository;
            _dataProvider = dataProvider;
            _cacheManager = cacheManager;
            _eventPublisher = eventPublisher;
            _userRepository = userRepository;
            _permissionRepository = permissionRepository;
            _roleRepository = roleRepository;
        }

        public List<Menu> GetMenus(string userid)
        {
            if (string.IsNullOrEmpty(userid))
            {
                var rootlist = _menuRepository.Table.Where(s => s.Deleted == false && string.IsNullOrEmpty(s.ParentId)).ToList();
                foreach (var root in rootlist)
                {
                    var childs = _menuRepository.Table.Where(s => s.Deleted == false && s.ParentId == root.Id).ToList();
                    root.ChildMenus = childs;

                }

                return rootlist;
            }
            else
            {
                var user = _userRepository.Table.Where(s => s.Id == userid).FirstOrDefault();
                //List<Permission> list = new List<Permission>();
                List<Menu> menus = new List<Menu>();
                foreach (var role in user.Roles)
                {
                    var roleentity = _roleRepository.Table.Where(s => s.Id == role.Id).FirstOrDefault();
                    if (roleentity == null || roleentity.Permissions == null || roleentity.Permissions.Count == 0)
                        continue;

                    foreach(var permission in roleentity.Permissions)
                    {
                        var pentity = _permissionRepository.Table.Where(s => s.Id == permission.Id).FirstOrDefault();
                        if(pentity!=null && pentity.Menus!=null && pentity.Menus.Count > 0)
                        {
                            menus.AddRange(pentity.Menus);
                        }
                    }

                   
                    //list.AddRange(roleentity.Permissions);menus
                    
                }

                return menus.Distinct().ToList();



            }
           

        }

        public Menu AddMenu(Menu menu)
        {
            return _menuRepository.Insert(menu);
        }

        public void UpdateMenu(Menu menu)
        {
            if (menu == null)
                throw new ArgumentNullException("Menu");

            _menuRepository.Update(menu);

            //event notification
            _eventPublisher.EntityUpdated(menu);
        }

        public void DeleteMenu(string menuid)
        {
            var menu = _menuRepository.Table.Where(s => s.Id == menuid).FirstOrDefault();
            if(menu == null)
                throw new ArgumentNullException("can not find menu");

            _menuRepository.Delete(menu);
        }

        public Menu GetMenu(string menuid)
        {
            return _menuRepository.Table.Where(s => s.Id == menuid).FirstOrDefault(); 
        }


    }
}
