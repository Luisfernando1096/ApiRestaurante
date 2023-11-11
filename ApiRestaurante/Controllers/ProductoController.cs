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
    public class ProductoController : Controller
    {
        private readonly IProductoRepository productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerProductoPorIdFamilia(int id)
        {
            return Ok(await productoRepository.ObtenerProductoPorIdFamilia(id));
        }

        [HttpGet("productoporid/{id}")]
        public async Task<IActionResult> ObtenerSalonPorId(int id)
        {
            return Ok(await productoRepository.ObtenerProductoPorId(id));
        }

        [HttpPut("actualizarstock")]
        public async Task<IActionResult> actualizarstock([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await productoRepository.actualizarstock(producto);

            return NoContent();
        }
    }
}
