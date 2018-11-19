using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yimi.PublishManage.Framework.Controllers;
using Yimi.PublishManage.Service.IService;
using Yimi.PublishManage.Framework.UI.Paging;
using Yimi.PublishManage.Web.Extensions;
using Yimi.PublishManage.Web.Model.Response;
using Yimi.PublishManage.Core;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yimi.PublishManage.Web.Controllers
{
    public class SqlPublishController : BasePublicController
    {
        private ISqlPublishService _sqlPublishService;
        private IWorkContext _workContext;
        public SqlPublishController(ISqlPublishService sqlPublishService, IWorkContext workContext)
        {
            _sqlPublishService = sqlPublishService;
            _workContext = workContext;
        }

        // GET: /<controller>/
        public IActionResult Index(int pageindex = 0, int pagesize = 20)
        {
            var providers = _sqlPublishService.GetYimiSqlProviders(null);
            ViewBag.Providers = providers;

            var models = _sqlPublishService.GetSQLPublishOrders(_workContext.CurrentUser.Id, null, pageindex, pagesize);
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex, Url = RouteData.GetUrl() };
            return View(models);
        }

        public IActionResult Create()
        {
            var providers = _sqlPublishService.GetYimiSqlProviders(null);
            ViewBag.Providers = providers;

            return View();
        }

        public IActionResult Edit(string id)
        {
            var providers = _sqlPublishService.GetYimiSqlProviders(null);
            ViewBag.Providers = providers;

            var model = _sqlPublishService.GetSQLPublishOrder(id);

            return View(model);
        }

        public IActionResult AuditIndex(int pageindex = 0, int pagesize = 20)
        {
            var providers = _sqlPublishService.GetYimiSqlProviders(null);
            ViewBag.Providers = providers;

            var models = _sqlPublishService.GetSQLPublishOrders("", Core.Domain.SqlPublishOrderApprovalStatues.Audit, pageindex, pagesize);
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex, Url = RouteData.GetUrl() };
            return View(models);
        }


        [HttpPost]
        public JsonResult Create([FromBody] Yimi.PublishManage.Core.Domain.SqlPublishOrder sqlPublishOrder)
        {
            sqlPublishOrder.Createtime = DateTime.Now;
            sqlPublishOrder.Updatetime = DateTime.Now;
            sqlPublishOrder.Publishtime = DateTime.Now;
            sqlPublishOrder.IsPublished = false;
            sqlPublishOrder.IsRunning = false;
            sqlPublishOrder.Result = "";
            sqlPublishOrder.YimiSqlProvider = _sqlPublishService.GetYimiSqlProvider(sqlPublishOrder.SqlProviderId);
            sqlPublishOrder.Approvalstatues = Core.Domain.SqlPublishOrderApprovalStatues.None;
            sqlPublishOrder.UserId = _workContext.CurrentUser.Id;
            _sqlPublishService.AddSQLPublishOrder(sqlPublishOrder);

            return Json(new SqlPublishCreateResponse { IsSuccess = true });
        }

        [HttpPost]
        public JsonResult Edit([FromBody] Yimi.PublishManage.Core.Domain.SqlPublishOrder sqlPublishOrder)
        {
            var orginmodel = _sqlPublishService.GetSQLPublishOrder(sqlPublishOrder.Id);
            sqlPublishOrder.Deleted = orginmodel.Deleted;
            sqlPublishOrder.Createtime = orginmodel.Createtime;
            sqlPublishOrder.Updatetime = DateTime.Now;
            sqlPublishOrder.Publishtime = orginmodel.Publishtime;
            sqlPublishOrder.UserId = orginmodel.UserId;
            sqlPublishOrder.YimiSqlProvider = _sqlPublishService.GetYimiSqlProvider(sqlPublishOrder.SqlProviderId);
            sqlPublishOrder.Approvalstatues = Core.Domain.SqlPublishOrderApprovalStatues.Audit;
            _sqlPublishService.UpdateSQLPublishOrder(sqlPublishOrder);

            return Json(new SqlPublishEditResponse { IsSuccess = true });
        }

        [HttpPost]
        public JsonResult UpdateStatues(string id,int statues)
        {
            var model = _sqlPublishService.GetSQLPublishOrder(id);
            model.Updatetime = DateTime.Now;
            model.Approvalstatues = (Core.Domain.SqlPublishOrderApprovalStatues)statues;
            _sqlPublishService.UpdateSQLPublishOrder(model);
            return Json(new SqlPublishEditResponse { IsSuccess = true });
        }

        public IActionResult Detail(string id)
        {
            var providers = _sqlPublishService.GetYimiSqlProviders(null);
            ViewBag.Providers = providers;
            var model = _sqlPublishService.GetSQLPublishOrder(id);
            return View(model);
        }

        public IActionResult ConnectionManage()
        {
            var models = _sqlPublishService.GetYimiSqlProviders(null);
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = 0, Url = RouteData.GetUrl() };
            return View(models);
        }

        public IActionResult ConnectionManageEdit(string id)
        {
            var model = _sqlPublishService.GetYimiSqlProvider(id);
            return View(model);
        }

        public IActionResult ConnectionManageCreate()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ConnectionManageEdit([FromBody] Yimi.PublishManage.Core.Domain.YimiSqlProvider yimiSqlProvider)
        {

            var orginmodel = _sqlPublishService.GetYimiSqlProvider(yimiSqlProvider.Id);
            yimiSqlProvider.Deleted = orginmodel.Deleted;
            yimiSqlProvider.Createtime = orginmodel.Createtime;
            yimiSqlProvider.Updatetime = DateTime.Now;

            _sqlPublishService.UpdateYimiSqlProvider(yimiSqlProvider);

            return Json(new ConnectionManageEditResponse { IsSuccess = true });
        }

        [HttpPost]
        public JsonResult ConnectionManageCreate([FromBody] Yimi.PublishManage.Core.Domain.YimiSqlProvider yimiSqlProvider)
        {

            yimiSqlProvider.Createtime = DateTime.Now;
            yimiSqlProvider.Updatetime = DateTime.Now;
            yimiSqlProvider.IsProd = yimiSqlProvider.Name.Contains("生产") ? true : false;

            _sqlPublishService.AddYimiSqlProvider(yimiSqlProvider);

            return Json(new  ConnectionManageCreate { IsSuccess = true });
        }

        [HttpPost]
        public JsonResult ConnectionManageDelete(string id)
        {
            var model = _sqlPublishService.GetYimiSqlProvider(id);
            model.Deleted = true;
            model.Updatetime = DateTime.Now;

            _sqlPublishService.UpdateYimiSqlProvider(model);

            return Json(new DeleteUserResponse { IsSuccess = true });
        }

        [HttpPost]
        public JsonResult Run(string id)
        {
            var result = _sqlPublishService.Run(id);
            if (result.Item1)
            {
                return Json(new RunResponse { IsSuccess = true });
            }
            else
            {
                return Json(new RunResponse { IsSuccess = false, Message = result.Item2 });
            }
        }


    }
}
