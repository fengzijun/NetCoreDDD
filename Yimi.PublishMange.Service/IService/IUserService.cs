using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Domain;
using Yimi.PublishManage.Service.Model;
using static DingTalk.Api.Response.OapiUserListResponse;

namespace Yimi.PublishManage.Service.IService
{
    public interface IUserService
    {
        void EnableOrDisableUser(string userLogonName);
        void DeleteDomainUser(string userLogonName);

        void ResetDomainUserPwd(string userLogonName, string pwd);
        List<AdUser> GetDomainUsers();
        void AddDomainUser(string userLogonName);
        IPagedList<User> GetUsers(string name = "", int pageIndex = 0, int pageSize = int.MaxValue);

        User AddUser(User user);

        void DeleteUser(string userid);

        void UpdateUser(User user);

        IPagedList<SqlPublishOrder> GetUserOrders(string userid, int pageIndex = 0, int pageSize = int.MaxValue);

        IPagedList<SqlPublishOrderApproval> GetUserAuditOrders(string userid, int pageIndex = 0, int pageSize = int.MaxValue);

        List<Permission> GetUserPermissions(string userid);

        void UpdateUserPermissions(string userid, List<Permission> permissions);

        User GetUserById(string userid);

        User GetUserByName(string name, string exclueduserid = "");

        void UpdateUserLastIpAddress(User user);

        List<UserlistDomain> GetDingDingUserList();


    }
}
