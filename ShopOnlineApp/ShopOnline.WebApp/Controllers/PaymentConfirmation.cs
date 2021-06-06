using Microsoft.AspNetCore.Mvc;
using ShopOnline.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.UI.Controllers
{
    public class PaymentConfirmation : Controller
    {
        private readonly IPaymentManager paymentManager;

        public PaymentConfirmation(IPaymentManager pMgr)
        {
            paymentManager = pMgr;
        }

        public IActionResult Index()
        {
            var allOrders = paymentManager.GetOrdersForPaymentApproval();
            return View(allOrders);
        }
    }
}
