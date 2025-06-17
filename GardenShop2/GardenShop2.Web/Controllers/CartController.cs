using GardenShop2.BusinessLogic.BL_Struct;
using GardenShop2.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GardenShop2.Web.Controllers
{
     public class CartController : Controller
     {
          private readonly ProductBL _productBL = new ProductBL();
          private readonly CartBL _cartBL = new CartBL();

          public ActionResult AddToCart(int id)
          {
               var product = _productBL.GetById(id);
               if (product == null)
               {
                    return HttpNotFound();
               }

               var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();
               _cartBL.AddToCart(cart, product);

               Session["Cart"] = cart;
               Session["CartCount"] = cart.Sum(item => item.Quantity);

               return RedirectToAction("Index", "Categories", new { name = product.Category });
          }

          public ActionResult RemoveFromCart(int id)
          {
               var cart = Session["Cart"] as List<CartItem>;
               if (cart == null)
                    return RedirectToAction("Index", "Home");

               var item = cart.FirstOrDefault(p => p.ProductId == id);
               if (item != null)
               {
                    cart.Remove(item);
                    Session["Cart"] = cart;
                    Session["CartCount"] = cart.Sum(p => p.Quantity);
               }

               return Redirect(Request.UrlReferrer.ToString());
          }
     }
}
