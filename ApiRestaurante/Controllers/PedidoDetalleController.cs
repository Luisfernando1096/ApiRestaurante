using ApiRestaurante.Data.Repositorios;
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
    }
}
