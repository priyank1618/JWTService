using JWTService.Interface;
using JWTService.Models;
using JWTService.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }
        // GET: api/<UserController>
       

        // POST api/<UserController>
        [HttpPost("Login")]
        public string Login([FromBody] Login login)
        {
            var result = _authService.Login(login);
            return result;
        }

        // PUT api/<UserController>/5
        [HttpPost("addUser")]
        public User AddUser([FromBody] User user)
        {
            var userobj =_authService.AddUser(user);
            return userobj;

        }

        
    }
}
