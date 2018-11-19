﻿using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading.Tasks;

namespace Yimi.PublishManage.Framework.Mvc.Routing
{
    /// <summary>
    /// Represents custom overridden redirect result executor
    /// </summary>
    public class YimiRedirectResultExecutor : RedirectResultExecutor
    {
        #region Fields

        //private readonly SecuritySettings _securitySettings;

        #endregion

        #region Ctor

        public YimiRedirectResultExecutor(ILoggerFactory loggerFactory,
            IUrlHelperFactory urlHelperFactory) : base(loggerFactory, urlHelperFactory)
        {
            //this._securitySettings = securitySettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Execute passed redirect result
        /// </summary>
        /// <param name="context">Action context</param>
        /// <param name="result">Redirect result</param>
        public override Task ExecuteAsync(ActionContext context, RedirectResult result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            //if (_securitySettings.AllowNonAsciiCharInHeaders)
            //{
            //    //passed redirect URL may contain non-ASCII characters, that are not allowed now (see https://github.com/aspnet/KestrelHttpServer/issues/1144)
            //    //so we force to encode this URL before processing
            //    result.Url = Uri.EscapeUriString(WebUtility.UrlDecode(result.Url));
            //}

            result.Url = Uri.EscapeUriString(WebUtility.UrlDecode(result.Url));

            return base.ExecuteAsync(context, result);
        }

        #endregion
    }
}
