using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sofftek.GestionComercial.Core.Entities;
using Sofftek.GestionComercial.Core.Interface.IService;

namespace Sofftek.GestionComercial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IServiceClientes _service;
        public ClientesController(IServiceClientes service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista los clientes clientes con estado activo
        /// </summary>
        /// <returns></returns>
        [HttpGet("listarclientes", Name = "listarclientes")]
        [Authorize]
        public IActionResult listarClientes()
        {
            try
            {
                var result = _service.listarCliente();
                return Ok(new { Success = false, Message = "Listado exitoso", date = DateTime.Now, Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, date = DateTime.Now, Data = "NULL" });
            }

        }
       
        /// <summary>
        /// Guarda un cliente nuevo
        /// </summary>
        /// <param name="cliente">Identificado del cliente</param>
        /// <returns></returns>
        [HttpPost("guardarcliente", Name = "guardarcliente")]
        [Authorize]
        public IActionResult GuardarCliente(Cliente cliente)
        {
            try
            {
                _service.guardarCliente(cliente);
                return Ok(new { Success = false, Message = "Registro exitoso", date = DateTime.Now, Data = cliente });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, date = DateTime.Now, Data = "NULL" });
            }
        }

        [HttpGet("obtenerclienteporid/{idcliente}", Name = "obtenerclienteporid")]
        [Authorize]
        public IActionResult ObtenerClientePorId(Guid idcliente)
        {
            try
            {
                var result = _service.obtenerClientePorId(idcliente);
                return Ok(new { Success = false, Message = "Listado exitoso", date = DateTime.Now, Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, date = DateTime.Now, Data = "NULL" });
            }

        }
    }
}
