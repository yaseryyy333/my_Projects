#pragma checksum "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "222bf40fcf36422269c97768f1c566e023d910ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Details), @"mvc.1.0.view", @"/Views/Products/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"222bf40fcf36422269c97768f1c566e023d910ff", @"/Views/Products/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7d9ebfedd2d24b44ad81c5b6262f80dde86b05f", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Matjary.Models.Products>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-thumbnail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("delete-btn btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'???? ?????? ??????????\')"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
  
    ViewData["Title"] = "?????? ????????????";
    Layout = "~/Views/Shared/_dashboardLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!--Start Page Content-->
<div class=""page-content"">
    <div class=""container-fluid"">
        <div class=""page-title"">
            <i class=""fab fa-product-hunt""></i>
            <h6>????????????????</h6>
            <i class=""fa fa-angle-left""></i>
            <h6>?????? ????????????</h6>
            <i class=""fa fa-angle-left""></i>
            <h6>?????? ??????????</h6>
        </div>
        <div class=""page-info shadow"">
            <div class=""title"">
                <i class=""fab fa-product-hunt""></i>
                <h6>?????? ????????????</h6>
            </div>
            <div class=""content"">
                <div class=""row"">
                    <div class=""col-md-6 col-sm-12"">
                        <div class=""form-group row"">
                            <span class=""col-md-3 col-sm-12 col-form-label"">?????? ???????????? :</span>
                            <span class=""col-md-9 col-sm-12 col-form-label"">");
#nullable restore
#line 29 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
                                                                       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span><!--Put Server Variable Here-->
                        </div>
                        <div class=""form-group row"">
                            <span class=""col-md-3 col-sm-12 col-form-label"">?????? ???????????? :</span>
                            <span class=""col-md-9 col-sm-12 col-form-label"">");
#nullable restore
#line 33 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
                                                                       Write(Html.DisplayFor(model => model.Sku));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span><!--Put Server Variable Here-->
                        </div>
                        <div class=""form-group row"">
                            <span class=""col-md-3 col-sm-12 col-form-label"">?????? ?????????? :</span>
                            <span class=""col-md-3 col-sm-12 col-form-label"">");
#nullable restore
#line 37 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
                                                                       Write(Html.DisplayFor(model => model.SellPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" SR</span><!--Put Server Variable Here-->\r\n                            <span class=\"col-md-3 col-sm-12 col-form-label\">?????????????? :</span>\r\n                            <span class=\"col-md-3 col-sm-12 col-form-label\">");
#nullable restore
#line 39 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
                                                                       Write(Html.DisplayFor(model => model.Cost));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" SR</span><!--Put Server Variable Here-->
                        </div>
                    </div>
                    <div class=""col-md-6 col-sm-12"">
                        <div class=""form-group row"">
                            <span class=""col-md-3 col-sm-12 col-form-label"">?????? ???????????? :</span>
                            <span class=""col-md-9 col-sm-12 col-form-label"">");
#nullable restore
#line 45 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
                                                                       Write(Html.DisplayFor(model => model.Category.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span><!--Put Server Variable Here-->
                        </div>
                        <div class=""form-group row"">
                            <span class=""col-md-3 col-sm-12 col-form-label"">?????????? :</span>
                            <span class=""col-md-3 col-sm-12 col-form-label"">");
#nullable restore
#line 49 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
                                                                       Write(Html.DisplayFor(model => model.DiscountRate));

#line default
#line hidden
#nullable disable
            WriteLiteral(" SR</span><!--Put Server Variable Here-->\r\n                            <span class=\"col-md-3 col-sm-12 col-form-label\">???????????? :</span>\r\n                            <span class=\"col-md-3 col-sm-12 col-form-label\">");
#nullable restore
#line 51 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
                                                                       Write(Html.DisplayFor(model => model.Store.Qty));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" Pcs</span><!--Put Server Variable Here-->
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-sm-12"">
                        <div class=""form-group row"">
                            <span class=""col-sm-12 col-form-label"">?????? ???????????? :</span>
                            <span class=""col-sm-12 col-form-label"" style=""max-width: fit-content;"">");
#nullable restore
#line 59 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
                                                                                              Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span><!--Put Server Variable Here-->
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-sm-12"">
                        <div class=""form-group row"">
                            <span class=""col-sm-12 col-form-label"">?????? ???????????? :</span>
                            <div class=""col-sm-12"">
                                <div class=""row"">
                                    <!--Print Your Image Here-->
");
#nullable restore
#line 70 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
                                     if (Model.ProductPhoto.Count > 0)
                                    {
                                        foreach (var photo in Model.ProductPhoto)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <div class=\"col-md-4 col-sm-12\">\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "222bf40fcf36422269c97768f1c566e023d910ff12541", async() => {
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "222bf40fcf36422269c97768f1c566e023d910ff12758", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 4510, "~/Dashboard/img/products/", 4510, 25, true);
#nullable restore
#line 75 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
AddHtmlAttributeValue("", 4535, photo.Photo, 4535, 12, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4423, "~/Dashboard/img/products/", 4423, 25, true);
#nullable restore
#line 75 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
AddHtmlAttributeValue("", 4448, photo.Photo, 4448, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            </div>\r\n");
#nullable restore
#line 77 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
                                        }
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-md-3 col-sm-12"">
                        <div class=""form-group row"">
                            <label class=""col-sm-12 col-form-label"">???????????? ???????????? :</label>
                            <div class=""col-sm-12"">
                                <div style=""overflow-x: auto;"">
                                    <table class=""table table-striped"">
                                        <tbody>
");
#nullable restore
#line 92 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
                                             if (Model.ProductPersons.Count > 0)
                                            {
                                                foreach (var supplier in Model.ProductPersons)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <tr>\r\n                                                        <td>");
#nullable restore
#line 97 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
                                                       Write(supplier.Person.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    </tr>\r\n");
#nullable restore
#line 99 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
                                                }
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""btn-operation"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "222bf40fcf36422269c97768f1c566e023d910ff18200", async() => {
                WriteLiteral("<i class=\"fa fa-edit\"></i>?????????? ????????????");
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
#line 109 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
                                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "222bf40fcf36422269c97768f1c566e023d910ff20482", async() => {
                WriteLiteral("<i class=\"fa fa-edit\"></i>?????? ????????????");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 110 "D:\Project\Matjry\Code\Matjary\Matjary\Views\Products\Details.cshtml"
                                             WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Matjary.Models.Products> Html { get; private set; }
    }
}
#pragma warning restore 1591
