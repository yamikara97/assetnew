#pragma checksum "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ShoppingPlans\_DataTablePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f091272b3675154dd81dbb8a5febc652b067ea4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShoppingPlans__DataTablePartial), @"mvc.1.0.view", @"/Views/ShoppingPlans/_DataTablePartial.cshtml")]
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
#line 1 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\_ViewImports.cshtml"
using VimaruAsset;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\_ViewImports.cshtml"
using VimaruAsset.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f091272b3675154dd81dbb8a5febc652b067ea4", @"/Views/ShoppingPlans/_DataTablePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a85afafb96f595ed93a2959785399f9d927c80d", @"/Views/_ViewImports.cshtml")]
    public class Views_ShoppingPlans__DataTablePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VimaruAsset.Models.ShoppingPlan>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"<table id=""shoppingplan"" class=""table table-striped table-bordered table-data"">
    <thead>
        <tr>
            <th>STT</th>
            <th>Tên kế hoạch</th>
            <th>Năm</th>
            <th>Nội dung</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 14 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ShoppingPlans\_DataTablePartial.cshtml"
         foreach (var item in Model)
        {
            if (item != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td></td>\r\n                    <td>");
#nullable restore
#line 20 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ShoppingPlans\_DataTablePartial.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 21 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ShoppingPlans\_DataTablePartial.cshtml"
                   Write(item.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 22 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ShoppingPlans\_DataTablePartial.cshtml"
                   Write(item.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"text-center\">\r\n                        <button class=\"btn btn-secondary action-btn border-0\" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 24 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ShoppingPlans\_DataTablePartial.cshtml"
                                                                                                                                        Write(Url.Action("Create") + "/" + item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            <span>Sửa</span>\r\n                        </button>\r\n                        <button class=\"btn btn-danger action-btn border-0\" data-toggle=\"ajax-modal\" data-target=\"#delete-model\" data-url=\"");
#nullable restore
#line 27 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ShoppingPlans\_DataTablePartial.cshtml"
                                                                                                                                      Write(Url.Action("Delete") + "/" + item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            <span>Xóa</span>\r\n                        </button>\r\n                    </td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 33 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\ShoppingPlans\_DataTablePartial.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VimaruAsset.Models.ShoppingPlan>> Html { get; private set; }
    }
}
#pragma warning restore 1591
