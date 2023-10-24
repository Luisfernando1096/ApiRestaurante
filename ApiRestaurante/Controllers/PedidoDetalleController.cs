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
    public class PedidoDetalleController : Controller
    {
        private readonly IPedidoDetalleRepository pedidoDetalleRepository;

        public PedidoDetalleController(IPedidoDetalleRepository pedidoDetalleRepository)
        {
            this.pedidoDetalleRepository = pedidoDetalleRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerDetallePedidoPorMesa(int id)
        {
            return Ok(await pedidoDetalleRepository.ObtenerDetallePedidoPorMesa(id));
        }

        [HttpGet("detallesdepedido/{id}/{idPedido}")]
        public async Task<IActionResult> ObtenerDetallePedidoPorMesaYPorIdPedido(int id, int idPedido)
        {
            return Ok(await pedidoDetalleRepository.ObtenerDetallePedidoPorMesaYPorIdPedido(id, idPedido));
        }

        [HttpPost("insertar")]
        public async Task<IActionResult> InsertarPedidoDetalle([FromBody] PedidoDetalle pDetalle)
        {
            if (pDetalle == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var crear = await pedidoDetalleRepository.Insertar(pDetalle);

            return Created("created", crear);
        }

        [HttpPut("actualizarcompra")]
        public async Task<IActionResult> ActualizarCompra([FromBody] PedidoDetalle pDetalle)
        {
            if (pDetalle == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await pedidoDetalleRepository.ActualizarCompra(pDetalle);

            return NoContent();
        }

        [HttpPut("actualizardatos")]
        public async Task<IActionResult> ActualizarDatos([FromBody] PedidoDetalle pDetalle)
        {
            if (pDetalle == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await pedidoDetalleRepository.ActualizarDatos(pDetalle);

            return NoContent();
        }
    }
}
