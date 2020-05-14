using System;
using System.Linq;
using System.Web.UI.WebControls;
using UCommerce.Api;
using UCommerce.EntitiesV2;

namespace UCommerce.MasterClass.Pages
{
    public partial class Payment : System.Web.UI.Page
    {
        protected int SelectedPaymentMethodId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            PurchaseOrder basket = TransactionLibrary.GetBasket(false).PurchaseOrder;

            Country shippingCountry = TransactionLibrary.GetShippingInformation().Country;

            var availablePaymentMethods = TransactionLibrary.GetPaymentMethods(shippingCountry);

            var existingPayment = basket.Payments.FirstOrDefault();

            var selectedPaymentMethodId = existingPayment != null
                ? existingPayment.PaymentMethod.PaymentMethodId
                : -1;

            foreach (var availablePaymentMethod in availablePaymentMethods)
            {
                var option = new ListItem();
                option.Text = availablePaymentMethod.Name;
                option.Value = availablePaymentMethod.PaymentMethodId.ToString();
                option.Selected = availablePaymentMethod.PaymentMethodId == selectedPaymentMethodId;

                AvailablePaymentMethods.Items.Add(option);
            }
        }

        protected void SavePaymentAndGoToPreviewBtn_OnClick(object sender, EventArgs e)
        {
            var selectedPaymentMethodId = Int32.Parse(AvailablePaymentMethods.SelectedValue);

            TransactionLibrary.CreatePayment(
                paymentMethodId: selectedPaymentMethodId,
                requestPayment: false,
                amount: -1,
                overwriteExisting: true);

            TransactionLibrary.ExecuteBasketPipeline();

            Response.Redirect("/preview");
        }
    }
}