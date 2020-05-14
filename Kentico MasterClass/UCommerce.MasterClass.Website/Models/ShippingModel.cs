using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace UCommerce.MasterClass.Models
{
    public class ShippingModel
    {
        public ShippingModel()
        {
            AvailableShippingMethods = new List<ListItem>();
        }

        public IList<ListItem> AvailableShippingMethods { get; set; }

        public int SelectedShippingMethodId { get; set; }
    }
}