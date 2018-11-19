using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Domain;

namespace Yimi.PublishManage.Service.IService
{
    public interface IPermissionService
    {
        List<Permission> GetPermissions(string roleid);

        Permission AddPermission(Permission permission);

        void UpdatePermisson(Permission permission);

        void DeletePermission(string permissionid);

        Permission GetPermission(string permissionid);

        bool HasPermission(string userid, string url);

        void AddOrUpdateRolePermission(string roleid, string permissionid);

        Role GetRole(string roleid);

        List<Role> GetRoles();

    }
}
