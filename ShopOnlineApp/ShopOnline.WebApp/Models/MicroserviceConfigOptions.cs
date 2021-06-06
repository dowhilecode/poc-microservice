using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.UI.Models
{
    sealed public class MicroserviceConfigOptions
    {
        public const string ProductCatalogService = "MicroserviceConfig:ProductCatalogService";
        public const string DiscountService = "MicroserviceConfig:DiscountService";
        public const string OrderService = "MicroserviceConfig:OrderService";
        public const string UserService = "MicroserviceConfig:UserService";
    }

    public class ProductCatalogServiceOption
    {
        public string BaseUrl { get; set; }
        public string GetAllProduct { get; set; }
        public string GetProductDetail { get; set; }
    }

    public class DiscountServiceOption
    {
        public string BaseUrl { get; set; }
        public string GetDiscount { get; set; }
    }
}
