using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GardenShop2.BusinessLogic.BL_Struct;
using GardenShop2.Domain.Model;

namespace GardenShop2.Web.Controllers
{
     public class ProfileController : Controller
     {
          private readonly ProductBL _productBL = new ProductBL();

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
     }
}
