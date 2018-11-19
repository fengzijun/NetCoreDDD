using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Data;
using Microsoft.AspNetCore.Http;
using Yimi.PublishManage.Service.IService;

namespace Yimi.PublishManage.Framework.Mvc.Filters
{
    /// <summary>
    /// Represents filter attribute that saves last IP address of customer
    /// </summary>
    public class SaveIpAddressAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// Create instance of the filter attribute
        /// </summary>
        public SaveIpAddressAttribute() : base(typeof(SaveIpAddressFilter))
        {
        }

        #region Nested filter

        /// <summary>
        /// Represents a filter that saves last IP address of customer
        /// </summary>
        private class SaveIpAddressFilter : IActionFilter
        {
            #region Fields

            private readonly IUserService _customerService;
            private readonly IWebHelper _webHelper;
            private readonly IWorkContext _workContext;

            #endregion

            #region Ctor

            public SaveIpAddressFilter(IUserService customerService,
                IWebHelper webHelper,
                IWorkContext workContext)
            {
                this._customerService = customerService;
                this._webHelper = webHelper;
                this._workContext = workContext;
            }

            #endregion

            #region Methods

            /// <summary>
            /// Called before the action executes, after model binding is complete
            /// </summary>
            /// <param name="context">A context for action filters</param>
            public void OnActionExecuting(ActionExecutingContext context)
            {
                if (context == null || context.HttpContext == null || context.HttpContext.Request == null)
                    return;

                if (!DataSettingsHelper.DatabaseIsInstalled())
                    return;

                //only in GET requests
                if (!HttpMethods.IsGet(context.HttpContext.Request.Method))
                    return;

                //get current IP address
                var currentIpAddress = _webHelper.GetCurrentIpAddress();
                if (string.IsNullOrEmpty(currentIpAddress))
                    return;
                
                //update customer's IP address
                if (!currentIpAddress.Equals(_workContext.CurrentUser.LastLoginIp, StringComparison.OrdinalIgnoreCase))
                {
                    _workContext.CurrentUser.LastLoginIp = currentIpAddress;
                    _customerService.UpdateUserLastIpAddress(_workContext.CurrentUser);
                }
            }

            /// <summary>
            /// Called after the action executes, before the action result
            /// </summary>
            /// <param name="context">A context for action filters</param>
            public void OnActionExecuted(ActionExecutedContext context)
            {
                //do nothing
            }

            #endregion
        }

        #endregion
    }
}