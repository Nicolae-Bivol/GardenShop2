using GardenShop2.Helpers;
using System.Linq;
using GardenShop2.Domain.Model;
using GardenShop2.Domain.Data;
using System.Data.Entity;


namespace GardenShop2.BusinessLogic.BL_Struct
{
     public class AuthBL
     {
          private readonly ApplicationDbContext _context;

          public AuthBL()
          {
               _context = new ApplicationDbContext();
          }

          public bool Login(string username, string password)
          {
               string hashedPassword = PasswordHelper.HashPassword(password);
               return _context.Users.Any(u => u.Username == username && u.Password == hashedPassword);
          }

          public bool Register(string username, string password)
          {
               if (_context.Users.Any(u => u.Username == username))
                    return false;

               string hashedPassword = PasswordHelper.HashPassword(password);
               _context.Users.Add(new User { Username = username, Password = hashedPassword });
               _context.SaveChanges();

               return true;
          }
     }
}
