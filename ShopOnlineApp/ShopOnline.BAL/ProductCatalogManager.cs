using ShopOnline.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.BAL
{
    public interface IProductCatalogManager
    {
        public string Url { get; set; }
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> ProductDetail();
    }
    public class ProductCatalogManager : BaseManager, IProductCatalogManager
    {
        public ProductCatalogManager()
        {
        }

        public string Url { get; set; }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            GetUrl = Url;
            var data = await HttpGet();
            if (data == null)
                return null;

            if (data.Result == null)
                return null;

            var prodData = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Product>>(data.Result);

            return prodData;
        }

        public async Task<Product> ProductDetail()
        {
            GetUrl = Url;
            var data = await HttpGet();
            if (data == null)
                return null;

            if (data.Result == null)
                return null;

            var product = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(data.Result);

            return product;
        }
    }
}
