#pragma checksum "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "699f0187b960b5f56d8a1fd7cac8c905351bb2a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SqlPublish_Index), @"mvc.1.0.view", @"/Views/SqlPublish/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SqlPublish/Index.cshtml", typeof(AspNetCore.Views_SqlPublish_Index))]
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
#line 2 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
using Yimi.PublishManage.Framework.UI.Paging;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"699f0187b960b5f56d8a1fd7cac8c905351bb2a0", @"/Views/SqlPublish/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55eb66a85096509c7ddca9d37ded023fb10c11b8", @"/Views/_ViewImports.cshtml")]
    public class Views_SqlPublish_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Yimi.PublishManage.Core.IPagedList<Yimi.PublishManage.Core.Domain.SqlPublishOrder>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(138, 1943, true);
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-12"">
        <div class=""x_panel"">
            <div class=""x_title"">
                <h2>Sql发布</h2>

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
                        <a class=""close-link""><i class=""fa fa-close""></");
            WriteLiteral(@"i></a>
                    </li>
                </ul>
                <div class=""clearfix""></div>
            </div>
            <div class=""x_content"">
                <div class=""dt-buttons btn-group""><a class=""btn btn-default buttons-copy buttons-html5 btn-sm"" tabindex=""0"" aria-controls=""datatable-buttons"" href=""/SqlPublish/create""><span>Create</span></a></div>
                <!-- start project list -->
                <table class=""table table-striped projects"">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Statues</th>
                            <th>Environment</th>
                            <th>Publishtime</th>
                            <th>Db ProviderName</th>
                            <th>#Edit</th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 46 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
                         foreach (var item in Model)
                        {


#line default
#line hidden
            BeginContext(2164, 112, true);
            WriteLiteral("                            <tr>\r\n\r\n                                <td>\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2276, "\"", 2311, 2);
            WriteAttributeValue("", 2283, "/SqlPublish/edit?id=", 2283, 20, true);
#line 52 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
WriteAttributeValue("", 2303, item.Id, 2303, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2312, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2314, 9, false);
#line 52 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
                                                                      Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2323, 83, true);
            WriteLiteral("</a>\r\n                                </td>\r\n                                <td>\r\n");
            EndContext();
#line 55 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
                                     if(item.Approvalstatues == Yimi.PublishManage.Core.Domain.SqlPublishOrderApprovalStatues.Audit)
                                    {
                                        

#line default
#line hidden
            BeginContext(2625, 3, true);
            WriteLiteral("审核中");
            EndContext();
#line 57 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
                                                        

                                    }
                                    else if(item.Approvalstatues == Yimi.PublishManage.Core.Domain.SqlPublishOrderApprovalStatues.Failed)
                                    {

#line default
#line hidden
            BeginContext(2856, 70, true);
            WriteLiteral("                                       <font color=\"red\">审核失败</font>\r\n");
            EndContext();
#line 63 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"

                                    }
                                    else if(item.Approvalstatues == Yimi.PublishManage.Core.Domain.SqlPublishOrderApprovalStatues.Success)
                                    {

#line default
#line hidden
            BeginContext(3146, 73, true);
            WriteLiteral("                                        <font color=\"green\">审核通过</font>\r\n");
            EndContext();
#line 68 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"

                                    }

#line default
#line hidden
            BeginContext(3260, 75, true);
            WriteLiteral("                                </td>\r\n                                <td>");
            EndContext();
            BeginContext(3336, 37, false);
#line 71 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
                               Write(item.SqlPublishEnvironment.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(3373, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(3417, 16, false);
#line 72 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
                               Write(item.Publishtime);

#line default
#line hidden
            EndContext();
            BeginContext(3433, 45, true);
            WriteLiteral("</td>\r\n\r\n                                <td>");
            EndContext();
            BeginContext(3479, 25, false);
#line 74 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
                               Write(item.YimiSqlProvider.Name);

#line default
#line hidden
            EndContext();
            BeginContext(3504, 47, true);
            WriteLiteral("</td>\r\n\r\n                                <td>\r\n");
            EndContext();
#line 77 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
                                     if (item.Approvalstatues == Yimi.PublishManage.Core.Domain.SqlPublishOrderApprovalStatues.None || item.Approvalstatues == Yimi.PublishManage.Core.Domain.SqlPublishOrderApprovalStatues.Failed)
                                    {
                                        

#line default
#line hidden
            BeginContext(3987, 90, true);
            WriteLiteral("                                        <button class=\"btn btn-primary btn-xs submitaudit\"");
            EndContext();
            BeginWriteAttribute("modelid", " modelid=\"", 4077, "\"", 4095, 1);
#line 80 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
WriteAttributeValue("", 4087, item.Id, 4087, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4096, 48, true);
            WriteLiteral("  ><i class=\"fa fa-folder\"></i> 提交审核 </button>\r\n");
            EndContext();
#line 81 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
                                    }

#line default
#line hidden
            BeginContext(4183, 38, true);
            WriteLiteral("                                  \r\n\r\n");
            EndContext();
#line 84 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
                                     if (item.Approvalstatues == Yimi.PublishManage.Core.Domain.SqlPublishOrderApprovalStatues.Success && !item.IsPublished && item.Publishtime.Day == DateTime.Now.Day && !item.IsRunning)
                                    {


#line default
#line hidden
            BeginContext(4483, 134, true);
            WriteLiteral("                                        <button class=\"btn btn-info btn-xs run\" data-toggle=\"modal\" data-target=\".bs-example-modal-lg\"");
            EndContext();
            BeginWriteAttribute("modelid", " modelid =\"", 4617, "\"", 4636, 1);
#line 87 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
WriteAttributeValue("", 4628, item.Id, 4628, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4637, 45, true);
            WriteLiteral("><i class=\"fa fa-pencil\"></i> Run </button>\r\n");
            EndContext();
#line 88 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
                                    }
                                    else
                                    {
                                        if (item.IsRunning)
                                        {

#line default
#line hidden
            BeginContext(4906, 137, true);
            WriteLiteral("                                            <button class=\"btn btn-info btn-xs disabled\"><i class=\"fa fa-pencil\"></i> Running </button>\r\n");
            EndContext();
#line 94 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
                                        }
                                        else if (item.IsPublished)
                                        {

#line default
#line hidden
            BeginContext(5197, 115, true);
            WriteLiteral("                                            <button type=\"button\" class=\"btn btn-success btn-xs\">Success</button>\r\n");
            EndContext();
#line 98 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"

                                        }
                                        else
                                        {

#line default
#line hidden
            BeginContext(5446, 132, true);
            WriteLiteral("                                            <button class=\"btn btn-info btn-xs disabled\"><i class=\"fa fa-pencil\"></i>Run </button>\r\n");
            EndContext();
#line 103 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"

                                        }

                                    }

#line default
#line hidden
            BeginContext(5664, 74, true);
            WriteLiteral("                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 109 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(5765, 161, true);
            WriteLiteral("\r\n                    </tbody>\r\n                </table>\r\n                <!-- end project list -->\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(5927, 51, false);
#line 120 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
Write(Html.Partial("page", ViewBag.PageInfo as PageModel));

#line default
#line hidden
            EndContext();
            BeginContext(5978, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(5981, 28, false);
#line 121 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\SqlPublish\Index.cshtml"
Write(Html.Partial("ConfirmModal"));

#line default
#line hidden
            EndContext();
            BeginContext(6009, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(6030, 1823, true);
                WriteLiteral(@"
    <script>

        var currentrunid = """";

        $(function () {
            $("".run"").each(function () {
                $(this).click(function () {
                    $(""#modelmsg"").html("""");
                    currentrunid = $(this).attr(""modelid"");
                   
                })

            })
        $("".confirm"").click(function () {
          
            var data = { id: currentrunid };

            $.ajax({
                url: ""/SqlPublish/Run?id="" + currentrunid ,
                type: 'POST',
                dataType: 'json',
                data: JSON.stringify(data),
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.IsSuccess)
                        window.location.reload();
                    else {
                        $(""#modelmsg"").html(""<font color='red'>"" + data.Message + ""</font>"");
                    }
                }
            });
        })

");
                WriteLiteral(@"        $("".submitaudit"").each(function () {
            $(this).click(function () { 

                var id = $(this).attr(""modelid"");
                var data = { id: id };
                $.ajax({
                    url: ""/SqlPublish/updatestatues?id="" + id + ""&statues=2"",
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Yimi.PublishManage.Core.IPagedList<Yimi.PublishManage.Core.Domain.SqlPublishOrder>> Html { get; private set; }
    }
}
#pragma warning restore 1591