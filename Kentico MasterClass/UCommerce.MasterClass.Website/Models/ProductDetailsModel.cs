using System.Collections.Generic;
using UCommerce.Api;

namespace UCommerce.MasterClass.Models
{
    public class ProductDetailsModel
    {
        public ProductDetailsModel()
        {
            Variants = new List<ProductDetailsModel>();
        }
        public bool IsVariant { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string LongDescription { get; set; }

        public IList<ProductDetailsModel> Variants { get; set; }

        public string Sku { get; set; }

        public string VariantSku { get; set; }

        public PriceCalculation PriceCalculation { get; set; }
    }
}