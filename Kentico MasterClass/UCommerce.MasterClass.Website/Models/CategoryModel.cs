using System.Collections.Generic;

namespace UCommerce.MasterClass.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            Categories = new List<CategoryModel>();
        }
        public string Url { get; set; }

        public string Name { get; set; }

        public IList<CategoryModel> Categories { get; set; }
    }
}