#pragma checksum "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6c2cca02e281f46b7339c7751a79234ef7c7a78f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CustomerOrder_OrderDetails), @"mvc.1.0.view", @"/Views/CustomerOrder/OrderDetails.cshtml")]
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
#line 1 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\_ViewImports.cshtml"
using ClickToBuy;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\_ViewImports.cshtml"
using ClickToBuy.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
using ClickToBuy.Model;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c2cca02e281f46b7339c7751a79234ef7c7a78f", @"/Views/CustomerOrder/OrderDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58182b6284b770ec652d8b2f171e7aefd040d64f", @"/Views/_ViewImports.cshtml")]
    public class Views_CustomerOrder_OrderDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<OrderDetails>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-theme02"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CustomerOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CUstomerOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AcceptOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
  
    ViewData["Title"] = "OrderDetails";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";
    CustomerBillingAddress customerBillingAddress = ViewBag.CustomerOrderBillingAddress;
    Order customerOrderInfo = ViewBag.CustomerOrderInfo;
    double unitPrice = 0, total = 0, subTotal = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""row content-panel"" style=""margin-top: 30px"">
        <div class=""col-lg-10 col-lg-offset-1"">
            <div class=""invoice-body"">
                <div class=""pull-left"">
                    <h1>Click To Buy</h1>
                    <address>
                        <strong>H# 880, Adarsho Road,</strong><br>
                        Moddho Monipur,<br>
                        Mirpur 2, Dhaka,<br>
                        Bangladesh.<br>
                        <abbr title=""Phone"">P:</abbr> 01743909840
                    </address>
                </div>
                <!-- /pull-left -->
                <div class=""pull-right"">
                    <h3>Delivery Address</h3>
                    <address>
                        ");
#nullable restore
#line 29 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                   Write(customerOrderInfo.CustomerBillingAddress.BillingAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br>\r\n                        ");
#nullable restore
#line 30 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                   Write(customerOrderInfo.DeliveryCharge.City.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </address>
                </div>
                <!-- /pull-right -->
                <div class=""clearfix""></div>
                <br>
                <div class=""row"">
                    <div class=""col-md-9"">
                        <h4>");
#nullable restore
#line 38 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                       Write(customerOrderInfo.Customer.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                        <address>\r\n                            <strong>");
#nullable restore
#line 40 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                               Write(customerOrderInfo.Customer.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong><br>\r\n                            <abbr title=\"Phone\">P:</abbr> ");
#nullable restore
#line 41 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                                                     Write(customerOrderInfo.Customer.Contact);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br>\r\n                            ");
#nullable restore
#line 42 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                       Write(customerOrderInfo.Customer.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                            ");
#nullable restore
#line 43 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                       Write(customerOrderInfo.Customer.City.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                            ");
#nullable restore
#line 44 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                       Write(customerOrderInfo.Customer.Country.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </address>
                    </div>
                    <!-- /col-md-9 -->
                    <div class=""col-md-3"">
                        <br>
                        <br>
                        <br>
                        <div>
                            <div class=""pull-left""> ORDER NO : </div>
                            <div class=""pull-right""> ");
#nullable restore
#line 54 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                                                Write(customerOrderInfo.OrderNo);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </div>
                            <div class=""clearfix""></div>
                        </div>
                        <div>
                            <!-- /col-md-3 -->
                            <div class=""pull-left""> ORDER DATE : </div>
                            <div class=""pull-right""> ");
#nullable restore
#line 60 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                                                Write(customerOrderInfo.OrderDate.ToString("d/M/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </div>
                            <div class=""clearfix""></div>
                        </div>
                        <!-- /row -->
                    </div>
                    <!-- /invoice-body -->
                </div>
                <!-- /col-lg-10 -->
                <br>
                <table class=""table"">
                    <thead>
                        <tr>
                            <th style=""width:160px"" class=""text-center"">Product Name</th>
                            <th style=""width:40px"" class=""text-left"">Qty</th>
                            <th style=""width:40px"" class=""text-right"">UNIT PRICE</th>
                            <th style=""width:90px"" class=""text-right"">TOTAL</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 79 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                         foreach (OrderDetails orderDetails in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td class=\"text-center\">");
#nullable restore
#line 82 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                                                   Write(orderDetails.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"text-left\">");
#nullable restore
#line 83 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                                                 Write(orderDetails.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 84 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                                  
                                    unitPrice = Convert.ToDouble(orderDetails.Product.OfferPrice > 0 ? orderDetails.Product.OfferPrice : orderDetails.Product.RegularPrice);
                                    total = unitPrice * orderDetails.Quantity;
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"text-right\">");
#nullable restore
#line 88 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                                                  Write(unitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"text-right\">");
#nullable restore
#line 89 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                                                  Write(total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 91 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"

                            { subTotal = subTotal + total; }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <tr>
                            <td colspan=""2"" rowspan=""4"">
                                <h4>Terms and Conditions</h4>
                                <p>Thank you for your business. We do expect payment within 21 days, so please process this invoice within that time. There will be a 1.5% interest charge per month on late invoices.</p>
                            </td>
                            <td class=""text-right""><strong>Subtotal</strong></td>
                            <td class=""text-right"">");
#nullable restore
#line 101 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                                              Write(subTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"text-right no-border\"><strong>Shipping</strong></td>\r\n                            <td class=\"text-right\">");
#nullable restore
#line 105 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                                              Write(customerOrderInfo.DeliveryCharge.Ammount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                        </tr>
                        <tr>
                            <td class=""text-right no-border"">
                                <div class=""well well-small green""><strong>Total</strong></div>
                            </td>
                            <td class=""text-right"">
");
#nullable restore
#line 112 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                                  
                                    total = subTotal + customerOrderInfo.DeliveryCharge.Ammount;
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <strong>");
#nullable restore
#line 115 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                                   Write(total);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <br>
                <br>
                <div class=""row"">
                    <div class=""col-md-12 text-center"">
");
#nullable restore
#line 124 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                         if (customerOrderInfo.Status == true)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6c2cca02e281f46b7339c7751a79234ef7c7a78f17588", async() => {
                WriteLiteral(" Back To Order List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            <a class=\"btn btn-success\">All Ready Accept Order</a>\r\n");
#nullable restore
#line 128 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6c2cca02e281f46b7339c7751a79234ef7c7a78f19470", async() => {
                WriteLiteral(" Back To Order List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6c2cca02e281f46b7339c7751a79234ef7c7a78f20956", async() => {
                WriteLiteral(" Accept Order");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 132 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                                                                                                                 WriteLiteral(customerOrderInfo.Id);

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
            WriteLiteral("\r\n");
#nullable restore
#line 133 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\CustomerOrder\OrderDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>            \r\n            <!--/col-lg-12 mt -->\r\n        </div>\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<OrderDetails>> Html { get; private set; }
    }
}
#pragma warning restore 1591
