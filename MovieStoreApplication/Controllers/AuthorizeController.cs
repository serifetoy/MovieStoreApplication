using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieStoreApplication.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieStoreApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class AuthorizeController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthorizeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("token")]
        public IActionResult GetToken(UserSec usersec)
        {

            //var id = "UserID";

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JwtKey"));

            //var tokenDesc = new SecurityTokenDescriptor
            //{
            //    SigningCredentials= new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            //    Expires = DateTime.UtcNow.AddDays(1), //lifetime
            //    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, id )
            //    })
            //};

            //var token = tokenHandler.CreateToken(tokenDesc);

            //var tokenString = tokenHandler.WriteToken(token);

            //return Ok(tokenString);

            var id = "UserID";
            var tokenHandler = new JwtSecurityTokenHandler();
            var result = _configuration.GetSection("JwtKey").Value;
            var key = Encoding.UTF8.GetBytes(result);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, id),
        
                }),
                Expires = DateTime.UtcNow.AddHours(7), //lifetime
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(tokenHandler.WriteToken(token));
        }

    }
}
