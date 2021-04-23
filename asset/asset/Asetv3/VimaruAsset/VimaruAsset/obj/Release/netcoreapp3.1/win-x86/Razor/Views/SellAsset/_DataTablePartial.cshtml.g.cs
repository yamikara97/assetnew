#pragma checksum "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0372f05d04758f00e881450532f29f2dd5d08bf4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SellAsset__DataTablePartial), @"mvc.1.0.view", @"/Views/SellAsset/_DataTablePartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0372f05d04758f00e881450532f29f2dd5d08bf4", @"/Views/SellAsset/_DataTablePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a85afafb96f595ed93a2959785399f9d927c80d", @"/Views/_ViewImports.cshtml")]
    public class Views_SellAsset__DataTablePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VimaruAsset.Models.AssetsViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"<div class=""table-responsive"">
    <table id=""mywarehouse"" class=""table table-striped table-bordered nowrap mt-2 table-data"">
        <thead>
            <tr>
                <th style=""width: 16%"" class=""text-primary"">Ngày thêm</th>
                <th style=""width: 15%"" class=""text-primary"">Tên tài sản</th>
                <th style=""width: 12%"" class=""text-primary"">Mã tài sản</th>
                <th style=""width: 12%"" class=""text-primary"">Đặt tại</th>
                <th style=""width: 15%"" class=""text-primary"">Tổng nguyên giá</th>
                <th style=""width: 15%"" class=""text-primary"">Tình trạng</th>
                <th style=""width: 16%"" class=""text-primary""></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 17 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml"
             foreach (var item in Model)
            {
                if (item != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td class=\"font-weight-bold text-wrap\">");
#nullable restore
#line 22 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml"
                                                  Write(item.Asset.DateUpdate.ToString("dd/MM/yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"font-weight-bold text-wrap\">");
#nullable restore
#line 23 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml"
                                                  Write(item.Asset.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"font-weight-bold\">");
#nullable restore
#line 24 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml"
                                        Write(item.Asset.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("   </td>\r\n                <td class=\"font-weight-bold\">\r\n                    <span>");
#nullable restore
#line 26 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml"
                     Write(item.Asset.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </td>\r\n                <td class=\"font-weight-bold\">\r\n                    ");
#nullable restore
#line 29 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml"
               Write(item.Asset.Price.ToString("##,##0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ\r\n                </td>\r\n                <td class=\"font-weight-bold\">\r\n");
#nullable restore
#line 32 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml"
                     if (item.Asset.Status == Assets.Statuses.GOOD)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"text-primary\">TỐT</span>");
#nullable restore
#line 33 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml"
                                                          }
                    else if (item.Asset.Status == Assets.Statuses.BAD)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"text-danger\">HỎNG</span>");
#nullable restore
#line 35 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml"
                                                          }
                    else if (item.Asset.Status == Assets.Statuses.MAINTENANCE)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"text-warning\">BẢO TRÌ</span>");
#nullable restore
#line 37 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml"
                                                              }
                    else if (item.Asset.Status == Assets.Statuses.RENT)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"text-success\">CHO THUÊ</span>");
#nullable restore
#line 39 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml"
                                                               }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n\r\n                <td class=\"text-center\">\r\n                    <button class=\"btn btn-secondary action-btn  border-0\" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 43 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml"
                                                                                                                                     Write(Url.Action("ChangeWarehouse") + "/" + item.Asset.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                        <span><i class=\"fas fa-exchange-alt\"></i></span>\r\n                    </button>\r\n                    <button class=\"btn btn-primary action-btn  border-0\" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 46 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml"
                                                                                                                                   Write(Url.Action("Create") + "/" + item.Asset.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                        <span><i class=\"fas fa-search-plus\"></i></span>\r\n                    </button>\r\n                    <button class=\"btn btn-danger action-btn  border-0\" data-toggle=\"ajax-modal\" data-target=\"#delete-model\" data-url=\"");
#nullable restore
#line 49 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml"
                                                                                                                                   Write(Url.Action("Delete") + "/" + item.Asset.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                        <span><i class=\"fas fa-trash\"></i></span>\r\n                    </button>\r\n                </td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 55 "C:\Users\Hieu HD\Documents\GitHub\asset\Asetv3\VimaruAsset\VimaruAsset\Views\SellAsset\_DataTablePartial.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VimaruAsset.Models.AssetsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
