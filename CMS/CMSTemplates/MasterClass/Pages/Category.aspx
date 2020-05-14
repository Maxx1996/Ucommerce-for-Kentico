<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="UCommerce.MasterClass.Pages.Category" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContentPlaceholder" runat="server">

    <h1>
        <asp:Literal ID="CategoryName" runat="server" />
    </h1>

    <asp:Literal ID="CategoryDescription" runat="server" />

    <asp:Repeater runat="server" ID="Products" ItemType="UCommerce.MasterClass.Models.ProductModel">
        <ItemTemplate>
            <%# Item.Name %>

            <%# string.Format("{0}", (Item.PriceCalculation != null && Item.PriceCalculation.IsDiscounted) ? "<span style='text-decoration: line-through;'>" + Item.PriceCalculation.ListPrice.Amount + "</span>" : "") %>
            <%# string.Format("{0}", Item.PriceCalculation != null ? "<span>" + Item.PriceCalculation.YourPrice.Amount + "</span>" : "") %>
            <a href="<%# Item.Url %>">More info</a>

            <br />
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
