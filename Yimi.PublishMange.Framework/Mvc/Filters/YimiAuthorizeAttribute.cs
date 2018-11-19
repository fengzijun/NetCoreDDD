using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Infrastructure;

namespace Yimi.PublishManage.Framework.Mvc.Filters
{
   
    public class YimiAuthorizeAttribute : TypeFilterAttribute
    {
        private readonly bool _ignoreFilter;

        /// <summary>
        /// Create instance of the filter attribute
        /// </summary>
        /// <param name="ignore">Whether to ignore the execution of filter actions</param>
        public YimiAuthorizeAttribute(bool ignore = false) : base(typeof(YimiAuthorizeFilter))
        {
            this._ignoreFilter = ignore;
            this.Arguments = new object[] { ignore };
        }

        public bool IgnoreFilter => _ignoreFilter;


        public class YimiAuthorizeFilter : IAuthorizationFilter
        {
            private readonly IWorkContext _workContext;
            private readonly bool _ignoreFilter;
            public YimiAuthorizeFilter(bool ignoreFilter)
            {
                _workContext = EngineContext.Current.Resolve<IWorkContext>();
                this._ignoreFilter = ignoreFilter;
            }

            public void OnAuthorization(AuthorizationFilterContext filterContext)
            {

                if (filterContext == null)
                    throw new ArgumentNullException("filterContext");

                //check whether this filter has been overridden for the action
                if (filterContext.Filters.Any(filter => filter is YimiAuthorizeFilter))
                {
                    if (_workContext.CurrentUser == null)
                    {
                        //var changePasswordUrl = new UrlHelper(filterContext).RouteUrl("login");
                        filterContext.Result = new RedirectToActionResult("login", "account", null); //new RedirectResult("http://localhost:50911/account/login");
                        
                    }
                }
                   
            }
        }


    }
}
