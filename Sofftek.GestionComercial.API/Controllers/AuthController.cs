using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sofftek.GestionComercial.Core.DTO.Auth.v1.Request;
using Sofftek.GestionComercial.Core.DTO.Auth.v1.Response;
using Sofftek.GestionComercial.Core.Interfaces.IServices.Seguridad;
using System.Web.Http.Description;

namespace Sofftek.GestionComercial.API.Controllers.Auth
{
    [Authorize]
    [Area("Auth")]
    [ApiController]
    [Route("[area]/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _jWTManager;

        public AuthController(IAuthService jWTManager)
        {
            //this.settings = settings;
            this._jWTManager = jWTManager;
        }

        /// <summary>
        /// Autenticación
        /// </summary>
        /// <returns>Retorna un Token de Autenticación</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Authentication
        ///     {
        ///        "user":"UserExample",
        ///        "password":"123456"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Retorna un token</response>
        /// <response code="400">Retorna vacio</response>
        [MapToApiVersion("1.0")]
        [AllowAnonymous]
        [HttpPost]
        //[ModelStateValidator]
        //[ResponseType(typeof(GenericResponse<AuthenticationDto>))]
        [ResponseType(typeof(AuthenticationDto))]
        public IActionResult Authentication(LoginRequest login)
        {
            var token = _jWTManager.AuthenticateAsync(login);
            var ResponseAuth = new AuthenticationDto
            {
                AccessToken = token.Result.Token,
                RefreshToken = token.Result.RefreshToken
            };

            return Ok(ResponseAuth);
        }
    }
}
