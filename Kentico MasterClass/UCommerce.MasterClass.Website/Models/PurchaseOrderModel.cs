using System.Collections.Generic;

namespace UCommerce.MasterClass.Models
{
    public class PurchaseOrderModel
    {
        public PurchaseOrderModel()
        {
            OrderLines = new List<OrderlineModel>();
        }

        public ShippingModel ShippingViewModel { get; set; }

        public AddressModel BillingAddress { get; set; }

        public AddressModel ShippingAddress { get; set; }

        public IList<OrderlineModel> OrderLines { get; set; }

        public string OrderTotal { get; set; }

        public string SubTotal { get; set; }

        public string TaxTotal { get; set; }

        public string DiscountTotal { get; set; }

        public string ShippingTotal { get; set; }

        public string PaymentTotal { get; set; }
    }
}