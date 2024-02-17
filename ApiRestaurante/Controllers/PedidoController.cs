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
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        [HttpPost("insertar")]
        public async Task<IActionResult> InsertarPedido([FromBody] Pedido pedido)
        {
            if (pedido == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var crear = await pedidoRepository.InsertarPedido(pedido);

            return Created("created", crear);
        }

        [HttpPut("actualizartotal")]
        public async Task<IActionResult> ActualizarTotal([FromBody] Pedido pedido)
        {
            if (pedido == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await pedidoRepository.ActualizarTotal(pedido);

            return NoContent();
        }

        [HttpPut("actualizarmesa")]
        public async Task<IActionResult> ActualizarMesa([FromBody] Pedido pedido)
        {
            if (pedido == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await pedidoRepository.ActualizarMesa(pedido);

            return NoContent();
        }

        [HttpPut("actualizarcliente")]
        public async Task<IActionResult> ActualizarCliente([FromBody] Pedido pedido)
        {
            if (pedido == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await pedidoRepository.ActualizarCliente(pedido);

            return NoContent();
        }

        [HttpPut("actualizarmesero")]
        public async Task<IActionResult> ActualizarMesero([FromBody] Pedido pedido)
        {
            if (pedido == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await pedidoRepository.ActualizarMesero(pedido);

            return NoContent();
        }

        [HttpGet("obtenerultimopedido")]
        public async Task<IActionResult> ObtenerUltimoPedido()
        {
            return Ok(await pedidoRepository.ObtenerUltimoPedido());
        }

        [HttpGet("pedidosenmesa/{id}")]
        public async Task<IActionResult> ObtenerPedidosEnMesa(int id)
        {
            return Ok(await pedidoRepository.ObtenerPedidosEnMesa(id));
        }
        [HttpGet("pedidos/{id}")]
        public async Task<IActionResult> ObtenerPedidos(int id)
        {
            return Ok(await pedidoRepository.ObtenerPedidos(id));
        }
        [HttpGet("pedidoporid/{id}")]
        public async Task<IActionResult> ObtenerPedidoPorId(int id)
        {
            return Ok(await pedidoRepository.ObtenerPedidoPorId(id));
        }

        [HttpDelete("eliminarpedido/{id}")]
        public async Task<IActionResult> EliminarPedido(int id)
        {
            try
            {
                var resultado = await pedidoRepository.EliminarPedido(id);

                if (resultado)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound(false);
                }
            }
            catch (Exception ex)
            {
                // Loguear el error o devolver un mensaje genérico
                return StatusCode(500, "Error interno del servidor");
            }
        }

    }
}
