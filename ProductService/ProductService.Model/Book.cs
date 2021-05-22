using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Model
{
    public class Book:ProductBase
    {
        public string Author { get; set; }
        public bool BestSeller { get; set; }
    }
}
