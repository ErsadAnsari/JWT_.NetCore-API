using JWTAPI.Interface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTAPI.Service
{
    public class Auth : IAuthJwt
    {
        private readonly string UserName="Ersad";
        private readonly string Password="Ersad@123";
        private readonly string Key;
        public Auth(string key)
        {
            this.Key = key;
        }
        public string Authentication(string username, string password)
        {
           if(!(username.Equals(UserName)||password.Equals(Password)))
            {
                return null;
            }
            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();
            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(Key);
            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }
    }
}
