#pragma checksum "C:\Users\aozturk\source\repos\CoreApp\CoreApp\Views\Product\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a1bb847b9d968c2634f49daf1490630f1debec0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_List), @"mvc.1.0.view", @"/Views/Product/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/List.cshtml", typeof(AspNetCore.Views_Product_List))]
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
#line 1 "C:\Users\aozturk\source\repos\CoreApp\CoreApp\Views\_ViewImports.cshtml"
using CoreApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a1bb847b9d968c2634f49daf1490630f1debec0", @"/Views/Product/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43a18a02369d9fd4c1e1580d3d5ccb573d920854", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\aozturk\source\repos\CoreApp\CoreApp\Views\Product\List.cshtml"
  
    ViewData["Title"] = "List";

#line default
#line hidden
            BeginContext(69, 27, true);
            WriteLiteral("\r\n<h1>List</h1>\r\n<br />\r\n\r\n");
            EndContext();
#line 9 "C:\Users\aozturk\source\repos\CoreApp\CoreApp\Views\Product\List.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
            BeginContext(129, 8, true);
            WriteLiteral("    <h2>");
            EndContext();
            BeginContext(138, 9, false);
#line 11 "C:\Users\aozturk\source\repos\CoreApp\CoreApp\Views\Product\List.cshtml"
   Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(147, 15, true);
            WriteLiteral("</h2>\r\n    <h3>");
            EndContext();
            BeginContext(163, 10, false);
#line 12 "C:\Users\aozturk\source\repos\CoreApp\CoreApp\Views\Product\List.cshtml"
   Write(item.Price);

#line default
#line hidden
            EndContext();
            BeginContext(173, 15, true);
            WriteLiteral("</h3>\r\n    <h4>");
            EndContext();
            BeginContext(189, 13, false);
#line 13 "C:\Users\aozturk\source\repos\CoreApp\CoreApp\Views\Product\List.cshtml"
   Write(item.Category);

#line default
#line hidden
            EndContext();
            BeginContext(202, 19, true);
            WriteLiteral("</h4>\r\n    <hr />\r\n");
            EndContext();
#line 15 "C:\Users\aozturk\source\repos\CoreApp\CoreApp\Views\Product\List.cshtml"
}

#line default
#line hidden
            BeginContext(224, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
