using UCommerce.MasterClass.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UCommerce.Extensions;

namespace UCommerce.MasterClass.UserControls
{
    public partial class CategoryNavigation : System.Web.UI.UserControl
    {
        protected List<CategoryModel> mappedCategories;

        protected void Page_Load(object sender, EventArgs e)
        {
            var categories = UCommerce.Api.CatalogLibrary.GetRootCategories();
            var mappedCategories = MapCategories(categories);
            //List<CategoryModel> mappedCategories = new List<CategoryModel>();
            BuildCategoryMenu(mappedCategories);
        }

        private List<CategoryModel> MapCategories(ICollection<UCommerce.EntitiesV2.Category> categoriesToMap)
        {
            var categories = new List<CategoryModel>();
            foreach(var category in categoriesToMap)
            {
                var categoryModel = new CategoryModel();
                categoryModel.Name = category.DisplayName();
                categoryModel.Url = $"/category?category={category.CategoryId}";
                //UCommerce.Api.CatalogLibrary.GetNiceUrlForCategory();
                categoryModel.Categories = MapCategories(UCommerce.Api.CatalogLibrary.GetCategories(category));
                categories.Add(categoryModel);
            }
            return categories;

        }

        private void BuildCategoryMenu(List<CategoryModel> categories)
        {
            foreach (var currentCategory in categories)
            {
                CategoryNavigationDiv.Controls.Add(RecursiveMenu(currentCategory));
            }
        }

        private HtmlGenericControl RecursiveMenu(CategoryModel currentCategory)
        {
            var ulControl = new System.Web.UI.HtmlControls.HtmlGenericControl("ul");
            ulControl.Attributes.Add("class", "nav nav-list");

            var liControl = new System.Web.UI.HtmlControls.HtmlGenericControl("li");
            liControl.Attributes.Add("class", "nav-item");

            var link = new HyperLink();
            link.NavigateUrl = currentCategory.Url;
            link.Attributes.Add("class", "catnav");
            link.Text = currentCategory.Name;

            ulControl.Controls.Add(liControl);
            liControl.Controls.Add(link);

            foreach (var category in currentCategory.Categories)
            {
                liControl.Controls.Add(RecursiveMenu(category));
            }

            return ulControl;
        }
    }
}
