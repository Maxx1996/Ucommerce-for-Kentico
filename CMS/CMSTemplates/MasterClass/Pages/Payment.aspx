<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="UCommerce.MasterClass.Pages.Payment" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <div class="row-fluid well">
        <legend>Available payment methods</legend>
        
        <asp:RadioButtonList runat="server" ID="AvailablePaymentMethods" />

    <a href="/basket/address/shipment" class="btn btn-small">Back to Shipping Method</a>

    <asp:Button runat="server" ID="SavePaymentAndGoToPreviewBtn" class="btn btn-sm btn-arrow-right pull-right" OnClick="SavePaymentAndGoToPreviewBtn_OnClick" Text="Continue to preview order" />

</div>
</asp:Content>
