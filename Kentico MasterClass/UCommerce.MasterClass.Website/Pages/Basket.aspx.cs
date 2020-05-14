using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using UCommerce.MasterClass.Models;
using UCommerce.Api;
using UCommerce.EntitiesV2;
using UCommerce.Extensions;

namespace UCommerce.MasterClass.Pages
{
    public partial class Basket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            var basketModel = new PurchaseOrderModel();
            bool check = UCommerce.Api.TransactionLibrary.HasBasket();
            if (check == false)
            {
                Response.Redirect("/frontPage");
            }
            UCommerce.EntitiesV2.PurchaseOrder basket = UCommerce.Api.TransactionLibrary.GetBasket(false).PurchaseOrder;
            basketModel = MapBasket(basket);
            BuildPage(basketModel);

        }

        protected void UpdateBasketButton_OnClick(object sender, EventArgs e)
        {
          foreach(RepeaterItem item in OrderLinesRepeater.Items)
            {
                var orderlineIdHidden = item.FindControl("OrderLineId") as HiddenField;
                int orderlineId = Convert.ToInt32(orderlineIdHidden.Value);
                var quantityTextBox = item.FindControl("OrderLineQuantity") as TextBox;
                int quantity = Convert.ToInt32(quantityTextBox.Text);
                UCommerce.Api.TransactionLibrary.UpdateLineItem(orderlineId, quantity);
            }
            UCommerce.Api.TransactionLibrary.ExecuteBasketPipeline();
        }

        protected void RemoveOrderLineButton_OnClick(object sender, EventArgs e)
        {
          var orderlineId = Convert.ToInt32((sender as Button).Attributes["Value"]);
            UCommerce.Api.TransactionLibrary.UpdateLineItem(orderlineId, 0);
            UCommerce.Api.TransactionLibrary.ExecuteBasketPipeline();
        }

        protected void ContinueToBillingBtn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/basket/address");

        }

        private void BuildPage(PurchaseOrderModel basketModel)
        {
            OrderLinesRepeater.DataSource = basketModel.OrderLines;
            OrderLinesRepeater.DataBind();

            OrderTotal.Text = basketModel.OrderTotal;
        }

        private PurchaseOrderModel MapBasket(PurchaseOrder basket)
        {

            var basketModel = new PurchaseOrderModel();
            UCommerce.EntitiesV2.Currency billingCurrency = basket.BillingCurrency;
            basketModel.OrderTotal = new Money(basket.OrderTotal.GetValueOrDefault(), billingCurrency).ToString();
            foreach(OrderLine basketOrderLine in basket.OrderLines)
            {
                var orderlineModel = new OrderlineModel();
                orderlineModel.Quantity = basketOrderLine.Quantity;
                orderlineModel.ProductName = basketOrderLine.ProductName;
                orderlineModel.Sku = basketOrderLine.Sku;
                orderlineModel.VariantSku = basketOrderLine.VariantSku;
                orderlineModel.Total = new Money(basketOrderLine.Total.GetValueOrDefault(), billingCurrency).ToString();
                orderlineModel.OrderLineId = basketOrderLine.OrderLineId;
                basketModel.OrderLines.Add(orderlineModel);

            }
            return basketModel;
        }
    }
}