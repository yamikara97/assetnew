#pragma checksum "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "165ba3c178a052bb6bb3d044e8038f8b3169819e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Departments__DataTablePartial), @"mvc.1.0.view", @"/Views/Departments/_DataTablePartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"165ba3c178a052bb6bb3d044e8038f8b3169819e", @"/Views/Departments/_DataTablePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a85afafb96f595ed93a2959785399f9d927c80d", @"/Views/_ViewImports.cshtml")]
    public class Views_Departments__DataTablePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VimaruAsset.Models.Department>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<table id=\"department\" class=\"table table-striped table-bordered\">\r\n    <thead>\r\n        <tr>\r\n            <th>Cây quản lý hệ thống</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n        <tr>\r\n            <td>\r\n");
#nullable restore
#line 12 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                  
                    bool check(Department dep)
                    {
                        foreach(var item in Model)
                        {
                            if (item.FatherID == dep.FatherID)
                            {
                                return true;
                            }
                        }
                        return false;
                    }


                    var List = Model;
                    var ListLeft = Model;
                    void createtree(string fatherID, IEnumerable<Department> list)
                    {

                        if (fatherID == "")
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                             foreach (var item in list)
                            {
                                if (item.FatherID == "" || item.FatherID == null)
                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"active\">\r\n                                        <span");
            BeginWriteAttribute("class", " class=\"", 1273, "\"", 1372, 2);
#nullable restore
#line 39 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
WriteAttributeValue("", 1281, list.Where(a => a.FatherID == item.Code).ToList().Count() > 0 ? "caret caret-down" : "", 1281, 90, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1371, "", 1372, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            ");
#nullable restore
#line 40 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            <button class=\"btn btn-nest ml-lg-2\" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 41 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                                                                                                                           Write(Url.Action("Create") + "?Code=" + item.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fas fa-plus\"></i></button>\r\n                                            <button class=\"btn btn-nest \" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 42 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                                                                                                                    Write(Url.Action("Create") + "/" + item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fas fa-edit\"></i></button>\r\n                                            <button class=\"btn btn-nest \" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 43 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                                                                                                                    Write(Url.Action("Delete") + "/" + item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fas fa-trash\"></i></button>\r\n                                        </span>\r\n                                        <ul class=\"nested active\">\r\n");
#nullable restore
#line 46 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                              list = list.Where(a => a.Code != item.Code);
                                                ListLeft = list;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 49 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                              
                                                createtree(item.Code, list);
                                            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </ul>\r\n                                    </li>\r\n");
#nullable restore
#line 55 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"

                                }
                              }

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                               
                        }
                        else
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                             foreach (var item in list)
                            {
                                if (item.FatherID == fatherID)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li>\r\n                                        <span");
            BeginWriteAttribute("class", " class=\"", 3063, "\"", 3169, 2);
#nullable restore
#line 66 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
WriteAttributeValue("", 3071, list.Where(a => a.FatherID == item.Code).ToList().Count() > 0 ? "caret  caret-down" : "", 3071, 91, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 3162, "active", 3163, 7, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            ");
#nullable restore
#line 67 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            <button class=\"btn btn-nest ml-lg-2\" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 68 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                                                                                                                           Write(Url.Action("Create") + "?Code=" + item.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fas fa-plus\"></i></button>\r\n                                            <button class=\"btn btn-nest \" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 69 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                                                                                                                    Write(Url.Action("Create") + "/" + item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fas fa-edit\"></i></button>\r\n                                            <button class=\"btn btn-nest \" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 70 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                                                                                                                    Write(Url.Action("Delete") + "/" + item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fas fa-trash\"></i></button>\r\n                                        </span>\r\n                                                <ul class=\"nested active\">\r\n");
#nullable restore
#line 73 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                                      list = list.Where(a => a.Code != item.Code);
                                                        ListLeft = list;

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                                      
                                                        createtree(item.Code, list);
                                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </ul>\r\n                                      </li>\r\n");
#nullable restore
#line 80 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 81 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                 
                                }
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <ul id=\"myUL\">\r\n\r\n");
#nullable restore
#line 88 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                  
                    createtree("", List);
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 91 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                 foreach (var item in Model)
                {
                    if (!check(item))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <span");
            BeginWriteAttribute("class", " class=\"", 4957, "\"", 4965, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 97 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <button class=\"btn btn-nest ml-lg-2\" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 98 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                                                                                                               Write(Url.Action("Create") + "?Code=" + item.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fas fa-plus\"></i></button>\r\n                                <button class=\"btn btn-nest \" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 99 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                                                                                                        Write(Url.Action("Create") + "/" + item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fas fa-edit\"></i></button>\r\n                                <button class=\"btn btn-nest \" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 100 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                                                                                                        Write(Url.Action("Delete") + "/" + item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fas fa-trash\"></i></button>\r\n                            </span>\r\n                        </li>\r\n");
#nullable restore
#line 103 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                    }
                    if (item.FatherID == item.Code)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <span");
            BeginWriteAttribute("class", " class=\"", 5867, "\"", 5875, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 108 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <button class=\"btn btn-nest ml-lg-2\" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 109 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                                                                                                               Write(Url.Action("Create") + "?Code=" + item.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fas fa-plus\"></i></button>\r\n                                <button class=\"btn btn-nest \" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 110 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                                                                                                        Write(Url.Action("Create") + "/" + item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fas fa-edit\"></i></button>\r\n                                <button class=\"btn btn-nest \" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 111 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                                                                                                                        Write(Url.Action("Delete") + "/" + item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fas fa-trash\"></i></button>\r\n                            </span>\r\n                        </li>\r\n");
#nullable restore
#line 114 "C:\Users\Cheem\Documents\GitHub\assetnew\asset\asset\Asetv3\VimaruAsset\VimaruAsset\Views\Departments\_DataTablePartial.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n            </td>\r\n        </tr>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VimaruAsset.Models.Department>> Html { get; private set; }
    }
}
#pragma warning restore 1591
