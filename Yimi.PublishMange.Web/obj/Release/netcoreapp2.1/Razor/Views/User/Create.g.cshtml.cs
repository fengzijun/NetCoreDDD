#pragma checksum "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3fa9a8abaa4c78762b4ec6887f025ff14894c9c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Create), @"mvc.1.0.view", @"/Views/User/Create.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Create.cshtml", typeof(AspNetCore.Views_User_Create))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fa9a8abaa4c78762b4ec6887f025ff14894c9c2", @"/Views/User/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55eb66a85096509c7ddca9d37ded023fb10c11b8", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("demo-form2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal form-label-left"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("novalidate", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(121, 1250, true);
            WriteLiteral(@"


<div class=""row"">
    <div class=""col-md-12 col-sm-12 col-xs-12"">
        <div class=""x_panel"">
            <div class=""x_title"">
                <h2>Create User </h2>
                <ul class=""nav navbar-right panel_toolbox"">
                    <li>
                        <a class=""collapse-link""><i class=""fa fa-chevron-up""></i></a>
                    </li>
                    <li class=""dropdown"">
                        <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"" role=""button"" aria-expanded=""false""><i class=""fa fa-wrench""></i></a>
                        <ul class=""dropdown-menu"" role=""menu"">
                            <li>
                                <a href=""#"">Settings 1</a>
                            </li>
                            <li>
                                <a href=""#"">Settings 2</a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a class=""close-li");
            WriteLiteral("nk\"><i class=\"fa fa-close\"></i></a>\r\n                    </li>\r\n                </ul>\r\n                <div class=\"clearfix\"></div>\r\n            </div>\r\n            <div class=\"x_content\">\r\n                <br>\r\n            \r\n");
            EndContext();
            BeginContext(1534, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(1550, 3308, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c8f6539c7a241ecb590653b7d5e3dbb", async() => {
                BeginContext(1651, 2219, true);
                WriteLiteral(@"

                    <div class=""form-group"">
                        <label class=""control-label col-md-3 col-sm-3 col-xs-12"" for=""first-name"">
                            Name <span class=""required"">*</span>
                        </label>
                        <div class=""col-md-6 col-sm-6 col-xs-12"">
                            <input type=""text"" id=""Name"" required=""required"" class=""form-control col-md-7 col-xs-12"">
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label class=""control-label col-md-3 col-sm-3 col-xs-12"" for=""first-name"">
                            Password <span class=""required"">*</span>
                        </label>
                        <div class=""col-md-6 col-sm-6 col-xs-12"">
                            <input type=""password"" id=""Password"" required=""required"" class=""form-control col-md-7 col-xs-12"">
                        </div>
                    </div>
                    <div");
                WriteLiteral(@" class=""form-group"">
                        <label class=""control-label col-md-3 col-sm-3 col-xs-12"" for=""last-name"">
                            Email <span class=""required"">*</span>
                        </label>
                        <div class=""col-md-6 col-sm-6 col-xs-12"">
                            <input type=""text"" id=""Email"" name=""last-name"" required=""required"" class=""form-control col-md-7 col-xs-12"">
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label for=""middle-name"" class=""control-label col-md-3 col-sm-3 col-xs-12"">Mobile</label>
                        <div class=""col-md-6 col-sm-6 col-xs-12"">
                            <input id=""Mobile"" class=""form-control col-md-7 col-xs-12"" type=""text"" name=""middle-name"">
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label for=""middle-name"" class=""control-label col-md-3 col-s");
                WriteLiteral("m-3 col-xs-12\">Role</label>\r\n                        <div class=\"col-md-6 col-sm-6 col-xs-12\">\r\n                            <select class=\"form-control\" id=\"RoleSelect\">\r\n");
                EndContext();
#line 73 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Create.cshtml"
                             foreach (var role in ViewBag.Roles as List<Yimi.PublishManage.Core.Domain.Role>)
                            {

#line default
#line hidden
                BeginContext(4012, 32, true);
                WriteLiteral("                                ");
                EndContext();
                BeginContext(4044, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a9b0d8f6ba8b401d8c33c36835c7d082", async() => {
                    BeginContext(4070, 9, false);
#line 75 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Create.cshtml"
                                                    Write(role.Name);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 75 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Create.cshtml"
                                   WriteLiteral(role.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4088, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 76 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Create.cshtml"
                            }

#line default
#line hidden
                BeginContext(4121, 730, true);
                WriteLiteral(@"                               
                              
                            </select>
                        </div>
                    </div>
                 
                 
                    <div class=""ln_solid""></div>
                    <div class=""form-group"">
                        <div class=""col-md-6 col-sm-6 col-xs-12 col-md-offset-3"">
                            <a class=""btn btn-primary"" href=""/user/index"">Back</a>
                            <button class=""btn btn-primary"" type=""reset"">Reset</button>
                            <button type=""button"" class=""btn btn-success submit"">Submit</button>
                        </div>
                    </div>

                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-parsley-validate", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4858, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(4887, 80, true);
            WriteLiteral("\r\n\r\n              \r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(4984, 950, true);
                WriteLiteral(@"
    <script>
    $(function () {

        $("".submit"").click(function () {
           
            var Name = $(""#Name"").val();
            var Email = $(""#Email"").val();
            var Mobile = $(""#Mobile"").val();
            var Password = $(""#Password"").val();
            var RoleId = $(""#RoleSelect"").val();
            var data = { Name: Name, Email: Email, Mobile: Mobile, RoleId: RoleId, Password: Password} ;
            $.ajax({
                url: ""/user/Create"",
                type: 'POST',
                dataType: 'json',
                data: JSON.stringify(data),
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.IsSuccess)
                        window.location = ""/user/index"";
                    else {

                    }
                }
          
            })

        })
    })

    </script>
");
                EndContext();
            }
            );
            BeginContext(5937, 2, true);
            WriteLiteral("\r\n");
            EndContext();
        }
        #pragma warning restore 1998
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
