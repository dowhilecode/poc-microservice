using ShopOnline.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.BAL
{
    public interface IPaymentManager
    {
        IEnumerable<OrderPayment> GetOrdersForPaymentApproval();
        void Approve(string orderRefernce, bool isApproved);
    }

    public class PaymentManager : BaseManager, IPaymentManager
    {
        private List<OrderPayment> orderPaymentList = new List<OrderPayment>();
        public void Approve(string orderRefernce, bool isApproved)
        {
            var order = orderPaymentList.FirstOrDefault(o => o.OrderReferenceNumber == orderRefernce);
            if(order == null)
            {
                return;
            }

            PaymentResponse pr = new PaymentResponse();
            pr.OrderDate = order.OrderDate;
            pr.OrderAmount = order.OrderAmount;
            pr.OrderId = order.OrderId;
            pr.OrderReferenceNumber = order.OrderReferenceNumber;
            pr.UserId = order.UserId;
            pr.PaymentDate = DateTime.Now;
            pr.PaymentSuccess = isApproved;

            // Prepare the bytes to travel
            var paymentJson = Newtonsoft.Json.JsonConvert.SerializeObject(pr);
            var paymentResponseBytes = System.Text.Encoding.UTF8.GetBytes(paymentJson);

            // Todo: Apply Logic to send payment notification to queue

        }

        public IEnumerable<OrderPayment> GetOrdersForPaymentApproval()
        {
            // Todo: Logic to fetch data from Queue


            return orderPaymentList;
        }
    }
}
