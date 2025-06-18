using GardenShop2.BusinessLogic.BL_Struct;
using GardenShop2.Domain.Data;
using GardenShop2.Domain.Model;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GardenShop2.Web.Controllers
{
     public class ProductController : Controller
     {
          private readonly ProductBL _productBL = new ProductBL();

          // ✅ acceptă id NULL și protejează de erori
          public ActionResult Details(int? id)
          {
               if (id == null)
                    return RedirectToAction("Index", "Home");

               var product = _productBL.GetById(id.Value);
               if (product == null)
                    return HttpNotFound();

               return View(product);
          }
     
     [HttpPost]
          public ActionResult AddComment(int productId, string content)
          {
               var username = Session["Username"] as string;
               if (username == null)
                    return RedirectToAction("Login", "Autentification");

               using (var context = new ApplicationDbContext())
               {
                    var user = context.Users.FirstOrDefault(u => u.Username == username);
                    if (user == null) return RedirectToAction("Index", "Home");

                    var comment = new Comment
                    {
                         ProductId = productId,
                         UserId = user.Id,
                         Content = content,
                         CreatedAt = DateTime.Now
                    };

                    context.Comments.Add(comment);
                    context.SaveChanges();
               }

               return RedirectToAction("Details", new { id = productId });
          }
     }
}
