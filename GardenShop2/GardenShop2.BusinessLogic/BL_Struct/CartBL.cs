using GardenShop2.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace GardenShop2.BusinessLogic.BL_Struct
{
     public class CartBL
     {
          public void AddToCart(List<CartItem> cart, Product product)
          {
               var existingItem = cart.FirstOrDefault(p => p.ProductId == product.Id);
               if (existingItem != null)
               {
                    existingItem.Quantity++;
               }
               else
               {
                    cart.Add(new CartItem
                    {
                         ProductId = product.Id,
                         Name = product.Name,
                         ImageUrl = product.ImageUrl,
                         Price = product.Price,
                         Quantity = 1
                    });
               }
          }
     }
}
