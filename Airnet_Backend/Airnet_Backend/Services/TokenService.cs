using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Airnet_Backend.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Airnet_Backend.Services
{
      public class TokenService : ITokenService
      {
            private readonly SymmetricSecurityKey _key;
            public TokenService(IConfiguration config)
            {
                  _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            }

            public string CreateToken(User user)
            {
                  //* Adding Claims
                  var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.NameId , user.Username)
                ,new Claim(JwtRegisteredClaimNames.Email , user.Email)
                ,new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role" , user.UserRole)

            };

                  //* Creating Credentials
                  var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

                  //* Looks Of JWT Token
                  var TokenDesc = new SecurityTokenDescriptor
                  {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.Now.AddMinutes(5),
                        SigningCredentials = creds
                  };

                  //* Token Handler
                  var tokenHandler = new JwtSecurityTokenHandler();

                  //* Create Token With Credentials
                  var token = tokenHandler.CreateToken(TokenDesc);

                  //* Return Token to User
                  return tokenHandler.WriteToken(token);

            }
      }
}