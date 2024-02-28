using ApiRestaurante.Data.Repositorios;
using ApiRestaurante.Model.CLS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoDetalleLogController : Controller
    {
        private readonly IPedidoDetalleLogRepository pedidoDetalleLogRepository;

        public PedidoDetalleLogController(IPedidoDetalleLogRepository pedidoDetalleLogRepository)
        {
            this.pedidoDetalleLogRepository = pedidoDetalleLogRepository;
        }

        [HttpGet("obtenerpedidoeliminado/{id}")]
        public async Task<IActionResult> ObtenerPedidoEliminado(int id)
        {
            return Ok(await pedidoDetalleLogRepository.ObtenerPedidoEliminado(id));
        }

        [HttpPost("insertar")]
        public async Task<IActionResult> InsertarPedidoDetalleLog([FromBody] PedidoDetalleLog pDetalle)
        {
            if (pDetalle == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var crear = await pedidoDetalleLogRepository.InsertarPedidoDetalleLog(pDetalle);

            return Created("created", crear);
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> ActualizarPedidoDetalleLog([FromBody] PedidoDetalleLog pDetalle)
        {
            if (pDetalle == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await pedidoDetalleLogRepository.ActualizarPedidoDetalleLog(pDetalle);

            return NoContent();
        }

    }
}
