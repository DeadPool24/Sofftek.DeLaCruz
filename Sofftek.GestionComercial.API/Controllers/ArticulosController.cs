using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sofftek.GestionComercial.Core.Entities;
using Sofftek.GestionComercial.Core.Interface.IService;
using System.Web.Http.Results;

namespace Sofftek.GestionComercial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private IServiceArticulos _service;
        public ArticulosController(IServiceArticulos service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista los articulos con estado activo
        /// </summary>
        /// <returns></returns>
        [HttpGet("listararticulos", Name = "listararticulos")]
        [Authorize]
        public IActionResult listararticulos()
        {
            try
            {
                var result = _service.listarArticulos();
                return Ok(new { Success = true, Message = "Listado exitoso", date = DateTime.Now, Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, date = DateTime.Now, Data = "NULL" });
            }

        }
       
        /// <summary>
        /// Guarda un articulo nuevo
        /// </summary>
        /// <param name="articulo">Identificado del articulo</param>
        /// <returns></returns>
        [HttpPost("guardararticulo", Name = "guardararticulo")]
        [Authorize]
        public IActionResult GuardaraArticulo(Articulo articulo)
        {
            try
            {
                _service.guardarArticulo(articulo);
                return Ok(new { Success = true, Message = "Registro exitoso", date = DateTime.Now, Data = articulo });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, date = DateTime.Now, Data = "NULL" });
            }
        }

        /// <summary>
        /// Obtiene un articulo por Identificador
        /// </summary>
        /// <param name="idarticulo"></param>
        /// <returns></returns>
        [HttpGet("obtenerarticuloporid/{idarticulo}", Name = "obtenerarticuloporid")]
        [Authorize]
        public IActionResult ObtenerarticuloPorId(Guid idarticulo)
        {
            try
            {
                var result = _service.obtenerArticuloPorId(idarticulo);
                return Ok(new { Success = true, Message = "Listado exitoso", date = DateTime.Now, Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, date = DateTime.Now, Data = "NULL" });
            }

        }
    }
}
