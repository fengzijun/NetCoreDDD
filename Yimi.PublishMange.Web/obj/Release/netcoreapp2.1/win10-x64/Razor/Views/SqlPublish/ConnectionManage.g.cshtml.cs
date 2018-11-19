#pragma checksum "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\ConnectionManage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0beca8f495127dec7dbe23a3875d978cc4047179"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SqlPublish_ConnectionManage), @"mvc.1.0.view", @"/Views/SqlPublish/ConnectionManage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SqlPublish/ConnectionManage.cshtml", typeof(AspNetCore.Views_SqlPublish_ConnectionManage))]
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
#line 2 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\ConnectionManage.cshtml"
using Yimi.PublishManage.Framework.UI.Paging;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0beca8f495127dec7dbe23a3875d978cc4047179", @"/Views/SqlPublish/ConnectionManage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55eb66a85096509c7ddca9d37ded023fb10c11b8", @"/Views/_ViewImports.cshtml")]
    public class Views_SqlPublish_ConnectionManage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Yimi.PublishManage.Core.IPagedList<Yimi.PublishManage.Core.Domain.YimiSqlProvider>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(138, 1858, true);
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-12"">
        <div class=""x_panel"">
            <div class=""x_title"">
                <h2>数据库管理</h2>
            
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
                        <a class=""close-link""><i class=""fa ");
            WriteLiteral(@"fa-close""></i></a>
                    </li>
                </ul>
                <div class=""clearfix""></div>
            </div>
            <div class=""x_content"">
                <div class=""dt-buttons btn-group""><a class=""btn btn-default buttons-copy buttons-html5 btn-sm"" tabindex=""0"" aria-controls=""datatable-buttons"" href=""/SqlPublish/ConnectionManageCreate""><span>Create</span></a></div>
                <!-- start project list -->
                <table class=""table table-striped projects"">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>DBName</th>
                 
                            <th>Type</th>
                      
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 45 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\ConnectionManage.cshtml"
                         foreach (var item in Model)
                        {


#line default
#line hidden
            BeginContext(2079, 112, true);
            WriteLiteral("                            <tr>\r\n\r\n                                <td>\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2191, "\"", 2242, 2);
            WriteAttributeValue("", 2198, "/SqlPublish/ConnectionManageEdit?id=", 2198, 36, true);
#line 51 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\ConnectionManage.cshtml"
WriteAttributeValue("", 2234, item.Id, 2234, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2243, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2245, 9, false);
#line 51 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\ConnectionManage.cshtml"
                                                                                      Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2254, 119, true);
            WriteLiteral("</a>\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2374, 11, false);
#line 54 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\ConnectionManage.cshtml"
                               Write(item.DbName);

#line default
#line hidden
            EndContext();
            BeginContext(2385, 103, true);
            WriteLiteral("\r\n                                </td>\r\n                      \r\n                                <td>\r\n");
            EndContext();
#line 58 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\ConnectionManage.cshtml"
                                     if (item.SqlProviderType == Yimi.PublishManage.Core.Domain.SqlProviderType.MsSql)
                                    {

                                        

#line default
#line hidden
            BeginContext(2695, 5, true);
            WriteLiteral("MSSQL");
            EndContext();
#line 61 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\ConnectionManage.cshtml"
                                                          
                                    }
                                    else
                                    {

                                        

#line default
#line hidden
            BeginContext(2877, 5, true);
            WriteLiteral("MYSQL");
            EndContext();
#line 66 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\ConnectionManage.cshtml"
                                                          
                                    }

#line default
#line hidden
            BeginContext(2930, 193, true);
            WriteLiteral("\r\n                                </td>\r\n                              \r\n                                <td>\r\n\r\n                                    <button class=\"btn btn-danger btn-xs delete\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3123, "\"", 3136, 1);
#line 73 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\ConnectionManage.cshtml"
WriteAttributeValue("", 3128, item.Id, 3128, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3137, 93, true);
            WriteLiteral(">Delete </button>\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 76 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\ConnectionManage.cshtml"
                        }

#line default
#line hidden
            BeginContext(3257, 161, true);
            WriteLiteral("\r\n                    </tbody>\r\n                </table>\r\n                <!-- end project list -->\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(3419, 51, false);
#line 87 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\ConnectionManage.cshtml"
Write(Html.Partial("page", ViewBag.PageInfo as PageModel));

#line default
#line hidden
            EndContext();
            BeginContext(3470, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3491, 806, true);
                WriteLiteral(@"
    <script>
    $(function () {

        $("".delete"").each(function () {
            $(this).click(function () {
                var id = $(this).attr(""id"");
                var data = { id: id} ;
                $.ajax({
                    url: ""/SqlPublish/ConnectionManageDelete?id="" + id,
                    type: 'POST',
                    dataType: 'json',
                    data: JSON.stringify(data),
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        if (data.IsSuccess)
                            window.location.reload();
                        else {

                        }
                    }
                });
            })

        })
    })

    </script>
");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Yimi.PublishManage.Core.IPagedList<Yimi.PublishManage.Core.Domain.YimiSqlProvider>> Html { get; private set; }
    }
}
#pragma warning restore 1591