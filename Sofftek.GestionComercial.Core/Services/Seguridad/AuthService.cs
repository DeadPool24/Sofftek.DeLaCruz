using Sofftek.GestionComercial.Core.Interfaces.IServices.Seguridad;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Sofftek.GestionComercial.API.Entities.Auth;
using Sofftek.GestionComercial.Core.DTO.Auth.v1.Request;

namespace Sofftek.GestionComercial.Core.Services.Seguridad
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration iconfiguration;
        public AuthService(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }
        public async Task<Tokens> AuthenticateAsync(LoginRequest users)
        {
            //Header
            var symmetricSecurity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(iconfiguration["Authentication:Secretkey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurity, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, users.User),
                new Claim(ClaimTypes.Role, "Admistrator")
            };

            //Payload
            var payload = new JwtPayload
            (
                iconfiguration["Authentication:Issuer"],
                iconfiguration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(90)
            );

            //Token
            var token = new JwtSecurityToken(header, payload);

            return new Tokens { Token = new JwtSecurityTokenHandler().WriteToken(token) };

        }
    }
}
