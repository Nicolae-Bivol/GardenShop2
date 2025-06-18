using GardenShop2.BusinessLogic.BL_Struct;
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
     }
}
