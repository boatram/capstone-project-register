#pragma checksum "D:\PRN221_T_Phuong\CapstoneProjectRegister (2)\CapstoneProjectRegister\CapstoneProjectRegister\CapstoneProjectRegister_Web\Pages\StudentInGroupManagement\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5efbd95e3ec916201bf0280e0a8011e2f5059d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CapstoneProjectRegister.Web.Pages.StudentInGroupManagement.Pages_StudentInGroupManagement_Index), @"mvc.1.0.razor-page", @"/Pages/StudentInGroupManagement/Index.cshtml")]
namespace CapstoneProjectRegister.Web.Pages.StudentInGroupManagement
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
#line 1 "D:\PRN221_T_Phuong\CapstoneProjectRegister (2)\CapstoneProjectRegister\CapstoneProjectRegister\CapstoneProjectRegister_Web\Pages\_ViewImports.cshtml"
using CapstoneProjectRegister.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5efbd95e3ec916201bf0280e0a8011e2f5059d6", @"/Pages/StudentInGroupManagement/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73bd8431e527e6e8b8609a59284f5ff5d5436219", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_StudentInGroupManagement_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\PRN221_T_Phuong\CapstoneProjectRegister (2)\CapstoneProjectRegister\CapstoneProjectRegister\CapstoneProjectRegister_Web\Pages\StudentInGroupManagement\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5efbd95e3ec916201bf0280e0a8011e2f5059d64220", async() => {
                WriteLiteral("Add New Student");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
                Student
            </th>
            <th>
                Role
            </th>      
            <th>
                Join Date
            </th>
            <th>
                Status
            </th>
            <th>
                Description
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 35 "D:\PRN221_T_Phuong\CapstoneProjectRegister (2)\CapstoneProjectRegister\CapstoneProjectRegister\CapstoneProjectRegister_Web\Pages\StudentInGroupManagement\Index.cshtml"
 foreach (var item in Model.StudentInGroup) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 38 "D:\PRN221_T_Phuong\CapstoneProjectRegister (2)\CapstoneProjectRegister\CapstoneProjectRegister\CapstoneProjectRegister_Web\Pages\StudentInGroupManagement\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Student.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "D:\PRN221_T_Phuong\CapstoneProjectRegister (2)\CapstoneProjectRegister\CapstoneProjectRegister\CapstoneProjectRegister_Web\Pages\StudentInGroupManagement\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "D:\PRN221_T_Phuong\CapstoneProjectRegister (2)\CapstoneProjectRegister\CapstoneProjectRegister\CapstoneProjectRegister_Web\Pages\StudentInGroupManagement\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.JoinDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 47 "D:\PRN221_T_Phuong\CapstoneProjectRegister (2)\CapstoneProjectRegister\CapstoneProjectRegister\CapstoneProjectRegister_Web\Pages\StudentInGroupManagement\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>           \r\n            <td>\r\n                ");
#nullable restore
#line 50 "D:\PRN221_T_Phuong\CapstoneProjectRegister (2)\CapstoneProjectRegister\CapstoneProjectRegister\CapstoneProjectRegister_Web\Pages\StudentInGroupManagement\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5efbd95e3ec916201bf0280e0a8011e2f5059d68236", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 54 "D:\PRN221_T_Phuong\CapstoneProjectRegister (2)\CapstoneProjectRegister\CapstoneProjectRegister\CapstoneProjectRegister_Web\Pages\StudentInGroupManagement\Index.cshtml"
                                       WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" \r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 57 "D:\PRN221_T_Phuong\CapstoneProjectRegister (2)\CapstoneProjectRegister\CapstoneProjectRegister\CapstoneProjectRegister_Web\Pages\StudentInGroupManagement\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CapstoneProjectRegister.Web.Pages.StudentInGroupManagement.IndexModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CapstoneProjectRegister.Web.Pages.StudentInGroupManagement.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CapstoneProjectRegister.Web.Pages.StudentInGroupManagement.IndexModel>)PageContext?.ViewData;
        public CapstoneProjectRegister.Web.Pages.StudentInGroupManagement.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591