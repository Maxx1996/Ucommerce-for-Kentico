<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Shipment.aspx.cs" Inherits="UCommerce.MasterClass.Pages.Shipment" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <div class="row-fluid well">
        <legend>Available shipment methods</legend>
        
        <asp:RadioButtonList runat="server" ID="AvailableShipmentMethods" DataTextField="Name" DataValueField="ShippingMethodId" />

    <a href="/basket/address" class="btn btn-small">Back to Address Details</a>

    <asp:Button runat="server" ID="SaveShipmentAndGoToPaymentBtn" class="btn btn-sm btn-arrow-right pull-right" OnClick="SaveShipmentAndGoToPaymentBtn_OnClick" Text="Continue to payment" />
</div>
</asp:Content>
