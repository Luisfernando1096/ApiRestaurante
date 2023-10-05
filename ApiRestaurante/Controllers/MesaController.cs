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
    public class MesaController : Controller
    {
        private readonly IMesaRepository mesaRepository;

        public MesaController(IMesaRepository mesaRepository)
        {
            this.mesaRepository = mesaRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerSalonPorId(int id)
        {
            return Ok(await mesaRepository.ObtenerMesasPorSalon(id));
        }

        [HttpPut("ActualizarEstadoMesa")]
        public async Task<IActionResult> ActualizarEstadoMesa([FromBody] Mesa mesa)
        {
            if (mesa == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await mesaRepository.ActualizarEstadoMesa(mesa);

            return NoContent();
        }

    }
}
