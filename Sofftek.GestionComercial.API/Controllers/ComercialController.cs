using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sofftek.GestionComercial.Core.Entities;
using Sofftek.GestionComercial.Core.Interface;
using Sofftek.GestionComercial.Core.Interface.IService;

namespace Sofftek.GestionComercial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercialController : ControllerBase
    {
        private IServiceVentas _service;
        public ComercialController(IServiceVentas service)
        {
            _service = service;
        }

       
        /// <summary>
        /// Lista las ventas registradas en estado activo
        /// </summary>
        /// <returns>Lista de Ventas</returns>
        [HttpGet("listarventas", Name = "listarventas")]
        [Authorize]
        public IActionResult ListarVentas()
        {
            try
            {
                var result = _service.listarVentas();
                return Ok(new { Success = true, Message = "Listado exitoso", date = DateTime.Now, Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, date = DateTime.Now, Data = "NULL" });
            }

        }

        /// <summary>
        /// Guarda una venta
        /// </summary>
        /// <param name="venta">Datos de la venta</param>
        /// <returns>Ok/Bad</returns>
        [HttpPost("guardarventa", Name = "guardarventa")]
        [Authorize]
        public IActionResult GuardarVenta(Venta venta)
        {
            try
            {
                venta.id_venta = _service.guardarVenta(venta);
                return Ok(new { Success = true, Message = "Venta registrada", date = DateTime.Now, Data = venta });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, date = DateTime.Now, Data = "NULL" });
            }
        }

        
        /// <summary>
        /// Registra la lista del detalle de la venta
        /// </summary>
        /// <param name="detalle"></param>
        /// <returns></returns>
        [HttpPost("guardardetalleventa", Name = "guardardetalleventa")]
        [Authorize]
        public IActionResult GuardarDetalleVenta(List<DetalleVenta> detalle)
        {
            try
            {
                _service.guardarDetalleVenta(detalle);
                return Ok(new { Success = true, Message = "Detalle de venta registrado", date = DateTime.Now, Data = detalle });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, date = DateTime.Now, Data = "NULL" });
            }
        }
    }
}
