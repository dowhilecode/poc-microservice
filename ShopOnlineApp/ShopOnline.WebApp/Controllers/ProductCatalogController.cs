using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ShopOnline.BAL;
using ShopOnline.Model;
using ShopOnline.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.UI.Controllers
{
    public class ProductCatalogController : Controller
    {
        private readonly IProductCatalogManager _pdMgr;
        private readonly ICartManager _cartMgr;
        private readonly IOptions<ProductCatalogServiceOption> _options;
        public ProductCatalogController(IProductCatalogManager pdMgr,ICartManager cartManager
            ,IOptions<ProductCatalogServiceOption> pcServiceOption)
        {

            _pdMgr = pdMgr;
            _cartMgr = cartManager;
            _options = pcServiceOption;
        }

        // GET: All Products
        public async Task<ActionResult> Index()
        {
            _pdMgr.Url = _options.Value.BaseUrl + _options.Value.GetAllProduct;
            var products = await _pdMgr.GetProducts();
            return View(products);
        }

        // GET: Product/Details/5
        public async Task<ActionResult> Detail(string id)
        {
            _pdMgr.Url = _options.Value.BaseUrl + string.Format(_options.Value.GetProductDetail,id);
            var product = await _pdMgr.ProductDetail();
            return View(product);
        }

        // GET: Add product for order
        [HttpPost]
        public async Task AddToOrder([FromBody] string productId)
        {
            _pdMgr.Url = _options.Value.BaseUrl + _options.Value.GetAllProduct;
            var prodCollection = await _pdMgr.GetProducts();
            var prod = prodCollection.FirstOrDefault(p => p.ProductId == productId);
            _cartMgr.CartProduct.Add(prod);
        }

        // Check Out
        public ActionResult CheckOut()
        {
            return RedirectToAction("Index", "Cart");
        }
    }
}
