using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yimi.PublishManage.Framework.Controllers;
using Yimi.PublishManage.Web.Model.Response;
using Yimi.PublishManage.Service.IService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yimi.PublishManage.Web.Controllers
{
    public class PermissionController : BasePublicController
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult AddOrUpdate(string roleid , string permissionid)
        {
            _permissionService.AddOrUpdateRolePermission(roleid, permissionid);
            return Json(new PermissionAddOrUpdateResponse { IsSuccess = true });
        }
        
        [HttpPost]
        public JsonResult GetPermissions(string roleid)
        {
            var perssioms = _permissionService.GetPermissions(roleid);
            return new JsonResult(new GetPermissionsResponse { IsSuccess = true, Data = perssioms });
        }


    }
}
