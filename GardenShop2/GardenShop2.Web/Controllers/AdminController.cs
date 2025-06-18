using System.Web.Mvc;

namespace GardenShop.Controllers
{
     public class AdminController : Controller
     {
          public ActionResult Panel()
          {
               if (Session["Role"]?.ToString() != "2")
               {
                    return RedirectToAction("AccessDenied", "Account");
               }

               return View();
          }
     }
}
