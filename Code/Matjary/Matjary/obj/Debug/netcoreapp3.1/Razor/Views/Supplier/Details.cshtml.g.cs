#pragma checksum "D:\Project\Matjry\Code\Matjary\Matjary\Views\Supplier\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5dd3923d7b9cac970173fb703401be1af0ae707"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Supplier_Details), @"mvc.1.0.view", @"/Views/Supplier/Details.cshtml")]
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
#line 1 "D:\Project\Matjry\Code\Matjary\Matjary\Views\_ViewImports.cshtml"
using Matjary;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\Matjry\Code\Matjary\Matjary\Views\_ViewImports.cshtml"
using Matjary.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5dd3923d7b9cac970173fb703401be1af0ae707", @"/Views/Supplier/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7d9ebfedd2d24b44ad81c5b6262f80dde86b05f", @"/Views/_ViewImports.cshtml")]
    public class Views_Supplier_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Matjary.Models.Persons>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("delete-btn btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'هل انت متأكد\')"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Supplier\Details.cshtml"
  
    ViewData["Title"] = "عرض المورد";
    Layout = "~/Views/Shared/_dashboardLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<!--Start Page Content-->
<div class=""page-content"">
    <div class=""container-fluid"">
        <div class=""page-title"">
            <i class=""fa fa-user-friends""></i>
            <h6>الموردين</h6>
            <i class=""fa fa-angle-left""></i>
            <h6>عرض المورد</h6>
            <i class=""fa fa-angle-left""></i>
            <h6>
                ");
#nullable restore
#line 20 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Supplier\Details.cshtml"
           Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </h6>
        </div>
        <div class=""page-info shadow"">
            <div class=""title"">
                <i class=""fa fa-user-friends""></i>
                <h6>عرض المورد</h6>
            </div>
            <div class=""content"">
                <div class=""row"">
                    <div class=""col-md-6 col-sm-12"">
                        <div class=""form-group row"">
                            <span class=""col-md-3 col-sm-12 col-form-label"">اسم المورد :</span>
                            <span class=""col-md-9 col-sm-12 col-form-label"">
                                ");
#nullable restore
#line 34 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Supplier\Details.cshtml"
                           Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </span><!--Put Server Variable Here-->
                        </div>
                        <div class=""form-group row"">
                            <span class=""col-md-3 col-sm-12 col-form-label"">رقم التلفون :</span>
                            <span class=""col-md-9 col-sm-12 col-form-label"">
                                ");
#nullable restore
#line 40 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Supplier\Details.cshtml"
                           Write(Html.DisplayFor(model => model.Telephone));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </span><!--Put Server Variable Here-->
                        </div>
                        <div class=""form-group row"">
                            <span class=""col-md-3 col-sm-12 col-form-label"">الايميل :</span>
                            <span class=""col-md-9 col-sm-12 col-form-label"">
                                ");
#nullable restore
#line 46 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Supplier\Details.cshtml"
                           Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </span><!--Put Server Variable Here-->
                        </div>
                    </div>
                    <div class=""col-md-6 col-sm-12"">
                        <div class=""form-group row"">
                            <span class=""col-md-3 col-sm-12 col-form-label"">عنوان المورد :</span>
                            <span class=""col-md-9 col-sm-12 col-form-label"">
                                ");
#nullable restore
#line 54 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Supplier\Details.cshtml"
                           Write(Html.DisplayFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </span><!--Put Server Variable Here-->
                        </div>
                        <div class=""form-group row"">
                            <span class=""col-md-3 col-sm-12 col-form-label"">رقم الجوال :</span>
                            <span class=""col-md-9 col-sm-12 col-form-label"">
                                ");
#nullable restore
#line 60 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Supplier\Details.cshtml"
                           Write(Html.DisplayFor(model => model.Mobile));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </span><!--Put Server Variable Here-->
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-sm-12"">
                        <div class=""form-group row"">
                            <span class=""col-sm-12 col-form-label"">ملاحظات :</span>
                            <span class=""col-sm-12 col-form-label"" style=""max-width: fit-content;"">
                                
                                    ");
#nullable restore
#line 71 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Supplier\Details.cshtml"
                                Write((Model.Note == null) ? "لا يوجد ملاحظات" : Model.Note);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                \r\n                            </span><!--Put Server Variable Here-->\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"btn-operation\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d5dd3923d7b9cac970173fb703401be1af0ae70710194", async() => {
                WriteLiteral("<i class=\"fa fa-edit\"></i>تعديل المورد");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 78 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Supplier\Details.cshtml"
                                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d5dd3923d7b9cac970173fb703401be1af0ae70712475", async() => {
                WriteLiteral("<i class=\"fa fa-edit\"></i>حذف المورد");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 79 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Supplier\Details.cshtml"
                                             WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!--End Page Content-->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Matjary.Models.Persons> Html { get; private set; }
    }
}
#pragma warning restore 1591
