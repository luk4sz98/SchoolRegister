#pragma checksum "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0436f23565708388a4f7a9c00d35924fab11568b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Subject_Index), @"mvc.1.0.view", @"/Views/Subject/Index.cshtml")]
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
#nullable restore
#line 2 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0436f23565708388a4f7a9c00d35924fab11568b", @"/Views/Subject/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4cf803a08bcc603de38650a214abd162194c3095", @"/Views/_ViewImports.cshtml")]
    public class Views_Subject_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SchoolRegister.ViewModels.VM.SubjectVm>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddOrEditSubject", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Group", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AttachSubjectToGroup", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DetachSubjectFromGroup", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 5 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
      
    ViewData["Title"] = "Index";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <h2>");
#nullable restore
#line 9 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
   Write(Localizer["h2"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 10 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
     if (User.IsInRole("Admin"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0436f23565708388a4f7a9c00d35924fab11568b6255", async() => {
#nullable restore
#line 13 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
                                    Write(Localizer["Create"]);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 15 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <table id=\"tabela\" class=\"table table-responsive table-striped table-hover\">\r\n        <thead>\r\n            <tr>\r\n                <th class=\"d-none\">\r\n                    ");
#nullable restore
#line 21 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th class=\"col-2\">\r\n                    ");
#nullable restore
#line 24 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
               Write(Localizer["Name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th class=\"col-5\">\r\n                    ");
#nullable restore
#line 27 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
               Write(Localizer["Description"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th class=\"col-2\">\r\n                    ");
#nullable restore
#line 30 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
               Write(Localizer["Teacher"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th class=\"col-2\">\r\n                    ");
#nullable restore
#line 33 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
               Write(Localizer["GroupsCount"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 38 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td class=\"d-none\">\r\n                    ");
#nullable restore
#line 42 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"col-2\">\r\n                    ");
#nullable restore
#line 45 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"col-5\">\r\n                    ");
#nullable restore
#line 48 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"col-2\">\r\n                    ");
#nullable restore
#line 51 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.TeacherName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td class=\"col-2\">\r\n                    ");
#nullable restore
#line 55 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Groups.Count));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </td>
                <td class=""align-middle text-center"">
                    <div class=""dropdown show"">
                         <a class=""btn btn-secondary dropdown-toggle"" href=""#"" role=""button"" id=""dropdownMenuLink""
                            data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                            ");
#nullable restore
#line 61 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
                       Write(Localizer["Manage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </a>\r\n                        <div class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuLink\">\r\n");
#nullable restore
#line 64 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
                     if (User.IsInRole("Admin"))
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0436f23565708388a4f7a9c00d35924fab11568b13298", async() => {
                WriteLiteral("\r\n                                ");
#nullable restore
#line 68 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
                           Write(Localizer["Edit"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 67 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
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
            WriteLiteral("\r\n                            <div class=\"dropdown-divider\"></div>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0436f23565708388a4f7a9c00d35924fab11568b16067", async() => {
                WriteLiteral("\r\n                                ");
#nullable restore
#line 72 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
                           Write(Localizer["Attach"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-subjectId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 71 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
                                                                                                                       WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["subjectId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-subjectId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["subjectId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            <div class=\"dropdown-divider\"></div>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0436f23565708388a4f7a9c00d35924fab11568b19106", async() => {
                WriteLiteral("\r\n                                ");
#nullable restore
#line 76 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
                           Write(Localizer["Detach"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-subjectId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 75 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
                                                                                                                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["subjectId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-subjectId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["subjectId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            <div class=\"dropdown-divider\"></div>\r\n                            <a href=\"#\" class=\"dropdown-item modalLink\" >\r\n                                ");
#nullable restore
#line 80 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
                           Write(Localizer["Delete"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>                            \r\n");
#nullable restore
#line 82 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
                        
                    
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"dropdown-divider\"></div>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0436f23565708388a4f7a9c00d35924fab11568b22973", async() => {
#nullable restore
#line 86 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
                                                                                     Write(Localizer["Details"]);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 86 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
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
            WriteLiteral("\r\n                    </div>\r\n                    </div>\r\n\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 92 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    <div class=\"modal fade\" id=\"Modalpopup\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myModalLabel\">\r\n        <div class=\"modal-dialog\" role=\"document\">\r\n\r\n        </div>\r\n    </div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            $("".modalLink"").click(function () {
                var $currentId = $(this).closest(""tr"").children('td:first').text();
                console.log($currentId)
                $.ajax({
                    url: """);
#nullable restore
#line 108 "C:\Users\lukas\Desktop\Studia semestr 6\Aplikacje www\Lab\School register\SchoolRegister.Web\Views\Subject\Index.cshtml"
                     Write(Url.Action("GetIdToDelete", "Subject"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                    data: {
                        subjectId: $currentId
                    },
                    success: function (data) {
                        $("".modal-dialog"").html(data);
                        $(""#Modalpopup"").modal('show');
                    }
                });
            })
        })
    </script>
    ");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SchoolRegister.ViewModels.VM.SubjectVm>> Html { get; private set; }
    }
}
#pragma warning restore 1591
