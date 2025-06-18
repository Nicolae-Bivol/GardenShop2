using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GardenShop2.Domain.Model;
using GardenShop2.BusinessLogic.BL_Struct;

namespace GardenShop2.Web.Controllers
{
     public class FavoritesController : Controller
     {
          private readonly ProductBL _productBL = new ProductBL();

          // ✅ Acțiune pentru toggle la favorite (folosită de AJAX)
          [HttpPost]
          public ActionResult Toggle(int id)
          {
               // Doar useri autentificați pot adăuga la favorite
               if (Session["Username"] == null)
                    return new HttpStatusCodeResult(401); // Unauthorized

               var favorites = Session["Favorites"] as List<int> ?? new List<int>();

               if (favorites.Contains(id))
                    favorites.Remove(id);
               else
                    favorites.Add(id);

               Session["Favorites"] = favorites;

               return new HttpStatusCodeResult(200); // Succes pentru AJAX
          }

          // ✅ Acțiune pentru afișarea produselor favorite
          public ActionResult Index()
          {
               if (Session["Username"] == null)
                    return RedirectToAction("Login", "Autentification");

               var favoriteIds = Session["Favorites"] as List<int> ?? new List<int>();

               var favorites = _productBL.GetAll()
                                         .Where(p => favoriteIds.Contains(p.Id))
                                         .ToList();

               return View(favorites);
          }
     }
}
