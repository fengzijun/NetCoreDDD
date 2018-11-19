using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yimi.PublishManage.Framework.Controllers;
using Yimi.PublishManage.Service.IService;
using Yimi.PublishManage.Core;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yimi.PublishManage.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService _userService;
        private readonly IYimiAuthenticationService _yimiAuthenticationService;
        private readonly IWorkContext _workContext;

        public AccountController(IUserService userService, IYimiAuthenticationService yimiAuthenticationService, IWorkContext workContext)
        {
            _userService = userService;
            _yimiAuthenticationService = yimiAuthenticationService;
            _workContext = workContext;
        }
        // GET: /<controller>/
        
        public IActionResult Login()
        {
            if(_workContext.CurrentUser!=null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public IActionResult Login(Yimi.PublishManage.Web.Model.LoginModel loginModel)
        {
            var model = _userService.GetUserByName(loginModel.Username);
            if (model == null)
                return View();

            if (model.Password == loginModel.Password)
            {
                _yimiAuthenticationService.SignIn(model, true);
                return RedirectToAction("Index", "Home");
            }
               
            else
                return View();
        }


        public virtual IActionResult Logout()
        {
            //external authentication



            //standard logout 
            _yimiAuthenticationService.SignOut();

            //EU Cookie

            return RedirectToAction("Login", "Account");
        }
    }
}
