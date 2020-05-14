using System;
using System.Linq;
using System.Web.UI.WebControls;
using UCommerce.Api;
using UCommerce.EntitiesV2;
using System.Collections;
using System.Collections.Generic;

namespace UCommerce.MasterClass.Pages
{
    public partial class Shipment : System.Web.UI.Page
    {
        protected int SelectedShipmentMethodId { get; set; }

        [Obsolete]
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                return;
            }
            var basket = TransactionLibrary.GetBasket().PurchaseOrder;
            var firstShipment = basket.Shipments.First();
            var shippingMethods = TransactionLibrary.GetShippingMethods(firstShipment.ShipmentAddress.Country);
            AvailableShipmentMethods.DataSource = shippingMethods;
            AvailableShipmentMethods.DataBind();
            /*if (IsPostBack)
            {
                return;
            }
            var shippingInformation = UCommerce.Api.TransactionLibrary.GetShipmentInformation();
            ICollection<UCommerce.EntitiesV2.ShippingMethod> availableShippingMethods = 
                UCommerce.Api.TransactionLibrary.GetShippingMethods(shippingInformation.Country);
            var selectedShippingMethod = UCommerce.Api.TransactionLibrary.GetShippingMethod();
            int selectedShippingMethodId = -1;
            if(selectedShippingMethod != null)
            {
                selectedShippingMethodId = selectedShippingMethod.ShippingMethodId;
            }
            AvailableShipmentMethods.DataSource = selectedShippingMethod;
            AvailableShipmentMethods.SelectedValue = selectedShippingMethodId.ToString();
            AvailableShipmentMethods.DataBind();
            */
        }

        protected void SaveShipmentAndGoToPaymentBtn_OnClick(object sender, EventArgs e)
        {
            var selectedShipmentMethodId = Int32.Parse(AvailableShipmentMethods.SelectedValue);
            UCommerce.Api.TransactionLibrary.CreateShipment(selectedShipmentMethodId, overwriteExisting: true);
            UCommerce.Api.TransactionLibrary.ExecuteBasketPipeline();
            Response.Redirect("/basket/payment");
        }
    }
}