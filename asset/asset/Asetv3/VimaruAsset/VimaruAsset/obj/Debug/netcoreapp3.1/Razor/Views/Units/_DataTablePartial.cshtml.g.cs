#pragma checksum "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Units\_DataTablePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ce9cdf59d2c9cfd8b85bb43c8819ca18543a1b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Units__DataTablePartial), @"mvc.1.0.view", @"/Views/Units/_DataTablePartial.cshtml")]
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
#line 1 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\_ViewImports.cshtml"
using VimaruAsset;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\_ViewImports.cshtml"
using VimaruAsset.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ce9cdf59d2c9cfd8b85bb43c8819ca18543a1b2", @"/Views/Units/_DataTablePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a85afafb96f595ed93a2959785399f9d927c80d", @"/Views/_ViewImports.cshtml")]
    public class Views_Units__DataTablePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VimaruAsset.Models.Unit>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<table id=""unit"" class=""table table-striped table-bordered table-data"">
    <thead>
        <tr>
            <th>STT</th>
            <th>Đơn vị tính</th>
            <th>Ghi chú</th>
            <th>Chỉnh sửa vào</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 15 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Units\_DataTablePartial.cshtml"
         foreach (var item in Model)
        {
            if (item != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td></td>\r\n                    <td>");
#nullable restore
#line 21 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Units\_DataTablePartial.cshtml"
                   Write(item.UnitName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 22 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Units\_DataTablePartial.cshtml"
                   Write(item.Note);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 23 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Units\_DataTablePartial.cshtml"
                   Write(item.DateUpdate.ToString("dd-MM-yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"text-center\">\r\n                        <button class=\"btn btn-secondary action-btn border-0\" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 25 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Units\_DataTablePartial.cshtml"
                                                                                                                                        Write(Url.Action("Create") + "/" + item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            <span>Sửa</span>\r\n                        </button>\r\n                        <button class=\"btn btn-danger action-btn border-0\" data-toggle=\"ajax-modal\" data-target=\"#delete-model\" data-url=\"");
#nullable restore
#line 28 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Units\_DataTablePartial.cshtml"
                                                                                                                                      Write(Url.Action("Delete") + "/" + item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            <span>Xóa</span>\r\n                        </button>\r\n                    </td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 34 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Units\_DataTablePartial.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VimaruAsset.Models.Unit>> Html { get; private set; }
    }
}
#pragma warning restore 1591
