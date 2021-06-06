using ShopOnline.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.BAL
{
    public interface ICartManager
    {
        List<Product> CartProduct { get; set; }
        Task<bool> AddToCart(Product product);
        void RemoveFromCart(string productId, Product product);
    }

    public class CartManager : BaseManager, ICartManager
    {
        public List<Product> CartProduct { get; set; }
        
        public CartManager()
        {
            if (CartProduct == null)
                CartProduct = new List<Product>();
        }

        public async Task<bool> AddToCart(Product product)
        {
            CartProduct.Add(product);
            return await Task.FromResult<bool>(true);
        }

        public IEnumerable<Product> GetOrderList()
        {
            return CartProduct;
        }

        public void RemoveFromCart(string productId, Product product)
        {
            var prod = CartProduct.FirstOrDefault(o => o.ProductId == productId);
            if(prod != null)
            {
                CartProduct.RemoveAll(o => o.ProductId == prod.ProductId);
            }
        }
    }
}
