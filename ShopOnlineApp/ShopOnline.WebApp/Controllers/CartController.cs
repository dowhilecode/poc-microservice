using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.BAL;
using ShopOnline.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopOnline.UI.Models;
using Microsoft.Extensions.Options;
using BuildingBlock.Messaging.Publisher;

namespace ShopOnline.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartManager _cartMgr;
        private readonly IOrderManager _orderManager;
        private readonly IOptions<MessagingOptions> _options;
        public CartController(ICartManager cartManager
            ,IOrderManager orderManager
            ,IOptions<MessagingOptions> msgOptoin)
        {
            _cartMgr = cartManager;
            _orderManager = orderManager; 
            _options = msgOptoin;
        }

        // GET: List the items of order
        public ActionResult Index()
        {
            Random r = new Random();
            int total = _cartMgr.CartProduct.Sum(s => s.MRP);
            string OrderId = "O" + r.Next(1000, 9999);
            string UserId = "U101"; // Todo: Get UserId from loggedIn user

            // Prepare Order
            Order order = new Order();
            if (_cartMgr.CartProduct != null && _cartMgr.CartProduct.Count() > 0)
            {
                order.OrderReferenceNumber = OrderId + UserId;
                order.OrderId = OrderId;
                order.TotalPrice = total;
                order.UserId = UserId;
                order.DiscountApplied = 0;
                order.NetPrice = total - 0;
                order.CreatedDate = DateTime.Now;
                order.Items = GetOrderItem(_cartMgr.CartProduct);
            }

            return View(order);
        }

        private List<Item> GetOrderItem(IEnumerable<Product> orderList)
        {
            List<Item> items = new List<Item>();
            foreach(var o in orderList)
            {
                items.Add(new Item
                {
                    Price = o.MRP,
                    ProductId = o.ProductId,
                    ProductName = o.Name,
                    Qty = 1
                });
            }
            return items;
        }

        [HttpPost]
        public ActionResult PlaceOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return RedirectToAction(nameof(Index));
            }

            order.CreatedDate = DateTime.Now;
            order.Items = new List<Item>();
            order.Items = GetOrderItem(_cartMgr.CartProduct);
            order.Status = "PaymentPending";
            
            // Todo: Send order for Payment Approval on queue
            bool sent = SendOrderToPaymentApprovalQueue(order);

            // Delete Current order from buckect
            if (sent)
            {
                _orderManager.Orders.Add(order);
                _cartMgr.CartProduct.Clear();
            }
            return RedirectToAction(nameof(Index), "Home");
        }

        private bool SendOrderToPaymentApprovalQueue(Order order)
        {
            var orderJson = JsonConvert.SerializeObject(order);
            var orderInBytes = System.Text.Encoding.UTF8.GetBytes(orderJson);

            IPublisher publish = new Publisher();
            publish.HostName = _options.Value.Hostname;
            publish.QueueName = _options.Value.OrderQueue;
            publish.UserName = _options.Value.UserName;
            publish.Password = _options.Value.Password;

            try
            {
                publish.Send(orderJson);
            }
            catch (Exception ex)
            {
                //return Ok($"{ex.Message}  | inner exp: {ex.InnerException}");
                return false;
            }

            return true;
        }

        [HttpPost]
        public void Create()
        {

        }
    }
}
