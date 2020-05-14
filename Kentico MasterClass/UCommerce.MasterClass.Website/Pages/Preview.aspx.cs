using System;
using UCommerce.MasterClass.Models;
using UCommerce.Api;
using UCommerce.EntitiesV2;

namespace UCommerce.MasterClass.Pages
{
    public partial class Preview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PurchaseOrderModel model = MapOrder();

            model.BillingAddress = MapOrderAddress(TransactionLibrary.GetBillingInformation());
            model.ShippingAddress = MapOrderAddress(TransactionLibrary.GetShippingInformation());
            var basket = UCommerce.Api.TransactionLibrary.GetBasket(false).PurchaseOrder;
            var billingCurrency = basket.BillingCurrency;
            foreach(var basketOrderLine in basket.OrderLines)
            {
                var orderLineModel = new OrderlineModel();
                orderLineModel.Sku = basketOrderLine.Sku;
                orderLineModel.VariantSku = basketOrderLine.VariantSku;
                orderLineModel.ProductName = basketOrderLine.ProductName;
                orderLineModel.Quantity = basketOrderLine.Quantity;
                orderLineModel.Total = new UCommerce.Money(basketOrderLine.Total.GetValueOrDefault(), billingCurrency).ToString();
                model.OrderLines.Add(orderLineModel);
            }
            model.SubTotal = GetMoneyFormat(basket.SubTotal.GetValueOrDefault(), billingCurrency);
            model.TaxTotal = GetMoneyFormat(basket.TaxTotal.GetValueOrDefault(), billingCurrency);
            model.DiscountTotal = GetMoneyFormat(basket.DiscountTotal.GetValueOrDefault(), billingCurrency);
            model.ShippingTotal = GetMoneyFormat(basket.ShippingTotal.GetValueOrDefault(), billingCurrency);
            model.PaymentTotal = GetMoneyFormat(basket.PaymentTotal.GetValueOrDefault(), billingCurrency);
            model.OrderTotal = GetMoneyFormat(basket.OrderTotal.GetValueOrDefault(), billingCurrency);


            BuildPage(model);
        }

        private string GetMoneyFormat(decimal? value, Currency currency)
        {
            return new UCommerce.Money(value.GetValueOrDefault(), currency).ToString();
        }

        private void BuildPage(PurchaseOrderModel model)
        {
            BillingAddressFirstName.Text = model.BillingAddress.FirstName;
            BillingAddressLastName.Text = model.BillingAddress.LastName;
            BillingAddressLine1.Text = model.BillingAddress.Line1;
            BillingAddressLine2.Text = model.BillingAddress.Line2;
            BillingAddressPostalCode.Text = model.BillingAddress.PostalCode;
            BillingAddressCity.Text = model.BillingAddress.City;
            BillingAddressCountryName.Text = Country.Get(model.BillingAddress.CountryId).Name;

            ShippingAddressFirstName.Text = model.ShippingAddress.FirstName;
            ShippingAddressLastName.Text = model.ShippingAddress.LastName;
            ShippingAddressLine1.Text = model.ShippingAddress.Line1;
            ShippingAddressLine2.Text = model.ShippingAddress.Line2;
            ShippingAddressPostalCode.Text = model.ShippingAddress.PostalCode;
            ShippingAddressCity.Text = model.ShippingAddress.City;
            ShippingAddressCountryName.Text = Country.Get(model.ShippingAddress.CountryId).Name;

            OrderLinesRepeater.DataSource = model.OrderLines;
            OrderLinesRepeater.DataBind();

            SubTotal.Text = model.SubTotal;
            TaxTotal.Text = model.TaxTotal;
            DiscountTotal.Text = model.DiscountTotal;
            ShippingTotal.Text = model.ShippingTotal;
            PaymentTotal.Text = model.PaymentTotal;
            OrderTotal.Text = model.OrderTotal;
        }

        private AddressModel MapOrderAddress(OrderAddress orderAddress)
        {
            var addressDetails = new AddressModel();

            addressDetails.FirstName = orderAddress.FirstName;
            addressDetails.LastName = orderAddress.LastName;
            addressDetails.EmailAddress = orderAddress.EmailAddress;
            addressDetails.PhoneNumber = orderAddress.PhoneNumber;
            addressDetails.MobilePhoneNumber = orderAddress.MobilePhoneNumber;
            addressDetails.Line1 = orderAddress.Line1;
            addressDetails.Line2 = orderAddress.Line2;
            addressDetails.PostalCode = orderAddress.PostalCode;
            addressDetails.City = orderAddress.City;
            addressDetails.State = orderAddress.State;
            addressDetails.Attention = orderAddress.Attention;
            addressDetails.CompanyName = orderAddress.CompanyName;
            addressDetails.CountryId = orderAddress.Country != null ? orderAddress.Country.CountryId : -1;

            return addressDetails;
        }

        private PurchaseOrderModel MapOrder()
        {
            var basketModel = new PurchaseOrderModel();

            return basketModel;
        }

        protected void ConfirmAndContinueToPaymentBtn_OnClick(object sender, EventArgs e)
        {
            UCommerce.Api.TransactionLibrary.RequestPayments();
            Response.Redirect("/complete");
        }
    }
}