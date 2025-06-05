using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GardenShop2.Domain.Model;

namespace GardenShop2.Domain.Model
{
     public class User
     {
          public int Id { get; set; }
          public string Username { get; set; }
          public string Password { get; set; }
     }
}
