using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yimi.PublishManage.Service
{
    public class YimiCookieAuthenticationDefaults
    {
        /// <summary>
        /// The default value used for authentication scheme
        /// </summary>
        public const string AuthenticationScheme = "Authentication";

        /// <summary>
        /// The default value used for external authentication scheme
        /// </summary>
        public const string ExternalAuthenticationScheme = "ExternalAuthentication";

        /// <summary>
        /// The prefix used to provide a default cookie name
        /// </summary>
        public static readonly string CookiePrefix = ".Yimi.PublishManage.";

        /// <summary>
        /// The issuer that should be used for any claims that are created
        /// </summary>
        public static readonly string ClaimsIssuer = "Yiminode";

        /// <summary>
        /// The default value for the login path
        /// </summary>
        public static readonly PathString LoginPath = new PathString("/account/login");

        /// <summary>
        /// The default value used for the logout path
        /// </summary>
        public static readonly PathString LogoutPath = new PathString("/account//logout");

        /// <summary>
        /// The default value for the access denied path
        /// </summary>
        public static readonly PathString AccessDeniedPath = new PathString("/page-not-found");

        /// <summary>
        /// The default value of the return url parameter
        /// </summary>
        public static readonly string ReturnUrlParameter = "";
    }
}
