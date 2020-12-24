using System;
using System.Text;
using System.Security.Claims;
using FProject.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace FProject.Service
{
    public static class TokenService
    {
        public static string GenerateToken(User model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim( ClaimTypes.Name, model.Username.ToString() ),
                    new Claim( ClaimTypes.Role, model.Password.ToString())
                }),
                Expires = DateTime.UtcNow.AddSeconds(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
