using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Vue3Sharpen.Services
{
    public class TokenService
    {
        public string Generate(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("secretsecretsecretsecret");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) ,new Claim(ClaimTypes.Role, "Admin")}),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "http://localhost:8080",
                Audience = "http://localhost:8080",
                
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string Generate2(string username)
        {
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretsecretsecretsecret"));

            var token = new JwtSecurityToken(
                                         issuer: "http://localhost:5000",
                                         audience: "http://localhost:5000",
                                         claims: new[]
                                         {
                                             new Claim(JwtRegisteredClaimNames.UniqueName, username),
                                             new Claim(JwtRegisteredClaimNames.Email, username),
                                         },
                                         expires: DateTime.Now.AddDays(1),
                                         signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                                        );
           
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
