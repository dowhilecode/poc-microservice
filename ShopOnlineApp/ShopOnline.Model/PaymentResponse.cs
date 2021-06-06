using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Model
{
    public class PaymentResponse
    {
        public string OrderReferenceNumber { get; set; }
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public int OrderAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool PaymentSuccess { get; set; }
    }
}
