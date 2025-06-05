using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GardenShop2.BusinessLogic.Interfaces;
using GardenShop2.BusinessLogic.Services;


namespace GardenShop.Controllers
{
     public class AccountController : Controller
     {
          private readonly IUserService _userService;

          public AccountController()
          {
               _userService = new UserService(); // Poți folosi DI mai târziu dacă vrei
          }




          public ActionResult Register() => View();

          [HttpPost]
          public ActionResult Register(string username, string password)
          {
               if (_userService.Register(username, password))
               {
                    Session["Username"] = username;
                    return RedirectToAction("Index", "Home");
               }

               ViewBag.Error = "Username already exists!";
               return View();
          }

          public ActionResult Login() => View();

          [HttpPost]
          public ActionResult Login(string username, string password)
          {
               if (_userService.Login(username, password))
               {
                    Session["Username"] = username;
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
     }
}