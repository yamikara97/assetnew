#pragma checksum "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ReductionHistories\_DataTablePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "574fbb9accbd94e6ceb6cae07de70df3dcf6cc39"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ReductionHistories__DataTablePartial), @"mvc.1.0.view", @"/Views/ReductionHistories/_DataTablePartial.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\_ViewImports.cshtml"
using VimaruAsset;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\_ViewImports.cshtml"
using VimaruAsset.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"574fbb9accbd94e6ceb6cae07de70df3dcf6cc39", @"/Views/ReductionHistories/_DataTablePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a85afafb96f595ed93a2959785399f9d927c80d", @"/Views/_ViewImports.cshtml")]
    public class Views_ReductionHistories__DataTablePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VimaruAsset.Models.ReductionHistory>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"<div class=""table-responsive"">
    <table id=""reductionhistory"" class=""table table-striped table-bordered nowrap mt-2 table-data"">
        <thead>
            <tr>
                <th style=""width: 16%"" class=""text-primary"">Ngày</th>
                <th class=""text-primary"">Chuyển từ</th>
                <th class=""text-primary"">Sổ</th>
                <th class=""text-primary"">Đến đơn vị</th>
                <th class=""text-primary"">Người thực hiện</th>
                <th class=""text-primary"">Số lượng</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 17 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ReductionHistories\_DataTablePartial.cshtml"
             foreach (var item in Model)
            {
                if (item != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n            \r\n                <td class=\"font-weight-bold text-wrap\">");
#nullable restore
#line 23 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ReductionHistories\_DataTablePartial.cshtml"
                                                  Write(item.DateUpdate.ToString("dd/MM/yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"font-weight-bold text-wrap\">");
#nullable restore
#line 24 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ReductionHistories\_DataTablePartial.cshtml"
                                                  Write(item.FromDepartment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"font-weight-bold text-wrap\">");
#nullable restore
#line 25 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ReductionHistories\_DataTablePartial.cshtml"
                                                  Write(item.Frombook);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"font-weight-bold\">");
#nullable restore
#line 26 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ReductionHistories\_DataTablePartial.cshtml"
                                        Write(item.ToDepartment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"font-weight-bold\">\r\n                    <span>");
#nullable restore
#line 28 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ReductionHistories\_DataTablePartial.cshtml"
                     Write(item.PersonMove);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </td>\r\n                <td class=\"font-weight-bold\">\r\n                    ");
#nullable restore
#line 31 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ReductionHistories\_DataTablePartial.cshtml"
               Write(item.NumberofAsset);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"font-weight-bold\">\r\n                    <button class=\"btn btn-danger action-btn  border-0\" data-toggle=\"ajax-modal\" data-target=\"#delete-model\" data-url=\"");
#nullable restore
#line 34 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ReductionHistories\_DataTablePartial.cshtml"
                                                                                                                                   Write(Url.Action("Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                        <span><i class=\"fas fa-eye\"></i></span>\r\n                    </button>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 39 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ReductionHistories\_DataTablePartial.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n\r\n</div>\r\n<script>\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VimaruAsset.Models.ReductionHistory>> Html { get; private set; }
    }
}
#pragma warning restore 1591