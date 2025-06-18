using System.Web.Mvc;
using GardenShop2.BusinessLogic.Interfaces;
using GardenShop2.BusinessLogic.Services;
using GardenShop2.BusinessLogic.BL_Struct; // pentru UserBL
using GardenShop2.Helpers;

namespace GardenShop.Controllers
{
     public class AccountController : Controller
     {
          private readonly IUserService _userService;

          public AccountController()
          {
               _userService = new UserService();
          }

          public ActionResult Register() => View();

          [HttpPost]
          public ActionResult Register(string username, string password)
          {
               if (_userService.Register(username, password))
               {
                    // După înregistrare, îl autentificăm direct
                    var user = new UserBL().GetByUsername(username);
                    Session["Username"] = user.Username;
                    Session["Role"] = user.Role.ToString(); // setăm rolul

                    return RedirectToAction("Index", "Home");
               }

               ViewBag.Error = "Username already exists!";
               return View();
          }

          public ActionResult Login() => View();

          [HttpPost]
          public ActionResult Login(string username, string password)
          {
               var user = new UserBL().GetByUsername(username);
               if (user != null && user.Password == PasswordHelper.HashPassword(password))
               {
                    Session["Username"] = user.Username;
                    Session["Role"] = user.Role.ToString(); // setăm rolul

                    return RedirectToAction("Index", "Home");
               }

               ViewBag.Error = "Invalid username or password.";
               return View();
          }

          public ActionResult Logout()
          {
               Session.Clear();
               return RedirectToAction("Index", "Home");
          }

          public ActionResult AccessDenied()
          {
               return View();
          }
     }
}
