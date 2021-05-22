using ProductService.Model;
using ProductService.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProductService.DataAccess
{
    public interface IProductManager
    {
        IEnumerable<ProductBase> GetProducts();
        IEnumerable<string> GetCategories();
        ProductVM GetProduct(string prodId);
    }

    public class ProductManager: IProductManager
    {
        private static List<ProductBase> _products = null;
        public ProductManager()
        {
            _products = new List<ProductBase>();

            _products.Add(new Book() {
                Author = "Abc",
                BestSeller = true,
                CategoryType = CategoryType.Books,
                Description = "Power of subconcious mind",
                HasDiscount = false,
                InStock = true,
                IsActive = true,
                Name = "Power of subconcious mind",
                ProductID = "B001",
                Rating = 5,
                UnitPrice = 999
            });

            _products.Add(new Electronics()
            {
                CategoryType = CategoryType.Electronics,
                Description = "Air conditioner",
                ElectronicType = ElectronicType.Appliances,
                HasDiscount = false,
                InStock = true,
                IsActive = true,
                Name = "Air conditioner",
                ProductID = "E001",
                Rating = 3,
                EnergySaving = 4,
                UnitPrice = 45000
            });

            _products.Add(new Electronics()
            {
                CategoryType = CategoryType.Electronics,
                Description = "Lenevo Thinkpad Office use laptop",
                ElectronicType = ElectronicType.Computers,
                HasDiscount = false,
                InStock = true,
                IsActive = true,
                Name = "Lenevo Laptop",
                ProductID = "E002",
                Rating = 4,
                UnitPrice = 45000
            });

            _products.Add(new Electronics()
            {
                CategoryType = CategoryType.Electronics,
                Description = "Best android mobile",
                ElectronicType = ElectronicType.Mobile,
                HasDiscount = false,
                InStock = true,
                IsActive = true,
                Name = "Samsung Android",
                ProductID = "E003",
                Rating = 4,
                UnitPrice = 17999
            });

            _products.Add(new Clothes()
            {
                CategoryType = CategoryType.Clothes,
                Description = "Best for summer",
                HasDiscount = false,
                InStock = true,
                IsActive = true,
                Name = "Shirt",
                ProductID = "C001",
                Rating = 4,
                UnitPrice = 1500,
                Size = ClothSize.M,
                WearBy = ClothesFor.Men
            });
        }

        public IEnumerable<ProductBase> GetProducts()
        {
            return _products;
        }

        public IEnumerable<string> GetCategories()
        {
            return new string[] { CategoryType.Books.ToString(), CategoryType.Clothes.ToString(), CategoryType.Electronics.ToString()};
        }

        public ProductVM GetProduct(string prodId)
        {
            var prod = _products.FirstOrDefault(p => p.ProductID == prodId);
            if (prod == null)
                return null;

            return new ProductVM
            {
                CategoryType = prod.CategoryType,
                Description = prod.Description,
                HasDiscount = prod.HasDiscount,
                InStock = prod.InStock,
                Name = prod.Name,
                ProductID = prod.ProductID,
                Rating = prod.Rating,
                UnitPrice = prod.UnitPrice
            };
        }
    }
}
