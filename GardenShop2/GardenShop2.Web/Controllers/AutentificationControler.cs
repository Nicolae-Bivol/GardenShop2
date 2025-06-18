
using GardenShop2.BusinessLogic.Interfaces;
using GardenShop2.BusinessLogic.Services;
using System.Web.Mvc;

namespace GardenShop.Controllers
{
     public class AutentificationController : Controller
     {
          private readonly IUserService _userService;

          // Constructor implicit pentru ASP.NET MVC
          public AutentificationController() : this(new UserService())
          {
          }

          // Constructor folosit pentru testare sau dependency injection
          public AutentificationController(IUserService userService)
          {
               _userService = userService;
          }

          public ActionResult Login() => View();

          [HttpPost]
          public ActionResult Login(string username, string password)
          {
               var user = new GardenShop2.BusinessLogic.BL_Struct.UserBL().GetByUsername(username);
               if (user != null && user.Password == GardenShop2.Helpers.PasswordHelper.HashPassword(password))
               {
                    Session["Username"] = user.Username;
                    Session["Role"] = user.Role.ToString(); // AICI e cheia!

                    return RedirectToAction("Index", "Home");
               }

               ViewBag.Error = "Invalid username or password.";
               return View();
          }

          public ActionResult Register() => View();

          [HttpPost]
          public ActionResult Register(string username, string password)
          {
               if (_userService.Register(username, password))
               {
                    Session["Username"] = username;
                    return RedirectToAction("Login", "Autentification");
               }

               ViewBag.Error = "Username already exists.";
               return View();
          }

          public ActionResult Logout()
          {
               Session.Clear();
               return RedirectToAction("Login", "Autentification");
          }
     }
}
