#pragma checksum "E:\ITI_SD_Track\MVC\Project\MVCProject\MVCProject\Views\Home\GetAllComments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31c7902874b7952f10b475daae1ea4ffed6c78a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_GetAllComments), @"mvc.1.0.view", @"/Views/Home/GetAllComments.cshtml")]
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
#line 1 "E:\ITI_SD_Track\MVC\Project\MVCProject\MVCProject\Views\_ViewImports.cshtml"
using MVCProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\ITI_SD_Track\MVC\Project\MVCProject\MVCProject\Views\_ViewImports.cshtml"
using MVCProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31c7902874b7952f10b475daae1ea4ffed6c78a2", @"/Views/Home/GetAllComments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f87f51910e1016d2b81c8d4107669623c21b1e4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_GetAllComments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Comment>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "E:\ITI_SD_Track\MVC\Project\MVCProject\MVCProject\Views\Home\GetAllComments.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>");
#nullable restore
#line 8 "E:\ITI_SD_Track\MVC\Project\MVCProject\MVCProject\Views\Home\GetAllComments.cshtml"
  Write(item.CommentContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 9 "E:\ITI_SD_Track\MVC\Project\MVCProject\MVCProject\Views\Home\GetAllComments.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Comment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
