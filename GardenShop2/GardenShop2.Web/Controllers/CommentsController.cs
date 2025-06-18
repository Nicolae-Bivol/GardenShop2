using GardenShop2.Domain.Data;
using GardenShop2.Domain.Model;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GardenShop2.Web.Controllers
{
     public class CommentsController : Controller
     {
          private readonly ApplicationDbContext _context;

          public CommentsController()
          {
               _context = new ApplicationDbContext();
          }

          [HttpPost]
          public ActionResult Add(int productId, string content)
          {
               var username = Session["Username"] as string;
               if (username == null)
                    return RedirectToAction("Login", "Autentification");

               var user = _context.Users.FirstOrDefault(u => u.Username == username);
               var product = _context.Products.FirstOrDefault(p => p.Id == productId);

               if (user == null || product == null)
                    return RedirectToAction("Index", "Home");

               var comment = new Comment
               {
                    Content = content,
                    CreatedAt = DateTime.Now,
                    ProductId = product.Id,
                    UserId = user.Id
               };

               _context.Comments.Add(comment);
               _context.SaveChanges();

               return RedirectToAction("Details", "Product", new { id = productId });
          }

          public ActionResult MyComments()
          {
               var username = Session["Username"] as string;
               if (username == null)
                    return RedirectToAction("Login", "Autentification");

               var user = _context.Users.FirstOrDefault(u => u.Username == username);
               if (user == null)
                    return RedirectToAction("Index", "Home");

               var comments = _context.Comments
                   .Where(c => c.UserId == user.Id)
                   .OrderByDescending(c => c.CreatedAt)
                   .ToList();

               return View(comments);
          }
     }
}
