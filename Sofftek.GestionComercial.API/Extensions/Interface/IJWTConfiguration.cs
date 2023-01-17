using Sofftek.GestionComercial.API.Entities.Auth;
using Sofftek.GestionComercial.Core.DTO.Auth.v1.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.API.Extensions.Interface
{
    public interface IJWTConfiguration
    {

        Task<Tokens> AuthenticateAsync(LoginRequest users);

    }
}
