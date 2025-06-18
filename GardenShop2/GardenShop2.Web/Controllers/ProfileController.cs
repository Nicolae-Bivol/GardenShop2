using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GardenShop2.BusinessLogic.BL_Struct;
using GardenShop2.Domain.Data;
using GardenShop2.Domain.Model;

namespace GardenShop2.Web.Controllers
{
     public class ProfileController : Controller
     {
          private readonly ProductBL _productBL = new ProductBL();
          private readonly ApplicationDbContext _context;

          public ProfileController()
          {
               _context = new ApplicationDbContext();
          }

          public ActionResult Index()
          {
               if (Session["Username"] == null)
               {
                    return RedirectToAction("Login", "Autentification");
               }

               var favoriteIds = Session["Favorites"] as List<int> ?? new List<int>();
               var favorites = _productBL.GetAll().Where(p => favoriteIds.Contains(p.Id)).ToList();

               return View(favorites);
          }

          // ✅ Comentariile utilizatorului
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
