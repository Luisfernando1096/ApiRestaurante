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
    public class ConfiguracionController : Controller
    {
        private readonly IConfiguracionRepository configuracionRepository;

        public ConfiguracionController(IConfiguracionRepository configuracionRepository)
        {
            this.configuracionRepository = configuracionRepository;
        }

        [HttpGet("obtenerConfiguracion")]
        public async Task<IActionResult> ObtenerConfiguracion()
        {
            return Ok(await configuracionRepository.ObtenerConfiguracion());
        }
    }
}
