#pragma checksum "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec7894e9a57004205c547c8fe948d0a9fadd62e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Details), @"mvc.1.0.view", @"/Views/Student/Details.cshtml")]
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
#line 1 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\_ViewImports.cshtml"
using SchoolRegister.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\_ViewImports.cshtml"
using SchoolRegister.ViewModels.VM;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec7894e9a57004205c547c8fe948d0a9fadd62e7", @"/Views/Student/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4cf803a08bcc603de38650a214abd162194c3095", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SchoolRegister.BLL.DataModels.Student>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
  
    ViewData["Title"] = $"{Model.FirstName} {Model.LastName} details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 7 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<hr />\r\n<div class=\"row\">\r\n    <table class=\"table table-hover\">\r\n        <thead>\r\n            <tr>\r\n                <th class=\"d-none\">\r\n                    ");
#nullable restore
#line 14 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n");
#nullable restore
#line 16 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
                 if (!User.IsInRole("Parent")) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th class=\"col-2\">\r\n                    ");
#nullable restore
#line 18 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Parent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n");
#nullable restore
#line 20 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <th class=\"col-1\">\r\n                    ");
#nullable restore
#line 23 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th class=\"col-1\">\r\n                    ");
#nullable restore
#line 26 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Group));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th class=\"col-1\">\r\n                    ");
#nullable restore
#line 29 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.AverageGrade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th class=\"col-2\">\r\n                    ");
#nullable restore
#line 32 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Grades));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th class=\"col-2\">\r\n                    ");
#nullable restore
#line 35 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.AverageGradePerSubject));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n            <tr>\r\n                <td class=\"d-none\">\r\n                    ");
#nullable restore
#line 42 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
               Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 44 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
                 if (!User.IsInRole("Parent")) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 46 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Parent.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 46 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
                                                                     Write(Html.DisplayFor(model => model.Parent.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 48 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("   \r\n                <td>\r\n                    ");
#nullable restore
#line 51 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
               Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 54 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
               Write(Html.DisplayFor(model => model.Group.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
               Write(Html.DisplayFor(model => model.AverageGrade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <ul>\r\n");
#nullable restore
#line 61 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
                     foreach (var item in Model.Grades) {
                       

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>");
#nullable restore
#line 63 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Subject.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(":  ");
#nullable restore
#line 63 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
                                                                              Write(Html.DisplayFor(modelItem => item.GradeValue));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </li> \r\n");
#nullable restore
#line 64 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                     </ul> \r\n                </td>\r\n                <td>\r\n                    <ul>\r\n");
#nullable restore
#line 69 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
                         foreach (var item in Model.AverageGradePerSubject) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>");
#nullable restore
#line 70 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Key));

#line default
#line hidden
#nullable disable
            WriteLiteral(": ");
#nullable restore
#line 70 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
                                                                    Write(Html.DisplayFor(modelItem => item.Value));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 71 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                </td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>\r\n\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec7894e9a57004205c547c8fe948d0a9fadd62e713306", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 84 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Student\Details.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SchoolRegister.BLL.DataModels.Student> Html { get; private set; }
    }
}
#pragma warning restore 1591
