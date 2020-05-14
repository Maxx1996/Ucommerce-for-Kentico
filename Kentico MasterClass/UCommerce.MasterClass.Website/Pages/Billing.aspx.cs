using System;
using System.Linq;
using System.Web.UI.WebControls;
using UCommerce.MasterClass.Models;
using UCommerce.Api;

namespace UCommerce.MasterClass.Pages
{
    public partial class Billing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            var addressDetails = new AddressDetailsModel();

            var shippingInformation = TransactionLibrary.GetShippingInformation();
            var billingInformation = TransactionLibrary.GetBillingInformation();

            BillingAddressFirstName.Text = billingInformation.FirstName;
            BillingAddressLastName.Text = billingInformation.LastName;
            BillingAddressEmailAddress.Text = billingInformation.EmailAddress;
            BillingAddressPhoneNumber.Text = billingInformation.PhoneNumber;
            BillingAddressMobilePhoneNumber.Text = billingInformation.MobilePhoneNumber;
            BillingAddressLine1.Text = billingInformation.Line1;
            BillingAddressLine2.Text = billingInformation.Line2;
            BillingAddressPostalCode.Text = billingInformation.PostalCode;
            BillingAddressCity.Text = billingInformation.City;
            BillingAddressAttention.Text = billingInformation.Attention;
            BillingAddressCompanyName.Text = billingInformation.CompanyName;
            var billingAddressCountryId = billingInformation.Country != null ? billingInformation.Country.CountryId : -1;

            ShippingAddressFirstName.Text = shippingInformation.FirstName;
            ShippingAddressLastName.Text = shippingInformation.LastName;
            ShippingAddressEmailAddress.Text = shippingInformation.EmailAddress;
            ShippingAddressPhoneNumber.Text = shippingInformation.PhoneNumber;
            ShippingAddressMobilePhoneNumber.Text = shippingInformation.MobilePhoneNumber;
            ShippingAddressLine1.Text = shippingInformation.Line1;
            ShippingAddressLine2.Text = shippingInformation.Line2;
            ShippingAddressPostalCode.Text = shippingInformation.PostalCode;
            ShippingAddressCity.Text = shippingInformation.City;
            ShippingAddressAttention.Text = shippingInformation.Attention;
            ShippingAddressCompanyName.Text = shippingInformation.CompanyName;
            var shippingAddressCountryId = shippingInformation.Country != null ? shippingInformation.Country.CountryId : -1;

            addressDetails.AvailableCountries = UCommerce.EntitiesV2.Country.All().ToList().Select(x => new ListItem() { Text = x.Name, Value = x.CountryId.ToString() }).ToList();

            BillingAddressCountryDropDown.ClearSelection();
            ShippingAddressCountryDropDown.ClearSelection();

            foreach (var country in addressDetails.AvailableCountries)
            {
                var shippingCountryIsSelected = shippingAddressCountryId.ToString() == country.Value;
                var billingCountryIsSelected = billingAddressCountryId.ToString() == country.Value;
                ShippingAddressCountryDropDown.Items.Add(new ListItem { Text = country.Text, Value = country.Value, Selected = shippingCountryIsSelected });
                BillingAddressCountryDropDown.Items.Add(new ListItem { Text = country.Text, Value = country.Value, Selected = billingCountryIsSelected });
            }
        }

        protected void SaveAndGoToShippingBtn_OnClick(object sender, EventArgs e)
        {
            TransactionLibrary.EditBillingInformation(
                BillingAddressFirstName.Text,
                BillingAddressLastName.Text,
                BillingAddressEmailAddress.Text,
                BillingAddressPhoneNumber.Text,
                BillingAddressMobilePhoneNumber.Text,
                BillingAddressCompanyName.Text,
                BillingAddressLine1.Text,
                BillingAddressLine2.Text,
                BillingAddressPostalCode.Text,
                BillingAddressCity.Text,
                string.Empty,
                BillingAddressAttention.Text,
                Int32.Parse(BillingAddressCountryDropDown.SelectedValue));

            TransactionLibrary.EditShippingInformation(
                ShippingAddressFirstName.Text,
                ShippingAddressLastName.Text,
                ShippingAddressEmailAddress.Text,
                ShippingAddressPhoneNumber.Text,
                ShippingAddressMobilePhoneNumber.Text,
                ShippingAddressCompanyName.Text,
                ShippingAddressLine1.Text,
                ShippingAddressLine2.Text,
                ShippingAddressPostalCode.Text,
                ShippingAddressCity.Text,
                string.Empty,
                ShippingAddressAttention.Text,
                Int32.Parse(ShippingAddressCountryDropDown.SelectedValue));

            TransactionLibrary.ExecuteBasketPipeline();

            Response.Redirect("/basket/address/shipment");
        }
    }
}