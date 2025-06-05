using GardenShop2.BusinessLogic.Core;
using GardenShop2.BusinessLogic.Interfaces;



namespace GardenShop2.BusinessLogic.Services
{
     public class UserService : IUserService
     {
          private readonly UserAPI _userApi;

          public UserService()
          {
               _userApi = new UserAPI();
          }

          public bool Register(string username, string password)
          {
               return _userApi.Register(username, password);
          }

          public bool Login(string username, string password)
          {
               return _userApi.Login(username, password);
          }
     }
}
