using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Data;
using Yimi.PublishManage.Service.IService;

namespace Yimi.PublishManage.Framework.Mvc.Filters
{
    /// <summary>
    /// Represents filter attribute that saves last customer activity date
    /// </summary>
    public class SaveLastActivityAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// Create instance of the filter attribute
        /// </summary>
        public SaveLastActivityAttribute() : base(typeof(SaveLastActivityFilter))
        {
        }

        #region Nested filter

        /// <summary>
        /// Represents a filter that saves last customer activity date
        /// </summary>
        private class SaveLastActivityFilter : IActionFilter
        {
            #region Fields

            private readonly IUserService _customerService;
            private readonly IWorkContext _workContext;

            #endregion

            #region Ctor

            public SaveLastActivityFilter(IUserService customerService,
                IWorkContext workContext)
            {
                this._customerService = customerService;
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

                //update last activity date
                //if (_workContext.CurrentCustomer.LastActivityDateUtc.AddMinutes(1.0) < DateTime.UtcNow)
                //{
                //    _workContext.CurrentCustomer.LastActivityDateUtc = DateTime.UtcNow;
                //    _customerService.UpdateCustomerLastActivityDate(_workContext.CurrentCustomer);
                //}
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