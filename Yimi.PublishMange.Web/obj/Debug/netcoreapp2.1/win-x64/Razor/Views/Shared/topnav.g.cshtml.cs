#pragma checksum "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\topnav.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c06090156ba5ebf4adc59b542773b0e0ee6ff5bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_topnav), @"mvc.1.0.view", @"/Views/Shared/topnav.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/topnav.cshtml", typeof(AspNetCore.Views_Shared_topnav))]
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
#line 1 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\_ViewImports.cshtml"
using Yimi.PublishManage.Web;

#line default
#line hidden
#line 2 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\_ViewImports.cshtml"
using Yimi.PublishManage.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c06090156ba5ebf4adc59b542773b0e0ee6ff5bd", @"/Views/Shared/topnav.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55eb66a85096509c7ddca9d37ded023fb10c11b8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_topnav : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/bower_components/gentelella/production/images/img.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(59, 430, true);
            WriteLiteral(@"<div class=""top_nav"">
    <div class=""nav_menu"">
        <nav>
            <div class=""nav toggle"">
                <a id=""menu_toggle""><i class=""fa fa-bars""></i></a>
            </div>

            <ul class=""nav navbar-nav navbar-right"">
                <li class="""">
                    <a href=""javascript:;"" class=""user-profile dropdown-toggle"" data-toggle=""dropdown"" aria-expanded=""false"">
                        ");
            EndContext();
            BeginContext(489, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2d2f43a8233a4d5ba0cb3892687ad9d9", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(564, 29, false);
#line 12 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\topnav.cshtml"
                                                                                             Write(_workContext.CurrentUser.Name);

#line default
#line hidden
            EndContext();
            BeginContext(593, 757, true);
            WriteLiteral(@"
                        <span class="" fa fa-angle-down""></span>
                    </a>
                    <ul class=""dropdown-menu dropdown-usermenu pull-right"">
                        <li><a href=""javascript:;""> Profile</a></li>
                        <li>
                            <a href=""javascript:;"">
                                <span class=""badge bg-red pull-right"">50%</span>
                                <span>Settings</span>
                            </a>
                        </li>
                        <li><a href=""javascript:;"">Help</a></li>
                        <li><a href=""/account/Logout""><i class=""fa fa-sign-out pull-right""></i> Log Out</a></li>
                    </ul>
                </li>

");
            EndContext();
            BeginContext(4869, 53, true);
            WriteLiteral("            </ul>\r\n        </nav>\r\n    </div>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Yimi.PublishManage.Core.IWorkContext _workContext { get; private set; }
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
