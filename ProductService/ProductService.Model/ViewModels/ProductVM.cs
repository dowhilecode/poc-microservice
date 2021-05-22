using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Model.ViewModels
{
    public class ProductVM
    {
        public string ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int Rating { get; set; }
        public bool InStock { get; set; }
        public bool HasDiscount { get; set; }
        public CategoryType CategoryType { get; set; }
    }
}
