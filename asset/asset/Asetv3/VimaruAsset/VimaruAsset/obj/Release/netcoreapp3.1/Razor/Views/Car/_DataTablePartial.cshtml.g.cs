#pragma checksum "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a8ede555876c15772f68806fc1b43531a1c0e71"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Car__DataTablePartial), @"mvc.1.0.view", @"/Views/Car/_DataTablePartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a8ede555876c15772f68806fc1b43531a1c0e71", @"/Views/Car/_DataTablePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a85afafb96f595ed93a2959785399f9d927c80d", @"/Views/_ViewImports.cshtml")]
    public class Views_Car__DataTablePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VimaruAsset.Models.AssetsViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"<div class=""table-responsive"">
    <table id=""mywarehouse"" class=""table table-striped table-bordered nowrap mt-2 table-data"">
        <thead>
            <tr>
                <th>STT</th>
                <th style=""width: 16%"" class=""text-primary"">Ngày thêm</th>
                <th style=""width: 15%"" class=""text-primary"">Tên tài sản</th>
                <th style=""width: 12%"" class=""text-primary"">Mã tài sản</th>
                <th style=""width: 12%"" class=""text-primary"">Đặt tại</th>
                <th style=""width: 15%"" class=""text-primary"">Tổng nguyên giá</th>
                <th style=""width: 15%"" class=""text-primary"">Tình trạng</th>
                <th style=""width: 16%"" class=""text-primary"">Hạn bảo hành</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 18 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
             foreach (var item in Model)
            {
                if (item != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td></td>\r\n                        <td class=\"font-weight-bold text-wrap\">");
#nullable restore
#line 24 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                                                          Write(item.Asset.DateUpdate.ToString("dd/MM/yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"font-weight-bold text-wrap\">");
#nullable restore
#line 25 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                                                          Write(item.Asset.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"font-weight-bold\">");
#nullable restore
#line 26 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                                                Write(item.Asset.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("   </td>\r\n                        <td class=\"font-weight-bold\">\r\n                            <span>");
#nullable restore
#line 28 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                             Write(item.Asset.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </td>\r\n                        <td class=\"font-weight-bold\">\r\n                            ");
#nullable restore
#line 31 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                       Write(item.Asset.Price.ToString("##,##0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ\r\n                        </td>\r\n                        <td class=\"font-weight-bold\">\r\n");
#nullable restore
#line 34 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                             if (item.Asset.Status == Assets.Statuses.GOOD)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"text-primary\">TỐT</span>");
#nullable restore
#line 35 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                                                                  }
                            else if (item.Asset.Status == Assets.Statuses.BAD)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"text-danger\">HỎNG</span>");
#nullable restore
#line 37 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                                                                  }
                            else if (item.Asset.Status == Assets.Statuses.MAINTENANCE)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"text-warning\">BẢO TRÌ</span>");
#nullable restore
#line 39 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                                                                      }
                            else if (item.Asset.Status == Assets.Statuses.RENT)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"text-success\">CHO THUÊ</span>");
#nullable restore
#line 41 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                                                                       }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n\r\n                        <td class=\"font-weight-bold\">\r\n");
#nullable restore
#line 45 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                              
                                int times = (int)(item.Asset.Guarantee - DateTime.Now).TotalDays;
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                             if (times > 30)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"text-primary\">Còn ");
#nullable restore
#line 50 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                                                          Write(times);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Ngày</span>\r\n");
#nullable restore
#line 51 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                            }
                            else if (times > 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"text-warning\">Còn ");
#nullable restore
#line 54 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                                                          Write(times);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Ngày</span>\r\n");
#nullable restore
#line 55 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                            }
                            else if (times <= 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"text-danger\">Hết hạn</span>\r\n");
#nullable restore
#line 59 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 62 "D:\asset 27-2\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Car\_DataTablePartial.cshtml"
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
