using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Model
{
    public class Catalog
    {
        public IEnumerable<ProductBase> ProductCatalog { get; set; }
    }
}
