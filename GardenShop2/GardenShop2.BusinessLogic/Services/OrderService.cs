using GardenShop2.Domain.Data;
using GardenShop2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GardenShop2.BusinessLogic.Services
{
     public class OrderService
     {
          private readonly ApplicationDbContext _context;

          public OrderService()
          {
               _context = new ApplicationDbContext();
          }

          public void PlaceOrder(int userId, List<CartItem> cartItems)
          {
               if (cartItems == null || !cartItems.Any())
                    throw new InvalidOperationException("Coșul este gol.");

               var order = new Order
               {
                    UserId = userId,
                    PlacedAt = DateTime.Now,
                    TotalAmount = cartItems.Sum(p => p.Price * p.Quantity),
                    OrderItems = cartItems.Select(item => new OrderItem
                    {
                         ProductId = item.ProductId,
                         ProductName = item.Name,
                         Quantity = item.Quantity,
                         UnitPrice = item.Price
                    }).ToList()
               };

               _context.Orders.Add(order);
               _context.SaveChanges();
          }

          public List<Order> GetOrdersForUser(int userId)
          {
               return _context.Orders
                   .Where(o => o.UserId == userId)
                   .OrderByDescending(o => o.PlacedAt)
                   .ToList();
          }
     }
}
