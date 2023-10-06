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
    }
}
