using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Model
{
    public class Clothes:ProductBase
    {
        public ClothSize Size { get; set; }
        public ClothesFor WearBy { get; set; }
    }
}
