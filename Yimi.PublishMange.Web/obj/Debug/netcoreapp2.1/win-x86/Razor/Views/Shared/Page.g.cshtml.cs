#pragma checksum "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23326183d1745b73f654aec2eab8e72dd506af25"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Page), @"mvc.1.0.view", @"/Views/Shared/Page.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Page.cshtml", typeof(AspNetCore.Views_Shared_Page))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23326183d1745b73f654aec2eab8e72dd506af25", @"/Views/Shared/Page.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55eb66a85096509c7ddca9d37ded023fb10c11b8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Page : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Yimi.PublishManage.Framework.UI.Paging.PageModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(57, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
 if (Model != null)
{
   

#line default
#line hidden
            BeginContext(88, 271, true);
            WriteLiteral(@"    <div class=""row"">
        <div class=""col-sm-5"">

        </div>
        <div class=""col-sm-7"">
            <div class=""dataTables_paginate paging_simple_numbers"" id=""datatable-responsive_paginate"">
                <ul class=""pagination"">
                   
");
            EndContext();
#line 14 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
                         if (Model.PageIndex > 0 && Model.PageCount != 1)
                        {

#line default
#line hidden
            BeginContext(461, 136, true);
            WriteLiteral("                            <li class=\"paginate_button previous\" id=\"datatable-responsive_previous\">\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 597, "\"", 641, 1);
#line 17 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
WriteAttributeValue("", 604, Model.GenerateUrl(Model.PageIndex-1), 604, 37, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(642, 116, true);
            WriteLiteral(" aria-controls=\"datatable-responsive\" data-dt-idx=\"0\" tabindex=\"0\">Previous</a>\r\n                            </li>\r\n");
            EndContext();
#line 19 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"

                        }
                        else
                        {

#line default
#line hidden
            BeginContext(844, 264, true);
            WriteLiteral(@"                         <li class=""paginate_button previous disabled"" id=""datatable-responsive_previous"">

                             <a href=""#"" aria-controls=""datatable-responsive"" data-dt-idx=""0"" tabindex=""0"">Previous</a>
                          </li>
");
            EndContext();
#line 27 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
                        }

#line default
#line hidden
            BeginContext(1135, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 30 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
                     for (int i = 1; i <= Model.PageCount; i++)
                     {
                        if (Model.PageIndex == i-1)
                        {

#line default
#line hidden
            BeginContext(1308, 64, true);
            WriteLiteral("                           <li class=\"paginate_button active\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1372, "\"", 1402, 1);
#line 34 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
WriteAttributeValue("", 1379, Model.GenerateUrl(i-1), 1379, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1403, 51, true);
            WriteLiteral(" aria-controls=\"datatable-responsive\" data-dt-idx=\"");
            EndContext();
            BeginContext(1455, 1, false);
#line 34 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
                                                                                                                                             Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(1456, 1, true);
            WriteLiteral("\"");
            EndContext();
            BeginWriteAttribute("tabindex", " tabindex=\"", 1457, "\"", 1470, 1);
#line 34 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
WriteAttributeValue("", 1468, i, 1468, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1471, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1473, 1, false);
#line 34 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
                                                                                                                                                               Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(1474, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 35 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
                        }
                        else
                        {


#line default
#line hidden
            BeginContext(1571, 58, true);
            WriteLiteral("                            <li class=\"paginate_button\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1629, "\"", 1659, 1);
#line 39 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
WriteAttributeValue("", 1636, Model.GenerateUrl(i-1), 1636, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1660, 51, true);
            WriteLiteral(" aria-controls=\"datatable-responsive\" data-dt-idx=\"");
            EndContext();
            BeginContext(1712, 1, false);
#line 39 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
                                                                                                                                       Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(1713, 1, true);
            WriteLiteral("\"");
            EndContext();
            BeginWriteAttribute("tabindex", " tabindex=\"", 1714, "\"", 1727, 1);
#line 39 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
WriteAttributeValue("", 1725, i, 1725, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1728, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1730, 1, false);
#line 39 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
                                                                                                                                                         Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(1731, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 40 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
                        }


                    }

#line default
#line hidden
            BeginContext(1796, 20, true);
            WriteLiteral("                    ");
            EndContext();
#line 44 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
                     if (Model.PageIndex < Model.PageCount - 1)
                    {


#line default
#line hidden
            BeginContext(1886, 90, true);
            WriteLiteral("                        <li class=\"paginate_button next\" id=\"datatable-responsive_next\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1976, "\"", 2020, 1);
#line 47 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
WriteAttributeValue("", 1983, Model.GenerateUrl(Model.PageIndex+1), 1983, 37, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2021, 51, true);
            WriteLiteral(" aria-controls=\"datatable-responsive\" data-dt-idx=\"");
            EndContext();
            BeginContext(2073, 15, false);
#line 47 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
                                                                                                                                                                                     Write(Model.PageCount);

#line default
#line hidden
            EndContext();
            BeginContext(2088, 1, true);
            WriteLiteral("\"");
            EndContext();
            BeginWriteAttribute("tabindex", " tabindex=\"", 2089, "\"", 2116, 1);
#line 47 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
WriteAttributeValue("", 2100, Model.PageCount, 2100, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2117, 16, true);
            WriteLiteral(">Next</a></li>\r\n");
            EndContext();
#line 48 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(2205, 159, true);
            WriteLiteral("                        <li class=\"paginate_button next disabled\" id=\"datatable-responsive_next\"><a href=\"#\" aria-controls=\"datatable-responsive\" data-dt-idx=\"");
            EndContext();
            BeginContext(2365, 15, false);
#line 51 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
                                                                                                                                                          Write(Model.PageCount);

#line default
#line hidden
            EndContext();
            BeginContext(2380, 1, true);
            WriteLiteral("\"");
            EndContext();
            BeginWriteAttribute("tabindex", " tabindex=\"", 2381, "\"", 2408, 1);
#line 51 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"
WriteAttributeValue("", 2392, Model.PageCount, 2392, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2409, 16, true);
            WriteLiteral(">Next</a></li>\r\n");
            EndContext();
#line 52 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"

                    }

#line default
#line hidden
            BeginContext(2450, 73, true);
            WriteLiteral("\r\n                </ul>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 59 "C:\Users\fengzijun\source\repos\Yimi.PublishMange\Yimi.PublishMange.Web\Views\Shared\Page.cshtml"

}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Yimi.PublishManage.Framework.UI.Paging.PageModel> Html { get; private set; }
    }
}
#pragma warning restore 1591