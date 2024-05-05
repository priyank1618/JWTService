using JWTService.Models;
using JWTService.ViewModels;

namespace JWTService.Interface
{
    public interface IAuthService
    {

         public User AddUser(User user);

        public string Login(Login login);
    }
}
