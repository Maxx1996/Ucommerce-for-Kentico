using System;
using UCommerce.MasterClass.Models;
using UCommerce.Extensions;
using UCommerce.EntitiesV2;
using UCommerce.Runtime;
using UCommerce.Api;


namespace UCommerce.MasterClass.Pages
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductDetailsModel model = new ProductDetailsModel();
            var currentProduct = UCommerce.Runtime.SiteContext.Current.CatalogContext.CurrentProduct;
            model = MapProduct(currentProduct);

            BuildPage(model);
        }

        private ProductDetailsModel MapProduct(UCommerce.EntitiesV2.Product currentProduct)
        {
            var model = new ProductDetailsModel();
            model.Sku = currentProduct.Sku;
            model.Name = currentProduct.DisplayName();
            model.LongDescription = currentProduct.LongDescription();
            model.PriceCalculation = UCommerce.Api.CatalogLibrary.CalculatePrice(currentProduct);
            model.VariantSku = currentProduct.VariantSku;
            model.IsVariant = currentProduct.IsVariant;

            foreach (EntitiesV2.Product currentProductVarient in currentProduct.Variants)
            {
                model.Variants.Add(MapProduct(currentProductVarient));
            }

            return model;
        }

        private void BuildPage(ProductDetailsModel model)
        {
            ProductName.Text = model.Name;
            ShowPrice.Visible = (model.PriceCalculation != null);
            if (model.PriceCalculation != null)
            {
                YourPriceAmount.Text = model.PriceCalculation.YourPrice.Amount.ToString();
            }

            HiddenSku.Value = model.Sku;
            LongDescription.Text = model.LongDescription;
            VariantDropDownList.DataSource = model.Variants;
            VariantDropDownList.DataBind();
        }

        protected void AddToBasketButton_OnClick(object sender, EventArgs e)
        {
            UCommerce.Api.TransactionLibrary.AddToBasket(1, HiddenSku.Value, VariantDropDownList.SelectedValue);
            //VariantDropDownList.SelectedValue
        }
    }
}