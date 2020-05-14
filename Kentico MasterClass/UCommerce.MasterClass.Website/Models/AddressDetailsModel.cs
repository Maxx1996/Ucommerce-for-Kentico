using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace UCommerce.MasterClass.Models
{
    public class AddressDetailsModel
    {
        public AddressDetailsModel()
        {
            ShippingAddress = new AddressModel();
            BillingAddress = new AddressModel();
            AvailableCountries = new List<ListItem>();
        }
        public AddressModel ShippingAddress { get; set; }

        public AddressModel BillingAddress { get; set; }

        public IList<ListItem> AvailableCountries { get; set; }
    }
}