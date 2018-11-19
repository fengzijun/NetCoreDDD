#pragma checksum "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Themes\DefaultClean\Views\Shared\Head.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7bb2553c31790bf8ede905f2bfee291719699dc9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Themes_DefaultClean_Views_Shared_Head), @"mvc.1.0.view", @"/Themes/DefaultClean/Views/Shared/Head.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Themes/DefaultClean/Views/Shared/Head.cshtml", typeof(AspNetCore.Themes_DefaultClean_Views_Shared_Head))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Themes\DefaultClean\Views\Shared\Head.cshtml"
using Yimi.PublishManage.Core;

#line default
#line hidden
#line 2 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Themes\DefaultClean\Views\Shared\Head.cshtml"
using Yimi.PublishManage.Framework.Themes;

#line default
#line hidden
#line 3 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Themes\DefaultClean\Views\Shared\Head.cshtml"
using Yimi.PublishManage.Framework.UI;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7bb2553c31790bf8ede905f2bfee291719699dc9", @"/Themes/DefaultClean/Views/Shared/Head.cshtml")]
    public class Themes_DefaultClean_Views_Shared_Head : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(181, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 7 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Themes\DefaultClean\Views\Shared\Head.cshtml"
  

    var themeName = themeContext.WorkingThemeName;

    //add browser specific CSS files
    //if (supportRtl)
    //{
    //    Html.AppendCssFileParts(string.Format("~/Themes/{0}/Content/css/style.rtl.css", themeName));
    //}

    Html.AppendCssFileParts(string.Format("~/Themes/{0}/Content/css/style.css", themeName));
    Html.AppendCssFileParts(string.Format("~/Themes/{0}/Content/css/fontawesome-all.min.css", themeName));
    Html.AppendCssFileParts("~/Content/bootstrap/bootstrap.min.css");
    Html.AppendScriptParts("~/Content/bootstrap/bootstrap.min.js");
    Html.AppendScriptParts("~/Content/bootstrap/popper.min.js");
    Html.AppendScriptParts("~/Scripts/public.ajaxcart.js");
    Html.AppendScriptParts("~/Scripts/jquery.countdown.min.js");
    Html.AppendScriptParts("~/Scripts/public.common.js");
    Html.AppendCssFileParts("~/Content/smoothproducts/smoothproducts.css");
    Html.AppendScriptParts("~/Scripts/smoothproducts.min.js");
    Html.AppendScriptParts("~/Scripts/jquery-migrate-1.2.1.min.js");
    Html.AppendScriptParts("~/Scripts/jquery-ui-1.10.3.custom.min.js");
    Html.AppendScriptParts("~/Scripts/jquery.validate.unobtrusive.min.js");
    Html.AppendScriptParts("~/Scripts/jquery.validate.min.js");
    Html.AppendScriptParts("~/Scripts/jquery-1.10.2.min.js");


#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IThemeContext themeContext { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IWorkContext workContext { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
