#pragma checksum "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65e2264f554342d4ef68523d753d5ea0fc26d06f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Edit), @"mvc.1.0.view", @"/Views/User/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Edit.cshtml", typeof(AspNetCore.Views_User_Edit))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65e2264f554342d4ef68523d753d5ea0fc26d06f", @"/Views/User/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55eb66a85096509c7ddca9d37ded023fb10c11b8", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Yimi.PublishManage.Core.Domain.User>
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
            BeginContext(165, 1248, true);
            WriteLiteral(@"


<div class=""row"">
    <div class=""col-md-12 col-sm-12 col-xs-12"">
        <div class=""x_panel"">
            <div class=""x_title"">
                <h2>Edit User </h2>
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
                        <a class=""close-link");
            WriteLiteral("\"><i class=\"fa fa-close\"></i></a>\r\n                    </li>\r\n                </ul>\r\n                <div class=\"clearfix\"></div>\r\n            </div>\r\n            <div class=\"x_content\">\r\n                <br>\r\n            \r\n");
            EndContext();
            BeginContext(1576, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(1592, 3753, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1661e0d5663e4adda87445d5cd76b4e8", async() => {
                BeginContext(1693, 42, true);
                WriteLiteral("\r\n                    <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", "  value=\"", 1735, "\"", 1753, 1);
#line 39 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Edit.cshtml"
WriteAttributeValue("", 1744, Model.Id, 1744, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1754, 405, true);
                WriteLiteral(@" id=""UserId""/>
                    <div class=""form-group"">
                        <label class=""control-label col-md-3 col-sm-3 col-xs-12"" for=""first-name"">
                            Name <span class=""required"">*</span>
                        </label>
                        <div class=""col-md-6 col-sm-6 col-xs-12"">
                            <input type=""text"" id=""Name"" required=""required""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2159, "\"", 2178, 1);
#line 45 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Edit.cshtml"
WriteAttributeValue("", 2167, Model.Name, 2167, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2179, 484, true);
                WriteLiteral(@" class=""form-control col-md-7 col-xs-12"">
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label class=""control-label col-md-3 col-sm-3 col-xs-12"" for=""first-name"">
                            Password <span class=""required"">*</span>
                        </label>
                        <div class=""col-md-6 col-sm-6 col-xs-12"">
                            <input type=""password"" id=""Password""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2663, "\"", 2686, 1);
#line 53 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Edit.cshtml"
WriteAttributeValue("", 2671, Model.Password, 2671, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2687, 510, true);
                WriteLiteral(@" required=""required"" class=""form-control col-md-7 col-xs-12"">
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label class=""control-label col-md-3 col-sm-3 col-xs-12"" for=""last-name"">
                            Email <span class=""required"">*</span>
                        </label>
                        <div class=""col-md-6 col-sm-6 col-xs-12"">
                            <input type=""text"" id=""Email"" name=""last-name""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3197, "\"", 3217, 1);
#line 61 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Edit.cshtml"
WriteAttributeValue("", 3205, Model.Email, 3205, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3218, 397, true);
                WriteLiteral(@" required=""required"" class=""form-control col-md-7 col-xs-12"">
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label for=""middle-name"" class=""control-label col-md-3 col-sm-3 col-xs-12"">Mobile</label>
                        <div class=""col-md-6 col-sm-6 col-xs-12"">
                            <input id=""Mobile""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3615, "\"", 3636, 1);
#line 67 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Edit.cshtml"
WriteAttributeValue("", 3623, Model.Mobile, 3623, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3637, 435, true);
                WriteLiteral(@" class=""form-control col-md-7 col-xs-12"" type=""text"" name=""middle-name"">
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label for=""middle-name"" class=""control-label col-md-3 col-sm-3 col-xs-12"">Role</label>
                        <div class=""col-md-6 col-sm-6 col-xs-12"">
                            <select class=""form-control"" id=""RoleSelect"">
");
                EndContext();
#line 74 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Edit.cshtml"
                             foreach (var role in ViewBag.Roles as List<Yimi.PublishManage.Core.Domain.Role>)
                            {
                                if (role.Id == Model.Roles.FirstOrDefault().Id)
                                {


#line default
#line hidden
                BeginContext(4332, 36, true);
                WriteLiteral("                                    ");
                EndContext();
                BeginContext(4368, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2e8cfc55b8344a2183cc7f289704853b", async() => {
                    BeginContext(4403, 9, false);
#line 79 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Edit.cshtml"
                                                                 Write(role.Name);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
#line 79 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Edit.cshtml"
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
                BeginContext(4421, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 80 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Edit.cshtml"
                                }
                                else
                                {

#line default
#line hidden
                BeginContext(4531, 36, true);
                WriteLiteral("                                    ");
                EndContext();
                BeginContext(4567, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7c93f2654c504104b4721894c848c58a", async() => {
                    BeginContext(4593, 9, false);
#line 83 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Edit.cshtml"
                                                        Write(role.Name);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 83 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Edit.cshtml"
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
                BeginContext(4611, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 84 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\User\Edit.cshtml"

                                }

                            }

#line default
#line hidden
                BeginContext(4683, 655, true);
                WriteLiteral(@"                               
                              
                            </select>
                        </div>
                    </div>
                 
                 
                    <div class=""ln_solid""></div>
                    <div class=""form-group"">
                        <div class=""col-md-6 col-sm-6 col-xs-12 col-md-offset-3"">
                            <a class=""btn btn-primary"" href=""/user/index"">Back</a>
            
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
            BeginContext(5345, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(5374, 80, true);
            WriteLiteral("\r\n\r\n              \r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(5471, 1012, true);
                WriteLiteral(@"
    <script>
    $(function () {

        $("".submit"").click(function () {
           
            var Name = $(""#Name"").val();
            var Email = $(""#Email"").val();
            var Mobile = $(""#Mobile"").val();
            var Password = $(""#Password"").val();
            var RoleId = $(""#RoleSelect"").val();
            var UserId = $(""#UserId"").val();

            var data = { Name: Name, Email: Email, Mobile: Mobile, RoleId: RoleId, Password: Password, UserId: UserId} ;
            $.ajax({
                url: ""/user/Edit"",
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
            BeginContext(6486, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Yimi.PublishManage.Core.Domain.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
