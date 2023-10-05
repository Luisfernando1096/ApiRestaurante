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

        [HttpGet("ActualizarEstadoMesa/{idMesa}")]
        public async Task<IActionResult> ActualizarEstadoMesa(int idMesa)
        {
            return Ok(await mesaRepository.ActualizarEstadoMesa(idMesa));
        }

    }
}
