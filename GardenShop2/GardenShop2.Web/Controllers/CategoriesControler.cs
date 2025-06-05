using GardenShop2.BusinessLogic.BL_Struct;
using System.Web.Mvc;

namespace GardenShop.Controllers
{
     public class CategoriesController : Controller
     {
          private readonly ProductBL _productBL;

          public CategoriesController()
          {
               _productBL = new ProductBL();
          }

          public ActionResult Index(string name)
          {
               if (string.IsNullOrWhiteSpace(name))
               {
                    return RedirectToAction("Index", "Home");
               }

               var products = _productBL.GetByCategory(name);
               ViewBag.CategoryName = name;
               return View(products);
          }
     }
}
