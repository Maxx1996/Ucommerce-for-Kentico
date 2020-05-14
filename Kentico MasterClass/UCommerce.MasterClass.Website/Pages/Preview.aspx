<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Preview.aspx.cs" Inherits="UCommerce.MasterClass.Pages.Preview" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    
    <div class="row-fluid well">
        <div class="span6">
            <h3>Billing address</h3>
            <br>
            <address>
                <strong>
                    <asp:Literal runat="server" ID="BillingAddressFirstName" />
                    <asp:Literal runat="server" ID="BillingAddressLastName" />
                </strong>
                <br>
                <asp:Literal runat="server" ID="BillingAddressLine1" />
                <asp:Literal runat="server" ID="BillingAddressLine2" /><br/>
                <asp:Literal runat="server" ID="BillingAddressPostalCode" />
                <asp:Literal runat="server" ID="BillingAddressCity" /><br>
                <asp:Literal runat="server" ID="BillingAddressCountryName" /><br>
                <br>
                <abbr title="Phone">P:</abbr><asp:Literal runat="server" ID="BillingAddressPhoneNumber" /><br>
                <abbr title="Mobile">M:</abbr><asp:Literal runat="server" ID="BillingAddressMobilePhoneNumber" /><br>
                <abbr title="Email">E:</abbr><a id="content_1_lnkBillingMail" href="mailto:noreply@ucommerce.net"><asp:Literal runat="server" ID="BillingAddressEmailAddress" /></a>
            </address>
        </div>

        <div class="span6">
            <h3>Shipping address</h3>
            <br>
            <address>
                <strong>
                    <asp:Literal runat="server" ID="ShippingAddressFirstName" />
                    <asp:Literal runat="server" ID="ShippingAddressLastName" />
                </strong>
                <br>
                <asp:Literal runat="server" ID="ShippingAddressLine1" />
                <asp:Literal runat="server" ID="ShippingAddressLine2" /><br/>
                <asp:Literal runat="server" ID="ShippingAddressPostalCode" />
                <asp:Literal runat="server" ID="ShippingAddressCity" /><br>
                <asp:Literal runat="server" ID="ShippingAddressCountryName" /><br>
                <br>
                <abbr title="Phone">P:</abbr><asp:Literal runat="server" ID="ShippingAddressPhoneNumber" /><br>
                <abbr title="Mobile">M:</abbr><asp:Literal runat="server" ID="ShippingAddressMobilePhoneNumber" /><br>
                <abbr title="Email">E:</abbr><a id="content_1_lnkBillingMail" href="mailto:noreply@ucommerce.net"><asp:Literal runat="server" ID="ShippingAddressEmailAddress" /></a>
            </address>
        </div>

    </div>

    <h3>Order details</h3>
    <table class="orderPreview table table-striped table-hover">
        <thead>
        <tr>
            <th>Sku</th>
            <th>Product name</th>
            <th>Quantiy</th>
            <th>Total</th>
        </tr>
        </thead>
        <tbody>
        

        <asp:Repeater runat="server" ID="OrderLinesRepeater" ItemType="UCommerce.MasterClass.Models.OrderlineModel">
            <ItemTemplate>
                <tr>
                    <input type="hidden" runat="server" id="OrderLineSku" value="<%# Item.Sku %>" />
                    <input type="hidden" runat="server" id="OrderLineVariantSku" value="<%# Item.VariantSku %>" />
                    <asp:HiddenField runat="server" id="OrderLineId" value="<%# Item.OrderLineId %>" />

                    <td><%# Item.Sku %> - <%# Item.VariantSku%></td>
                    <td><%# Item.ProductName %></td>
                    <td>
                        <%# Item.Quantity %>
                    </td>
                    <td><%# Item.Total %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
            

        </tbody>

        <tfoot>
        <tr>
            <td class="no-border" colspan="2"></td>
            <td style="width: 110px">Sub total</td>
            <td class="money"><asp:Literal runat="server" ID="SubTotal" /></td>
        </tr>
        <tr>
            <td class="no-border" colspan="2"></td>
            <td>Tax total</td>
            <td class="money"><asp:Literal runat="server" ID="TaxTotal" /></td>
        </tr>
        <tr>
            <td class="no-border" colspan="2"></td>
            <td>Discounts </td>
            <td class="money"><asp:Literal runat="server" ID="DiscountTotal" /></td>
        </tr>
        <tr>
            <td class="no-border" colspan="2"></td>
            <td>Shipping total</td>
            <td class="money"><asp:Literal runat="server" ID="ShippingTotal" /></td>
        </tr>
        <tr>
            <td class="no-border" colspan="2"></td>
            <td>Payment total</td>
            <td class="money"><asp:Literal runat="server" ID="PaymentTotal" /></td>
        </tr>
        <tr>
            <td class="no-border" colspan="2"></td>
            <td>Order total</td>
            <td class="money"><asp:Literal runat="server" ID="OrderTotal" /></td>
        </tr>
        </tfoot>
    </table>

    <a href="/basket/payment" class="btn btn-small">Back to Payment Method</a>

    <input type="hidden" name="checkout" value="true" />
    <asp:Button runat="server" ID="ConfirmAndContinueToPaymentBtn" OnClick="ConfirmAndContinueToPaymentBtn_OnClick" Text="Confirm and continue to payment" CssClass="btn btn-sm btn-arrow-right pull-right" />

</asp:Content>
