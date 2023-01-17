using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sofftek.GestionComercial.Service.Entities;
using Sofftek.GestionComercial.Service.Interface;

namespace Sofftek.GestionComercial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercialController : ControllerBase
    {
        private IRepositoryVentas _repository;
        public ComercialController(IRepositoryVentas repositoryVentas)
        {
            _repository = repositoryVentas;
        }

       
        /// <summary>
        /// Lista las ventas registradas en estado activo
        /// </summary>
        /// <returns>Lista de Ventas</returns>
        [HttpGet("listarventas", Name = "listarventas")]
        public IActionResult ListarVentas()
        {
            try
            {
                var result = _repository.listarVentas();
                return Ok(result);
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
        [HttpPost]
        public IActionResult GuardarVenta(Venta venta)
        {
            try
            {
                venta.id_venta = new Guid();
                _repository.guardarVenta(venta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, date = DateTime.Now, Data = "NULL" });
            }
        }
    }
}
