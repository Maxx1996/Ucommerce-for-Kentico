<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Basket.aspx.cs" Inherits="UCommerce.MasterClass.Pages.Basket" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceholder" runat="server">

    <h1>Your basket</h1>

    <form method="POST">
        <table class="table table-striped table-hover">
            <thead>
                <tr>
                    <th>SKU</th>
                    <th>Product Name</th>
                    <th>Quantity</th>
                    <th>Total</th>
                    <th>Remove</th>
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
                                <asp:TextBox runat="server" id="OrderLineQuantity" Text="<%# Item.Quantity %>" /></td>
                            <td><%# Item.Total %></td>
                            <td>
                                <asp:Button runat="server" ID="RemoveOrderLineButton" Value="<%# Item.OrderLineId %>" OnClick="RemoveOrderLineButton_OnClick" Text="Remove" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="4">OrderTotal</td>
                    <td>
                        <asp:Literal runat="server" ID="OrderTotal" /></td>
                </tr>
            </tfoot>
        </table>
        <asp:Button runat="server" ID="UpdateBasketButton" Text="Update basket" OnClick="UpdateBasketButton_OnClick" />
    </form>
    
    <asp:Button runat="server" ID="ContinueToBillingBtn" Text="Continue to billing information" OnClick="ContinueToBillingBtn_OnClick" CssClass="btn btn-sm pull-right"/>

</asp:Content>
