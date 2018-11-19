using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yimi.PublishManage.Core.Domain;
using Yimi.PublishManage.Web.Model;

namespace Yimi.PublishManage.Web.Mapper
{
    public static class MapperExtension
    {
        public static PermissionDto ToModel(this Permission permission)
        {
            return new PermissionDto { PermissionId = permission.Id, PermissionName = permission.Name };
        }

        public static List<PermissionDto> ToModels(this IEnumerable<Permission> permissions)
        {
            if (permissions == null)
                return null;

            List<PermissionDto> result = new List<PermissionDto>();
            foreach(var item in permissions)
            {
                result.Add(item.ToModel());
            }
            return result;
        }



        public static MenuDto ToModel(this Menu menu )
        {
            return new MenuDto { Id = menu.Id, Name = menu.Name, ParentId = menu.ParentId, Url = menu.Url  };
        }

        public static List<MenuDto> ToModels(this IEnumerable<Menu> menus)
        {
            if (menus == null)
                return null;

            List<MenuDto> result = new List<MenuDto>();
            foreach (var item in menus)
            {
                result.Add(item.ToModel());
            }
            return result;
        }



        public static RoleDto ToModel(this Role role)
        {
            return new RoleDto { Id = role.Id, Name = role.Name, Permissions = role.Permissions.ToModels() };
        }

        public static List<RoleDto> ToModels(this IEnumerable<Role> roles)
        {
            if (roles == null)
                return null;

            List<RoleDto> result = new List<RoleDto>();
            foreach (var item in roles)
            {
                result.Add(item.ToModel());
            }
            return result;
        }


        public static UserDto ToModel(this User user)
        {
            return new UserDto { Email = user.Email, Mobile = user.Mobile, Name = user.Name, UserId = user.Id , Password = user.Password  };
        }

        public static User ToModel(this UserDto user)
        {
            return new User { Email = user.Email, Mobile = user.Mobile, Name = user.Name,  Password = user.Password };
        }

        public static List<UserDto> ToModels(this IEnumerable<User> users)
        {
            if (users == null)
                return null;

            List<UserDto> result = new List<UserDto>();
            foreach (var item in users)
            {
                result.Add(item.ToModel());
            }
            return result;
        }



    }
}
