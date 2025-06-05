using System.Collections.Generic;
using System.Linq;
using GardenShop2.Domain.Model;

namespace GardenShop2.BusinessLogic.Services
{
     public class ProductService : IProductService
     {
          private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Apple Tree", Category = "Trees", Description = "Green apple tree", ImageUrl = "/img/AppleTree.png", Price = 25 },
            new Product { Id = 2, Name = "Rose", Category = "Flowers", Description = "Red rose", ImageUrl = "/img/Rose.png", Price = 10 },
            new Product { Id = 3, Name = "Shovel", Category = "Tools", Description = "Strong metal shovel", ImageUrl = "/img/shovel.png", Price = 15 }
        };

          public List<Product> GetAll() => _products;

          public List<Product> GetByCategory(string category)
          {
               return _products
                   .Where(p => p.Category != null && p.Category.ToLower() == category.ToLower())
                   .ToList();
          }

          public Product GetById(int id) =>
              _products.FirstOrDefault(p => p.Id == id);

          public void Add(Product product)
          {
               product.Id = _products.Max(p => p.Id) + 1;
               _products.Add(product);
          }

          public void Delete(int id)
          {
               var item = GetById(id);
               if (item != null)
                    _products.Remove(item);
          }
     }
}