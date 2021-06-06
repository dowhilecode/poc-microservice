using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Model
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool InStock { get; set; }
        [JsonProperty("UnitPrice")]
        public int MRP { get; set; }
        [JsonProperty("categoryType")]
        public ProductCategory Category { get; set; }
    }

}
