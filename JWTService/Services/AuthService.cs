using JWTService.DataContext;
using JWTService.Interface;
using JWTService.Models;
using JWTService.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTService.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _context = applicationDbContext;
            _configuration = configuration;

        }

        public User AddUser(User user)
        {
            var users = _context.Users.Add(user);
            _context.SaveChanges();
            return users.Entity;
        }

        public string Login(Login login)
        {
            if (login.username != null && login.password != null)
            {
                var user = _context.Users.FirstOrDefault(s => s.Email == login.username && s.Password == login.password);

                if (user != null)
                {
                    var claims = new[] {

                        new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                        new Claim("Id",user.Id.ToString()),
                        new Claim("UserName",user.Name),
                        new Claim("Email",user.Email)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);
                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
                else
                {
                    throw new Exception("User is not valid");
                }

            }
            else
            {
                throw new Exception("Credentials are not valid");
            }
        }


    }
}
