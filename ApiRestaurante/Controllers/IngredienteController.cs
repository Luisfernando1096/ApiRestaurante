using ApiRestaurante.Data.Repositorios;
using ApiRestaurante.Model.CLS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : Controller
    {
        private readonly IIngredienteRepository ingredienteRepository;
        public IngredienteController(IIngredienteRepository ingredienteRepository)
        {
            this.ingredienteRepository = ingredienteRepository;
        }

        [HttpGet("ingredientesdeproducto/{id}")]
        public async Task<IActionResult> ingredientesdeproducto(int id)
        {
            return Ok(await ingredienteRepository.ingredientesdeproducto(id));
        }

        [HttpPut("actualizarstock")]
        public async Task<IActionResult> actualizarstock([FromBody] Ingrediente ingrediente)
        {
            if (ingrediente == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await ingredienteRepository.actualizarstock(ingrediente);
            return NoContent();
        }
    }
}
