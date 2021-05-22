using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Model
{
    public abstract class ProductBase
    {
        public string ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int Rating { get; set; }
        public bool InStock { get; set; }
        public bool HasDiscount { get; set; }
        public bool IsActive { get; set; }

        public CategoryType CategoryType { get; set; }

        public virtual int GetTotal(int TotalQty)
        {
            return TotalQty * UnitPrice;
        }
    }
}
