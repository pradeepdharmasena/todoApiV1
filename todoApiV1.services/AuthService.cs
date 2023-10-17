using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using todoApiV1.models;

namespace todoApiV1.services
{
    public class AuthService : IAuthService
    {
        public readonly IUserService _userService;
        public readonly IConfiguration _configuration;

        public AuthService(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public string CreateToken(AppUser user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName +  " " + user.LastName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication Secret Key to genrate token"));

            //_configuration.GetSection("Auth:JwtSecretKey").Value)

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
               _configuration.GetSection("Auth:Issuer").Value,
               _configuration.GetSection("Auth:Audiance").Value,
                claims:claims,
                expires: DateTime.UtcNow.AddDays(2),
                signingCredentials:cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public string GetAuthToken(string email, string pw)
        {
            AppUser user = _userService.GetByCredentials(email, pw);
            if (user == null)
            {
                return string.Empty;
            }
            else
            {
                return CreateToken(user);
            }
        }
    }
}
