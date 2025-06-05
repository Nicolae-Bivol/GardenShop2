using GardenShop2.BusinessLogic.BL_Struct;

namespace GardenShop2.BusinessLogic.Core
{
     public class UserAPI
     {
          private readonly UserBL _userBL;

          public UserAPI()
          {
               _userBL = new UserBL();
          }

          public bool Register(string username, string password)
          {
               return _userBL.Register(username, password);
          }

          public bool Login(string username, string password)
          {
               return _userBL.Login(username, password);
          }
     }
}
