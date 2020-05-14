<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="UCommerce.MasterClass.Pages.Billing" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceholder" runat="server">

    <div class="row-fluid">
        <div class="well span6">
            <legend>Billing</legend>
            <div class="span12">
                <div class="span5 control-group">
                    <label>First name</label>
                    <asp:TextBox runat="server" ID="BillingAddressFirstName" CssClass="span12" />
                </div>
                <div class="span5 control-group">
                    <label class="col-lg-2 control-label">Last name</label>
                    <asp:TextBox runat="server" ID="BillingAddressLastName" CssClass="span12" />
                </div>
            </div>
            <div class="span12">
                <div class="span5 control-group">
                    <label>E-mail</label>
                    <asp:TextBox runat="server" ID="BillingAddressEmailAddress" CssClass="span12" />
                </div>
                <div class="span5 control-group">
                    <label class="">Company</label>
                    <asp:TextBox runat="server" ID="BillingAddressCompanyName" CssClass="span12" />
                </div>
            </div>
            <div class="span12">
                <div class="span5 control-group">
                    <label class="">Attention</label>
                    <asp:TextBox runat="server" ID="BillingAddressAttention" CssClass="span12" />
                </div>
                <div class="span5 control-group">
                    <label class="">Line 1</label>
                    <asp:TextBox runat="server" ID="BillingAddressLine1" CssClass="span12" />
                </div>
            </div>
            <div class="span12">
                <div class="span5 control-group">
                    <label class="">Line 2</label>
                    <asp:TextBox runat="server" ID="BillingAddressLine2" CssClass="span12" />
                </div>
                <div class="span5 control-group">
                    <label class="">City</label>
                    <asp:TextBox runat="server" ID="BillingAddressCity" CssClass="span12" />
                </div>
            </div>
            <div class="span12">
                <div class="span5 control-group">
                    <label class="">Postal code</label>
                    <asp:TextBox runat="server" ID="BillingAddressPostalCode" CssClass="span12" />
                </div>
                <div class="span5 control-group">
                    <label class="">Country</label>
                    <asp:DropDownList runat="server" ID="BillingAddressCountryDropDown"/>
                </div>
            </div>
            <div class="span12">
                <div class="span5 control-group">
                    <label class="">Phone</label>
                    <asp:TextBox runat="server" ID="BillingAddressPhoneNumber" CssClass="span12" />
                </div>
                <div class="span5 control-group">
                    <label class="">Mobile phone</label>
                    <asp:TextBox runat="server" ID="BillingAddressMobilePhoneNumber" CssClass="span12" />
                </div>
            </div>
        </div>
    
        <div class="well span6">
            <legend>Shipping</legend>
            <div class="span12">
                <div class="span5 control-group">
                    <label>First name</label>
                    <asp:TextBox runat="server" ID="ShippingAddressFirstName" CssClass="span12" />
                </div>
                <div class="span5 control-group">
                    <label class="col-lg-2 control-label">Last name</label>
                    <asp:TextBox runat="server" ID="ShippingAddressLastName" CssClass="span12" />
                </div>
            </div>
            <div class="span12">
                <div class="span5 control-group">
                    <label>E-mail</label>
                    <asp:TextBox runat="server" ID="ShippingAddressEmailAddress" CssClass="span12" />
                </div>
                <div class="span5 control-group">
                    <label class="">Company</label>
                    <asp:TextBox runat="server" ID="ShippingAddressCompanyName" CssClass="span12" />
                </div>
            </div>
            <div class="span12">
                <div class="span5 control-group">
                    <label class="">Attention</label>
                    <asp:TextBox runat="server" ID="ShippingAddressAttention" CssClass="span12" />
                </div>
                <div class="span5 control-group">
                    <label class="">Line 1</label>
                    <asp:TextBox runat="server" ID="ShippingAddressLine1" CssClass="span12" />
                </div>
            </div>
            <div class="span12">
                <div class="span5 control-group">
                    <label class="">Line 2</label>
                    <asp:TextBox runat="server" ID="ShippingAddressLine2" CssClass="span12" />
                </div>
                <div class="span5 control-group">
                    <label class="">City</label>
                    <asp:TextBox runat="server" ID="ShippingAddressCity" CssClass="span12" />
                </div>
            </div>
            <div class="span12">
                <div class="span5 control-group">
                    <label class="">Postal code</label>
                    <asp:TextBox runat="server" ID="ShippingAddressPostalCode" CssClass="span12" />
                </div>
                <div class="span5 control-group">
                    <label class="">Country</label>
                    <asp:DropDownList runat="server" ID="ShippingAddressCountryDropDown"/>
                </div>
            </div>
            <div class="span12">
                <div class="span5 control-group">
                    <label class="">Phone</label>
                    <asp:TextBox runat="server" ID="ShippingAddressPhoneNumber" CssClass="span12" />
                </div>
                <div class="span5 control-group">
                    <label class="">Mobile phone</label>
                    <asp:TextBox runat="server" ID="ShippingAddressMobilePhoneNumber" CssClass="span12" />
                </div>
            </div>
        </div>
    </div>
    
    <div style="clear: both;">
        <a href="/Basket" class="btn btn-small">Back to basket</a>
        <asp:Button runat="server" Text="Continue to Shipping" ID="SaveAndGoToShippingBtn" CssClass="btn btn-sm btn-arrow-right pull-right" OnClick="SaveAndGoToShippingBtn_OnClick"/>
    </div>
    
</asp:Content>

