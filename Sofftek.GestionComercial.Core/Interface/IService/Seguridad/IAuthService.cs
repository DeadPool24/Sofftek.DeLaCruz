using Sofftek.GestionComercial.API.Entities.Auth;
using Sofftek.GestionComercial.Core.DTO.Auth.v1.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.Core.Interfaces.IServices.Seguridad
{
    public interface IAuthService
    {
        Task<Tokens> AuthenticateAsync(LoginRequest users);
    }
}
