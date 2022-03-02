using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OPPI.Dominio.Enums;
using OPPI.Servico.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace OPPI.WebApi.Services
{
    public static class TokenService
    {
        public static string GenerateToken(UsuarioDTO usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Startup.StaticConfig.GetValue<string>("Settings:secretKey"));

            var json = JsonSerializer.Serialize(usuario);


            var listClaim = new List<Claim>();
            listClaim.Add(new Claim(ClaimTypes.Name, usuario.Nome.ToString()));
            listClaim.Add(new Claim(ClaimTypes.UserData, json));
            if (string.IsNullOrEmpty(usuario.Role)) usuario.Role = RoleEnum.Usuario.ToString();
            foreach (var role in usuario.Role.Split(","))
                listClaim.Add(new Claim(ClaimTypes.Role, role));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(listClaim.ToArray()),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static ClaimsPrincipal ValidateJwtToken(string token, bool validaTempo = true)
        {
            
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Startup.StaticConfig.GetValue<string>("Settings:secretKey"));
                SecurityToken validatedToken;
                ClaimsPrincipal principal = handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero,
                    ValidateLifetime = validaTempo
                }, out validatedToken);

                // return account id from JWT token if validation successful
                return principal;
            }
            catch (Exception ex)
            {
                throw new Exception("Token inválido ou expirado, favor refazer operação!", ex);
            }
        }
    }
}
