using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Microsoft.AspNetCore.Authentication;
using System;
using Yimi.PublishManage.Service;

namespace Yimi.PublishManage.Framework.Mvc.Filters
{
    /// <summary>
    /// Represents filter attribute that sign out from the external authentication scheme
    /// </summary>
    public class SignOutFromExternalAuthenticationAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// Create instance of the filter attribute
        /// </summary>
        public SignOutFromExternalAuthenticationAttribute() : base(typeof(SignOutFromExternalAuthenticationFilter))
        {
        }

        #region Nested filter

        /// <summary>
        /// Represents a filter that sign out from the external authentication scheme
        /// </summary>
        private class SignOutFromExternalAuthenticationFilter : IAuthorizationFilter
        {
            #region Methods

            /// <summary>
            /// Called early in the filter pipeline to confirm request is authorized
            /// </summary>
            /// <param name="filterContext">Authorization filter context</param>
            public async void OnAuthorization(AuthorizationFilterContext filterContext)
            {
                if (filterContext == null)
                    throw new ArgumentNullException(nameof(filterContext));

                //sign out from the external authentication scheme
                var authenticateResult = await filterContext.HttpContext.AuthenticateAsync(YimiCookieAuthenticationDefaults.ExternalAuthenticationScheme);
                if (authenticateResult.Succeeded)
                    await filterContext.HttpContext.SignOutAsync(YimiCookieAuthenticationDefaults.ExternalAuthenticationScheme);
            }

            #endregion
        }

        #endregion
    }
}