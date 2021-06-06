using Newtonsoft.Json;
using ShopOnline.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ShopOnline.BAL
{
    public interface IOrderManager
    {
        List<Order> Orders { get; set; }
    }
    public class OrderManager : IOrderManager
    {
        public OrderManager()
        {
            if (Orders == null)
                Orders = new List<Order>();
        }
        public List<Order> Orders { get; set; }

    }
}
