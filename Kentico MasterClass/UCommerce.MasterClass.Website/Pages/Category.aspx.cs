using System;
using System.Collections.Generic;
using UCommerce.Extensions;
using UCommerce.MasterClass.Models;
using UCommerce.EntitiesV2;
using UCommerce.Runtime;
using UCommerce.Api;



namespace UCommerce.MasterClass.Pages
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var model = new CategoryProductModel();
            var currentcategory = SiteContext.Current.CatalogContext.CurrentCategory;
            model.CategoryName = currentcategory.DisplayName();
            model.CategoryDescription = currentcategory.Description();
            model.Products = MapProducts(UCommerce.Api.CatalogLibrary.GetProducts(currentcategory));
            BuildPage(model);
        }

        private void BuildPage(CategoryProductModel model)
        {
            CategoryName.Text = model.CategoryName;
            CategoryDescription.Text = model.CategoryDescription;
            Products.DataSource = model.Products;
            Products.DataBind();
        }

        private IList<ProductModel> MapProducts(ICollection<UCommerce.EntitiesV2.Product> productsInCategory)
        {
            IList<ProductModel> productViews = new List<ProductModel>();
            foreach (var product in productsInCategory)
            {
                var productModel = new ProductModel();
                productModel.Sku = product.Sku;
                productModel.Name = product.DisplayName();
                productModel.Url = $"/product?product={product.ProductId}";
                productModel.PriceCalculation = UCommerce.Api.CatalogLibrary.CalculatePrice(product);
                productViews.Add(productModel);

            }
            return productViews;
        }
    }
}