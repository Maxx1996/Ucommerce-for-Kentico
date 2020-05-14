using System.Collections.Generic;
using UCommerce.Api;

namespace UCommerce.MasterClass.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            Variants = new List<ProductModel>();
        }
        public bool IsVariant { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string LongDescription { get; set; }

        public IList<ProductModel> Variants { get; set; }

        public string Sku { get; set; }

        public string VariantSku { get; set; }

        public PriceCalculation PriceCalculation { get; set; }
        public string MediaId { get; set; }
    }
}