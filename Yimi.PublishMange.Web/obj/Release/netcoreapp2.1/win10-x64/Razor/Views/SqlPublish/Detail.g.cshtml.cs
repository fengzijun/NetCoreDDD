#pragma checksum "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a799ace6960177be01ade8fe0e73483d6dd7f8d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SqlPublish_Detail), @"mvc.1.0.view", @"/Views/SqlPublish/Detail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SqlPublish/Detail.cshtml", typeof(AspNetCore.Views_SqlPublish_Detail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a799ace6960177be01ade8fe0e73483d6dd7f8d", @"/Views/SqlPublish/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55eb66a85096509c7ddca9d37ded023fb10c11b8", @"/Views/_ViewImports.cshtml")]
    public class Views_SqlPublish_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Yimi.PublishManage.Core.Domain.SqlPublishOrder>
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(62, 1245, true);
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-12 col-sm-12 col-xs-12"">
        <div class=""x_panel"">
            <div class=""x_title"">
                <h2>Sql Publish Order Detail </h2>
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
                        <a class=""c");
            WriteLiteral("lose-link\"><i class=\"fa fa-close\"></i></a>\r\n                    </li>\r\n                </ul>\r\n                <div class=\"clearfix\"></div>\r\n            </div>\r\n            <div class=\"x_content\">\r\n                <br>\r\n\r\n");
            EndContext();
            BeginContext(1474, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(1490, 3700, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2e5b21e56c834218aca2aa6e9d2b8428", async() => {
                BeginContext(1591, 42, true);
                WriteLiteral("\r\n                    <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1633, "\"", 1650, 1);
#line 36 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Detail.cshtml"
WriteAttributeValue("", 1641, Model.Id, 1641, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1651, 368, true);
                WriteLiteral(@" id=""sqlpublishorderid"" />
                    <div class=""form-group"">
                        <label class=""control-label col-md-3 col-sm-3 col-xs-12"" for=""first-name"">
                            Name <span class=""required"">*</span>
                        </label>
                        <div class=""col-md-6 col-sm-6 col-xs-12"">
                           ");
                EndContext();
                BeginContext(2020, 10, false);
#line 42 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Detail.cshtml"
                      Write(Model.Name);

#line default
#line hidden
                EndContext();
                BeginContext(2030, 410, true);
                WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label class=""control-label col-md-3 col-sm-3 col-xs-12"" for=""first-name"">
                            Environment <span class=""required"">*</span>
                        </label>
                        <div class=""col-md-6 col-sm-6 col-xs-12"">
                            ");
                EndContext();
                BeginContext(2441, 38, false);
#line 50 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Detail.cshtml"
                       Write(Model.SqlPublishEnvironment.ToString());

#line default
#line hidden
                EndContext();
                BeginContext(2479, 404, true);
                WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label class=""control-label col-md-3 col-sm-3 col-xs-12"" for=""first-name"">
                            SqlText <span class=""required"">*</span>
                        </label>
                        <div class=""col-md-6 col-sm-6 col-xs-12"">
                          ");
                EndContext();
                BeginContext(2884, 13, false);
#line 58 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Detail.cshtml"
                     Write(Model.SqlText);

#line default
#line hidden
                EndContext();
                BeginContext(2897, 326, true);
                WriteLiteral(@"
                        </div>
                    </div>

                    <div class=""form-group"">
                        <label for=""middle-name"" class=""control-label col-md-3 col-sm-3 col-xs-12"">Environment</label>
                        <div class=""col-md-6 col-sm-6 col-xs-12"">
                           
");
                EndContext();
#line 66 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Detail.cshtml"
                                 if (Model.SqlPublishEnvironment == Yimi.PublishManage.Core.Domain.SqlPublishEnvironment.Develop)
                                {
                                   

#line default
#line hidden
                BeginContext(3430, 7, true);
                WriteLiteral("Develop");
                EndContext();
#line 68 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Detail.cshtml"
                                                       

                                }
                                else if (Model.SqlPublishEnvironment == Yimi.PublishManage.Core.Domain.SqlPublishEnvironment.Uat)
                                {
                                    

#line default
#line hidden
                BeginContext(3691, 3, true);
                WriteLiteral("Uat");
                EndContext();
#line 73 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Detail.cshtml"
                                                    

                                }
                                else if (Model.SqlPublishEnvironment == Yimi.PublishManage.Core.Domain.SqlPublishEnvironment.Release)
                                {
                                    

#line default
#line hidden
                BeginContext(3952, 7, true);
                WriteLiteral("Release");
                EndContext();
#line 78 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Detail.cshtml"
                                                        

                                }
                                else
                                {
                                    

#line default
#line hidden
                BeginContext(4120, 4, true);
                WriteLiteral("Prod");
                EndContext();
#line 83 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Detail.cshtml"
                                                     

                                 }

#line default
#line hidden
                BeginContext(4171, 324, true);
                WriteLiteral(@"

                       
                        </div>
                    </div>

                    <div class=""form-group"">
                        <label for=""middle-name"" class=""control-label col-md-3 col-sm-3 col-xs-12"">SqlProvider</label>
                        <div class=""col-md-6 col-sm-6 col-xs-12"">
");
                EndContext();
#line 95 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Detail.cshtml"
                               
                                var name = (ViewBag.Providers as List<Yimi.PublishManage.Core.Domain.YimiSqlProvider>).FirstOrDefault().Name;
                            

#line default
#line hidden
                BeginContext(4702, 28, true);
                WriteLiteral("                            ");
                EndContext();
                BeginContext(4731, 4, false);
#line 98 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Detail.cshtml"
                       Write(name);

#line default
#line hidden
                EndContext();
                BeginContext(4735, 448, true);
                WriteLiteral(@"
                           </div>
                    </div>

                    <div class=""ln_solid""></div>
                    <div class=""form-group"">
                        <div class=""col-md-6 col-sm-6 col-xs-12 col-md-offset-3"">
                            <a class=""btn btn-primary"" href=""/sqlpublish/auditindex"" >Back</a>
                          
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
            BeginContext(5190, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(5215, 60, true);
            WriteLiteral("\r\n\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Yimi.PublishManage.Core.Domain.SqlPublishOrder> Html { get; private set; }
    }
}
#pragma warning restore 1591
