using Dominio.Entidades;
using Microsoft.IdentityModel.Tokens;
using Repositorio.Config;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Repositorio.ServiceToken
{
    public static class TokenServices
    {
        public static string GenerateToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Token.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                   new Claim(ClaimTypes.Name, user.Nome.AsString()),
                   new Claim(ClaimTypes.NameIdentifier, user.ChaveUsuario.AsString()),
                   new Claim(ClaimTypes.Role, user.Cargo.NomeCargo.AsString())
                }),
                Expires = DateTime.UtcNow.AddSeconds(20),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
