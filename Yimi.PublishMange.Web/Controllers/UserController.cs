using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yimi.PublishManage.Framework.Controllers;
using Yimi.PublishManage.Web.Model;
using Yimi.PublishManage.Web.Model.Response;
using Yimi.PublishManage.Core.Domain;
using Yimi.PublishManage.Service.IService;
using Yimi.PublishManage.Web.Mapper;
using Yimi.PublishManage.Framework.UI.Paging;
using Yimi.PublishManage.Web.Extensions;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yimi.PublishManage.Web.Controllers
{
    public class UserController : BasePublicController
    {

        public readonly IUserService _userService;
        public readonly IPermissionService _permissionService;

        public UserController(IUserService userService, IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }

        // GET: /<controller>/
        public IActionResult Index(int pageindex = 0, int pageisze = 20)
        {
            var users = _userService.GetUsers("", pageindex, pageisze);

            ViewBag.PageInfo = new PageModel { PageCount = users.TotalPages, PageIndex = pageindex, Url = RouteData.GetUrl()};
            return View(users);
        }

        public IActionResult Create()
        {
            ViewBag.Roles = _permissionService.GetRoles();
            return View();

        }

        [HttpPost]
        public JsonResult Create([FromBody] UserDto user)
        {
            var model = _userService.GetUserByName(user.Name);

            if (model != null)
            {
                return Json(new CreateUserResponse { IsSuccess = false, Message = "用户已存在" });
            }

            var usertemp = user.ToModel();

            var role = _permissionService.GetRole(user.RoleId);

            usertemp.Roles = new List<Role>();
            usertemp.Roles.Add(role);
            usertemp.Createtime = DateTime.Now;
            usertemp.Updatetime = DateTime.Now;
            usertemp.Actived = true;
            usertemp.LastLoginIp = null;

            _userService.AddUser(usertemp);

            return Json(new CreateUserResponse { IsSuccess = true });
        }

        public IActionResult Edit(string userid)
        {
            ViewBag.Roles = _permissionService.GetRoles();
            var user = _userService.GetUserById(userid);
            return View(user);

        }

        public IActionResult SynUsers()
        {
            var users = _userService.GetDomainUsers();

            return View(users);
        }

        [HttpPost]
        public JsonResult SysdingdingUsers()
        {
            string users = string.Empty;
            string errorusername = string.Empty;
            try
            {
                var dingdingusers = _userService.GetDingDingUserList();
                foreach (var user in dingdingusers)
                {
                    string email = user.Email ?? user.OrgEmail;
                    errorusername = email;
                    if (string.IsNullOrEmpty(email))
                        continue;
                    if(email.Contains("@"))
                    {
                        email = email.Substring(0, email.IndexOf("@")); 
                    }
          
                    _userService.AddDomainUser(email);
                }

                //if (users.Contains(","))
                //    users = users.Substring(0, users.Length - 1);

                //using (StreamWriter streamWriter = new StreamWriter(@"D:\\dingdingsynapp\\user.txt", false))
                //{
                //    streamWriter.WriteLine(users);
                //}

                //System.Diagnostics.Process si = new System.Diagnostics.Process();
                //si.StartInfo.WorkingDirectory = "c:\\";
                //si.StartInfo.UseShellExecute = false;
                //si.StartInfo.FileName = "cmd.exe";
                //si.StartInfo.Arguments = "dotnet D:\\dingdingsynapp\\publishYimi.PublishManage.ConsoleTest.dll";
                //si.StartInfo.CreateNoWindow = false;
                //si.StartInfo.RedirectStandardInput = true;
                //si.StartInfo.RedirectStandardOutput = true;
                //si.StartInfo.RedirectStandardError = true;

                //si.Start();
                //string output = si.StandardOutput.ReadToEnd();
                //si.Close();

                return Json(new CreateUserResponse { IsSuccess = true });
            }
            catch(Exception ex)
            {
                return Json(new CreateUserResponse { IsSuccess = false, Message = ex.Message  });
            }
        }

        [HttpGet]
        public IActionResult DeleteDomainUser(string username)
        {
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("SynUsers");

            _userService.EnableOrDisableUser(username);

            return RedirectToAction("SynUsers");

        }

      
        public IActionResult ResetUserPasword(string username)
        {
            DomainUser domainUser = new DomainUser { Username = username };

            return View(domainUser);
        }

        [HttpPost]
        public IActionResult ResetUserPasword(DomainUser domainUser)
        {
            if (string.IsNullOrEmpty(domainUser.Username) || string.IsNullOrEmpty(domainUser.Password))
                return View();

            _userService.ResetDomainUserPwd(domainUser.Username, domainUser.Password);

            return RedirectToAction("SynUsers");
        }

        [HttpPost]
        public JsonResult Edit([FromBody] UserDto user)
        {
            var usertemp = _userService.GetUserByName(user.Name,user.UserId);

            if (usertemp != null)
            {
                return Json(new CreateUserResponse { IsSuccess = false, Message = "用户已存在" });
            }

            usertemp = user.ToModel();
            usertemp.Id = user.UserId;
            var role = _permissionService.GetRole(user.RoleId);

            usertemp.Roles = new List<Role>();
            usertemp.Roles.Add(role);

            _userService.UpdateUser(usertemp);

            return Json(new CreateUserResponse { IsSuccess = true });
        }

        public IActionResult Profile(string userid)
        {
            var user = _userService.GetUserById(userid);
            return View(user);
        }

        [HttpPost]
        public JsonResult Delete(string userid)
        {

            var user = _userService.GetUserById(userid);
            user.Deleted = true;
            user.Updatetime = DateTime.Now;

            _userService.UpdateUser(user);

            return Json(new DeleteUserResponse { IsSuccess = true });
        }

    }
}
