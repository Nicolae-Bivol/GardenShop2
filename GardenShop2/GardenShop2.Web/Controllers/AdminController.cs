using GardenShop2.Domain.Data;
using GardenShop2.Domain.Model;
using System.Linq;
using System.Web.Mvc;

namespace GardenShop.Controllers
{
     public class AdminController : Controller
     {
          private readonly ApplicationDbContext _context = new ApplicationDbContext();

          public ActionResult Panel()
          {
               if (Session["Role"]?.ToString() != "2")
                    return RedirectToAction("AccessDenied", "Account");

               return View();
          }

          // ✅ Afișează lista produselor
          public ActionResult ProductList()
          {
               if (Session["Role"]?.ToString() != "2")
                    return RedirectToAction("AccessDenied", "Account");

               var products = _context.Products.ToList();
               return View(products);
          }

          // ❌ Ștergere produs
          public ActionResult DeleteProduct(int id)
          {
               if (Session["Role"]?.ToString() != "2")
                    return RedirectToAction("AccessDenied", "Account");

               var product = _context.Products.Find(id);
               if (product != null)
               {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
               }

               return RedirectToAction("ProductList");
          }

          // ➕ Adăugare produs (GET)
          public ActionResult AddProduct()
          {
               if (Session["Role"]?.ToString() != "2")
                    return RedirectToAction("AccessDenied", "Account");

               return View();
          }

          // ➕ Adăugare produs (POST)
          [HttpPost]
          public ActionResult AddProduct(Product product)
          {
               if (Session["Role"]?.ToString() != "2")
                    return RedirectToAction("AccessDenied", "Account");

               if (ModelState.IsValid)
               {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return RedirectToAction("ProductList");
               }

               return View(product);
          }
          public ActionResult Orders()
          {
               if (Session["Role"]?.ToString() != "2")
                    return RedirectToAction("AccessDenied", "Account");

               var orders = _context.Orders
                   .Include("User")
                   .Include("OrderItems.Product")
                   .ToList();

               var result = orders.Select(o => new OrderDisplayViewModel
               {
                    OrderId = o.Id,
                    Username = o.User.Username,
                    Items = o.OrderItems.Select(oi => new OrderItemDisplay
                    {
                         ProductName = oi.Product.Name,
                         Quantity = oi.Quantity,
                         PricePerUnit = oi.Product.Price
                    }).ToList()
               }).ToList();

               return View(result);
          }
          public ActionResult Users()
          {
               if (Session["Role"]?.ToString() != "2")
                    return RedirectToAction("AccessDenied", "Account");

               var users = _context.Users.ToList();
               return View(users);
          }

          public ActionResult DeleteUser(int id)
          {
               if (Session["Role"]?.ToString() != "2")
                    return RedirectToAction("AccessDenied", "Account");

               var user = _context.Users.Find(id);
               if (user != null)
               {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
               }

               return RedirectToAction("Users");
          }

     }
}
