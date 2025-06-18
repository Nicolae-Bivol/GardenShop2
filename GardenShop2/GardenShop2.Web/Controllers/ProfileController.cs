using System.Web.Mvc;

namespace GardenShop2.Web.Controllers
{
     public class ProfileController : Controller
     {
          public ActionResult Index()
          {
               if (Session["Username"] == null)
                    return RedirectToAction("Login", "Autentification");

               return View();
          }
     }
}
