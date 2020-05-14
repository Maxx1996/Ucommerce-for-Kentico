using System.Collections.Generic;

namespace UCommerce.MasterClass.Models
{
    public class CategoryProductModel
    {
        public CategoryProductModel()
        {
            Products = new List<ProductModel>();
        }
        public string Url { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public IList<ProductModel> Products { get; set; }
    }
}