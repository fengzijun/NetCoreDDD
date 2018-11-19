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
    public class PermissionService : IPermissionService
    {
        #region Fields

        private readonly IRepository<Permission> _permissionRepository;
        private readonly IRepository<Role> _roleRepository;

        private readonly IDataProvider _dataProvider;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<User> _userRepository;


        #endregion

        public PermissionService(IRepository<Permission> permissionRepository, IRepository<Role> roleRepository, IRepository<User> userRepository, IDataProvider dataProvider, ICacheManager cacheManager, IEventPublisher eventPublisher)
        {
            _permissionRepository = permissionRepository;
            _dataProvider = dataProvider;
            _cacheManager = cacheManager;
            _eventPublisher = eventPublisher;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public List<Permission> GetPermissions(string roleid)
        {
            var query = _permissionRepository.Table;
            if (!string.IsNullOrEmpty(roleid))
            {
                var role = _roleRepository.Table.Where(s => s.Id == roleid).FirstOrDefault();
                return role.Permissions.ToList();
            }

            return query.ToList();
               

        }

        public bool HasPermission(string userid, string url)
        {
            var user = _userRepository.Table.Where(s => s.Id == userid).FirstOrDefault();
            if (user == null || user.Roles == null || user.Roles.Count == 0)
                return false;

            List<Permission> list = new List<Permission>();
            foreach(var role in user.Roles)
            {
                var roleinfo = _roleRepository.Table.Where(s => s.Id == role.Id).FirstOrDefault();
                list.AddRange(roleinfo.Permissions);
            }

            foreach(var item in list)
            {
                if(item.PermissionType == PermissionType.Menu && item.Menus.Any(s=>s.Url.ToLower() == url.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }


        public Permission AddPermission(Permission permission)
        {
            return _permissionRepository.Insert(permission);
        }

        public void UpdatePermisson(Permission permission)
        {
            if (permission == null)
                throw new ArgumentNullException("Permission");

            _permissionRepository.Update(permission);

            //event notification
            _eventPublisher.EntityUpdated(permission);
        }

        public void DeletePermission(string permissionid)
        {
            var permission = _permissionRepository.Table.Where(s => s.Id == permissionid).FirstOrDefault();
            if (permission == null)
                throw new ArgumentNullException("can not find permission");

            _permissionRepository.Delete(permission);
        }

        public Permission GetPermission(string permissionid)
        {
            return _permissionRepository.Table.Where(s => s.Id == permissionid).FirstOrDefault();
        }

        public void AddOrUpdateRolePermission(string roleid , string permissionid)
        {
            var roleinfo = _roleRepository.Table.Where(s => s.Id == roleid).FirstOrDefault();
            roleinfo.Permissions.Clear();
            var permissioninfo = _permissionRepository.Table.Where(s => s.Id == permissionid).FirstOrDefault();
            roleinfo.Permissions.Add(permissioninfo);
            _roleRepository.Update(roleinfo);
        }

        public Role GetRole(string roleid)
        {
            return _roleRepository.Table.FirstOrDefault(s => s.Id == roleid);
        }

        public List<Role> GetRoles()
        {
            return _roleRepository.Table.ToList();
        }
    }
}
