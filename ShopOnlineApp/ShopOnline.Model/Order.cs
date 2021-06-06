using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Model
{
    public class Order
    {
        public string OrderReferenceNumber { get; set; }
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public int TotalPrice { get; set; }
        public int DiscountApplied { get; set; }
        public int NetPrice { get; set; }
        public DateTime? CreatedDate { get; set; }
        public List<Item> Items { get; set; }
        public string Status { get; set; }
    }
}
