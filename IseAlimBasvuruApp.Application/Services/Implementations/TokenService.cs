using IseAlimBasvuruApp.Application.DTOs;
using IseAlimBasvuruApp.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Application.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(KullaniciDTO kullanici)
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.NameIdentifier, kullanici.Id.ToString()), // Eğer Id bir sayıysa ToString kullanın
            new Claim(ClaimTypes.Name, kullanici.Ad),
            new Claim(ClaimTypes.Email, kullanici.Email),
            

        };
            

            // Eğer kullanıcı birden fazla rol taşıyorsa
            foreach (var rol in kullanici.Roles) // Roller, Kullanıcı DTO'sunda List<string> veya string[] olabilir
            {
                claims.Add(new Claim(ClaimTypes.Role, rol.ToString()));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new Microsoft.IdentityModel.Tokens.SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2), // Token 2 saat geçerli olacak
                SigningCredentials = creds,
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
