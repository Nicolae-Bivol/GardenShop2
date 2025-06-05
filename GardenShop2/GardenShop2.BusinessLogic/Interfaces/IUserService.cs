using GardenShop2.Domain.Model;

namespace GardenShop2.BusinessLogic.Interfaces
{
     public interface IUserService
     {
          bool Register(string username, string password);
          bool Login(string username, string password);
     }
}
