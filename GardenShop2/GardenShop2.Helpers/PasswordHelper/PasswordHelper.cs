using System;
using System.Security.Cryptography;
using System.Text;

namespace GardenShop2.Helpers
{
     public static class PasswordHelper
     {
          public static string HashPassword(string password)
          {
               using (var md5 = MD5.Create())
               {
                    var inputBytes = Encoding.ASCII.GetBytes(password + "twutm2018"); // salt
                    var hashBytes = md5.ComputeHash(inputBytes);
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
               }
          }
     }
}
