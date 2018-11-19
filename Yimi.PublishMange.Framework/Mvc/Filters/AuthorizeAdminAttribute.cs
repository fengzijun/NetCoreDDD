using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Yimi.PublishManage.Core.Data;
using Yimi.PublishManage.Service.IService;
using Yimi.PublishManage.Core;

namespace Yimi.PublishManage.Framework.Mvc.Filters
{
    /// <summary>
    /// Represents a filter attribute that confirms access to the admin panel
    /// </summary>
    public class AuthorizeAdminAttribute : TypeFilterAttribute
    {
        private readonly bool _ignoreFilter;

        /// <summary>
        /// Create instance of the filter attribute
        /// </summary>
        /// <param name="ignore">Whether to ignore the execution of filter actions</param>
        public AuthorizeAdminAttribute(bool ignore = false) : base(typeof(AuthorizeAdminFilter))
        {
            this._ignoreFilter = ignore;
            this.Arguments = new object[] { ignore };
        }

        public bool IgnoreFilter => _ignoreFilter;

        #region Nested filter

        /// <summary>
        /// Represents a filter that confirms access to the admin panel
        /// </summary>
        private class AuthorizeAdminFilter : IAuthorizationFilter
        {
            #region Fields

            private readonly bool _ignoreFilter;
            private readonly IPermissionService _permissionService;
            private readonly IWorkContext _workContext;

            #endregion

            #region Ctor

            public AuthorizeAdminFilter(bool ignoreFilter, IPermissionService permissionService, IWorkContext workContext)
            {
                this._ignoreFilter = ignoreFilter;
                this._permissionService = permissionService;
                _workContext = workContext;
            }

            #endregion

            #region Methods

            /// <summary>
            /// Called early in the filter pipeline to confirm request is authorized
            /// </summary>
            /// <param name="filterContext">Authorization filter context</param>
            public void OnAuthorization(AuthorizationFilterContext filterContext)
            {
                
                if (filterContext == null)
                    throw new ArgumentNullException("filterContext");

                //check whether this filter has been overridden for the action
                var actionFilter = filterContext.ActionDescriptor.FilterDescriptors
                    .Where(f => f.Scope == FilterScope.Action)
                    .Select(f => f.Filter).OfType<AuthorizeAdminAttribute>().FirstOrDefault();

                //ignore filter (the action is available even if a customer hasn't access to the admin area)
                if (actionFilter?.IgnoreFilter ?? _ignoreFilter)
                    return;

                if (!DataSettingsHelper.DatabaseIsInstalled())
                    return;
                string controller = string.Empty;
                string action = string.Empty;
    
                if (filterContext.RouteData.Values["action"]!=null)
                {
                    action = filterContext.RouteData.Values["action"].ToString();
                }

                if (filterContext.RouteData.Values["controller"] != null)
                {
                    controller = filterContext.RouteData.Values["controller"].ToString();
                }

                if (string.IsNullOrEmpty(action) || string.IsNullOrEmpty(controller))
                    return;

                string url = $"{controller}/{action}";

                //there is AdminAuthorizeFilter, so check access
                if (filterContext.Filters.Any(filter => filter is AuthorizeAdminFilter))
                {
                    //authorize permission of access to the admin area
                    if (!_permissionService.HasPermission(_workContext.CurrentUser.Id,url))
                        filterContext.Result = new ChallengeResult();
                }
            }

            #endregion
        }

        #endregion
    }
}