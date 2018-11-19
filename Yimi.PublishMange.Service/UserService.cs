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
using DingTalk.Api.Request;
using static DingTalk.Api.Response.OapiUserListResponse;
using DingTalk.Api;
using Yimi.PublishManage.Service.Model;
using Yimi.PublishManage.Core.Helper;
using DingTalk.Api.Response;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace Yimi.PublishManage.Service
{
    public partial class UserService : IUserService
    {
        #region Fields

        private readonly IRepository<Permission> _permissionRepository;
        private readonly IRepository<SqlPublishOrder> _sqlpublishorderRepository;
        private readonly IRepository<SqlPublishOrderApproval> _sqlpublishorderapprovalRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IDataProvider _dataProvider;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly string _domain = "https://oapi.dingtalk.com";
        private readonly string _dingOrgYimiRootId = "47902482";
        private readonly string _dingCorpId = "ding451a1102a04e6cf0";
        private readonly string _dingCorpSecret = "Vm-KpU91_scFY20wRvXXhhsFi_-vZiX7DdVGJhJHJVVRbm0CF_QfSiNAbpZTsO5D";

        #endregion

        public UserService(IRepository<User> userRepository,IRepository<Permission> permissionRepository, IRepository<Role> roleRepository, IRepository<SqlPublishOrder> sqlpublishorderRepository, IRepository<SqlPublishOrderApproval> sqlpublishorderapprovalRepository, IDataProvider dataProvider, ICacheManager cacheManager, IEventPublisher eventPublisher)
        {
            _permissionRepository = permissionRepository;
            _dataProvider = dataProvider;
            _cacheManager = cacheManager;
            _eventPublisher = eventPublisher;
            _roleRepository = roleRepository;
            _sqlpublishorderRepository = sqlpublishorderRepository;
            _sqlpublishorderapprovalRepository = sqlpublishorderapprovalRepository;
            _userRepository = userRepository;
        }

        public IPagedList<User> GetUsers(string name = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _userRepository.Table;
            if (!string.IsNullOrEmpty(name))
                query = query.Where(s => s.Name == name);

            query = query.Where(s => s.Deleted == false);

            return new PagedList<User>(query, pageIndex, pageSize);
        }

        public User GetUserById(string userid)
        {
            return _userRepository.Table.FirstOrDefault(s => s.Id == userid);
        }

        public User GetUserByName(string name, string exclueduserid = "")
        {
            if(!string.IsNullOrEmpty(exclueduserid))
                return _userRepository.Table.FirstOrDefault(s => s.Name == name && s.Deleted == false && s.Id !=exclueduserid);
            return _userRepository.Table.FirstOrDefault(s => s.Name == name && s.Deleted == false);
        }

        public User AddUser(User user)
        {
            user.Createtime = DateTime.Now;
            user.Updatetime = DateTime.Now;
            user.Deleted = false;
            user.Actived = true;

            return _userRepository.Insert(user);
        }

        public void DeleteUser(string userid)
        {
            var user = _userRepository.Table.Where(s => s.Id == userid).FirstOrDefault();
            if (user == null)
                throw new Exception("can not find user");

            _userRepository.Delete(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public IPagedList<SqlPublishOrder> GetUserOrders(string userid, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _sqlpublishorderRepository.Table;
            if (!string.IsNullOrEmpty(userid))
                query = query.Where(s => s.UserId == userid);

            query = query.Where(s => s.Deleted == false);

            return new PagedList<SqlPublishOrder>(query, pageIndex, pageSize);
        }

        public IPagedList<SqlPublishOrderApproval> GetUserAuditOrders(string userid, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _sqlpublishorderapprovalRepository.Table;
            if (!string.IsNullOrEmpty(userid))
                query = query.Where(s => s.LeaderId == userid);

            query = query.Where(s => s.Deleted == false);

            return new PagedList<SqlPublishOrderApproval>(query, pageIndex, pageSize);
        }

        public List<Permission> GetUserPermissions(string userid)
        {
            var user = _userRepository.Table.Where(s => s.Id == userid).FirstOrDefault();
            if (user == null || user.Roles == null || user.Roles.Count == 0)
                return null;

            List<Permission> list = new List<Permission>();
            foreach(var role in user.Roles)
            {
                var roleentity = _roleRepository.Table.Where(s => s.Id == role.Id).FirstOrDefault();
                if (roleentity == null || roleentity.Permissions == null || roleentity.Permissions.Count == 0)
                    continue;

                list.AddRange(roleentity.Permissions);
            }

            return list.Distinct().ToList();
        }

        public void UpdateUserPermissions(string userid, List<Permission> permissions)
        {
            throw new NotImplementedException();
        }


        public virtual void UpdateUserLastIpAddress(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var builder = Builders<User>.Filter;
            var filter = builder.Eq(x => x.Id, user.Id);
            var update = Builders<User>.Update
                .Set(x => x.LastLoginIp, user.LastLoginIp);
            var result = _userRepository.Collection.UpdateOneAsync(filter, update).Result;

        }


        public List<UserlistDomain> GetDingDingUserList()
        {
            var client = new DefaultDingTalkClient(_domain + "/department/list");
            var drequest = new OapiDepartmentListRequest
            {

                FetchChild = true,
                Id = _dingOrgYimiRootId
            };
            var accesstoken = GetAccessTokenAsync().AccessToken;
            drequest.SetHttpMethod("GET");
            var res = client.Execute(drequest, accesstoken);
            List<UserlistDomain> list = new List<UserlistDomain>();
            foreach (var department in res.Department)
            {
                OapiUserListRequest userListRequest = new OapiUserListRequest { DepartmentId = department.Id, Offset = 0, Size = 100};
                list.AddRange(PrepareDingdingUsers(userListRequest));
            }

            return list;
        }

        public List<AdUser> GetDomainUsers()
        {
            List<AdUser> users = new List<AdUser>();
            using (var context = new PrincipalContext(ContextType.Domain, "yimihaodi.net", "CN=Users,DC=yimihaodi,DC=net"))
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    var list = searcher.FindAll();

                    foreach (var result in list)
                    {
                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                        AdUser adUser = new AdUser { Username = result.SamAccountName, IsEnabled = true };
                        UserPrincipal userPrincipal = result as UserPrincipal;
                        if (userPrincipal != null)
                        {
                            adUser.IsEnabled = userPrincipal.Enabled.HasValue ? userPrincipal.Enabled.Value : true;
                        }
                        users.Add(adUser);
                    }

                    //Console.WriteLine($"count: {count}");
                }
            }

            return users;
        }

        public void AddDomainUser(string userLogonName)
        {
            PrincipalContext principalContext = null;

            principalContext = new PrincipalContext(ContextType.Domain, "yimihaodi.net", "CN=Users,DC=yimihaodi,DC=net");

          
            UserPrincipal usr = UserPrincipal.FindByIdentity(principalContext, userLogonName);
            if (usr != null)
            {
                return;
            }

            if (string.IsNullOrEmpty(userLogonName))
            {
                return;
            }

            // Create the new UserPrincipal object
            UserPrincipal userPrincipal = new UserPrincipal(principalContext);

            //userPrincipal.
            userPrincipal.SamAccountName = userLogonName;

            string password = "abcd@1234";
            userPrincipal.SetPassword(password);

            userPrincipal.Enabled = true;

            userPrincipal.PasswordNeverExpires = true;

            userPrincipal.Save();
        }

        public void DeleteDomainUser(string userLogonName)
        {
            PrincipalContext principalContext = null;

            principalContext = new PrincipalContext(ContextType.Domain, "yimihaodi.net", "CN=Users,DC=yimihaodi,DC=net");


            UserPrincipal usr = UserPrincipal.FindByIdentity(principalContext, userLogonName);
            if (usr == null)
            {
                return;
            }

            usr.Delete();

            usr.Save();
        }

        public void EnableOrDisableUser(string userLogonName)
        {

            PrincipalContext principalContext = null;

            principalContext = new PrincipalContext(ContextType.Domain, "yimihaodi.net", "CN=Users,DC=yimihaodi,DC=net");


            UserPrincipal usr = UserPrincipal.FindByIdentity(principalContext, userLogonName);
            if (usr == null)
            {
                return;
            }

            usr.Enabled = !usr.Enabled;
            usr.Save();
        }

        public void ResetDomainUserPwd(string userLogonName,string pwd)
        {
            PrincipalContext principalContext = null;

            principalContext = new PrincipalContext(ContextType.Domain, "yimihaodi.net", "CN=Users,DC=yimihaodi,DC=net");


            UserPrincipal usr = UserPrincipal.FindByIdentity(principalContext, userLogonName);
            if (usr == null)
            {
                return;
            }

            usr.SetPassword(pwd);

            usr.Save();
        }

        private List<UserlistDomain> PrepareDingdingUsers(OapiUserListRequest request)
        {
            var list = new List<UserlistDomain>();
            var client = new DefaultDingTalkClient(_domain + "/user/list");
          
            client.SetDisableParser(false);
            var accesstoken = GetAccessTokenAsync().AccessToken;
            request.SetHttpMethod("GET");

            var res = client.Execute(request, accesstoken);
            if (!res.IsError)
            {
                if (res.Userlist != null)
                {
                    list.AddRange(res.Userlist);
                }
                if (res.HasMore)
                {
                    request.Offset += request.Size;
                    list.AddRange(PrepareDingdingUsers(request));
                }
            }

            return list;
        }

        public OapiDepartmentListResponse GetDepartmentListAsync()
        {


            var client = new DefaultDingTalkClient(_domain + "/department/list");
            var request = new OapiDepartmentListRequest
            {

                FetchChild = true,
                Id = _dingOrgYimiRootId
            };
            var accesstoken = GetAccessTokenAsync().AccessToken;
            request.SetHttpMethod("Get");
            var res = client.Execute(request, accesstoken);

            return res;

        }

        public GetAccessTokenResponse GetAccessTokenAsync()
        {
            
            var req = new GeAccessTokenRequest
            {
                CorpId = _dingCorpId,
                CorpSecret = _dingCorpSecret
            };
            HttpWebUtils aliyunWebUtils = new HttpWebUtils();
            var res = aliyunWebUtils.DoGet<GetAccessTokenResponse>(_domain + "/gettoken", req.GetParameters()).Result;
            //if (res == null)
            //    return null;
            //if (res.IsSuccess)
            //{
            //    accessTokenCached = res;
            //    GetDingTalkCache().Set(CacheDingTalk_AccessToken, res, null, TimeSpan.FromSeconds(res.ExpiresIn - 10));
            //}
            return res;
        }

    }
}
