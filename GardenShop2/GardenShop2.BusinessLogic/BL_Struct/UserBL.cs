using System.Linq;
using GardenShop2.Domain.Model;
using GardenShop2.Helpers;
using GardenShop2.Domain.Data;

namespace GardenShop2.BusinessLogic.BL_Struct
{
     public class UserBL
     {
          private readonly ApplicationDbContext _context;

          public UserBL()
          {
               _context = new ApplicationDbContext();
          }

          public bool Register(string username, string password)
          {
               if (_context.Users.Any(u => u.Username == username))
                    return false;

               string hashedPassword = PasswordHelper.HashPassword(password);

               _context.Users.Add(new User
               {
                    Username = username,
                    Password = hashedPassword,
                    Role = 1 // utilizator normal implicit
               });

               _context.SaveChanges();
               return true;
          }

          public bool Login(string username, string password)
          {
               string hashedPassword = PasswordHelper.HashPassword(password);
               return _context.Users.Any(u => u.Username == username && u.Password == hashedPassword);
          }

          public User GetByUsername(string username)
          {
               return _context.Users.FirstOrDefault(u => u.Username == username);
          }
     }
}
