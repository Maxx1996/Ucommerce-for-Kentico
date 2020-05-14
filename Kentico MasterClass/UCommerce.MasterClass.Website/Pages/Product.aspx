<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="UCommerce.MasterClass.Pages.Product" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceholder" runat="server">

    <h1><asp:Literal runat="server" ID="ProductName" /></h1>
    
    <div runat="server" ID="ShowPrice">
        <h2>Your price: <asp:Literal runat="server" ID="YourPriceAmount"></asp:Literal></h2>
    </div>

    <asp:Literal runat="server" ID="LongDescription" />

        <asp:HiddenField id="HiddenSku" runat="server" />
        
       <asp:dropdownlist runat="server" id="VariantDropDownList" datatextfield="VariantSku"/>
        <asp:Button runat="server" ID="AddToBasketButton" type="submit" Text="Add to basket" OnClick="AddToBasketButton_OnClick" />

</asp:Content>
