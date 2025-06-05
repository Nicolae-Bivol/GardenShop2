using System.Collections.Generic;
using GardenShop2.Domain.Model;

namespace GardenShop2.BusinessLogic.Services
{
     public interface IProductService
     {
          List<Product> GetAll();
          List<Product> GetByCategory(string category);
          Product GetById(int id);
          void Add(Product product);
          void Delete(int id);
     }
}