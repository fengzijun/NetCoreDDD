﻿using Microsoft.AspNetCore.Mvc;

namespace Yimi.PublishManage.Framework.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string LogOn(this IUrlHelper urlHelper, string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl))
                return urlHelper.Action("Login", "Customer", new { ReturnUrl = returnUrl });
            return urlHelper.Action("Login", "Customer");
        }

        public static string LogOff(this IUrlHelper urlHelper, string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl))
                return urlHelper.Action("Logout", "Customer", new { ReturnUrl = returnUrl });
            return urlHelper.Action("Logout", "Customer");
        }
    }
}