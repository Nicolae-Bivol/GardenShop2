using GardenShop2.Domain.Data;
using GardenShop2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GardenShop2.Web.Controllers
{
     public class OrdersController : Controller
     {
          private readonly ApplicationDbContext _context;

          public OrdersController()
          {
               _context = new ApplicationDbContext();
          }

          [HttpPost]
          public ActionResult PlaceOrder()
          {
               var username = Session["Username"] as string;
               var cart = Session["Cart"] as List<CartItem>;

               if (username == null || cart == null || !cart.Any())
                    return RedirectToAction("Index", "Home");

               var user = _context.Users.FirstOrDefault(u => u.Username == username);
               if (user == null)
                    return RedirectToAction("Index", "Home");

               var pendingOrder = new Order
               {
                    UserId = user.Id,
                    PlacedAt = DateTime.Now,
                    TotalAmount = cart.Sum(p => p.Price * p.Quantity),
                    OrderItems = cart.Select(p => new OrderItem
                    {
                         ProductId = p.ProductId,
                         ProductName = p.Name,
                         Quantity = p.Quantity,
                         UnitPrice = p.Price
                    }).ToList()
               };

               Session["PendingOrder"] = pendingOrder;
               return RedirectToAction("DeliveryDetails");
          }

          public ActionResult DeliveryDetails()
          {
               var order = Session["PendingOrder"] as Order;
               if (order == null)
                    return RedirectToAction("Index", "Home");

               return View();
          }

          [HttpPost]
          public ActionResult ConfirmDelivery(string ShippingAddress, string Phone, string Email, string PaymentMethod)
          {
               var username = Session["Username"] as string;
               var order = Session["PendingOrder"] as Order;

               if (username == null || order == null)
                    return RedirectToAction("Index", "Home");

               order.ShippingAddress = ShippingAddress;
               order.Phone = Phone;
               order.Email = Email;
               order.PaymentMethod = PaymentMethod;

               _context.Orders.Add(order);
               _context.SaveChanges();

               Session["Cart"] = null;
               Session["CartCount"] = 0;
               Session["PendingOrder"] = null;

               return RedirectToAction("MyOrders");
          }

          public ActionResult MyOrders()
          {
               var username = Session["Username"] as string;
               if (username == null)
                    return RedirectToAction("Login", "Autentification");

               var user = _context.Users.FirstOrDefault(u => u.Username == username);
               if (user == null)
                    return RedirectToAction("Index", "Home");

               var orders = _context.Orders
                   .Where(o => o.UserId == user.Id)
                   .OrderByDescending(o => o.PlacedAt)
                   .ToList();

               return View(orders);
          }
     }
}
