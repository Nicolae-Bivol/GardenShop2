using GardenShop2.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using GardenShop2.Domain.Data;

namespace GardenShop2.BusinessLogic.BL_Struct
{
     public class ProductBL
     {
          private readonly ApplicationDbContext _context;

          public ProductBL()
          {
               _context = new ApplicationDbContext();
          }

          public List<Product> GetByCategory(string categoryName)
          {
               return _context.Products
                   .Where(p => p.Category == categoryName)
                   .ToList();
          }

          public Product GetById(int id)
          {
               return _context.Products.FirstOrDefault(p => p.Id == id);
          }
          public List<Product> GetAll()
          {
               return _context.Products.ToList();
          }
     }
}
