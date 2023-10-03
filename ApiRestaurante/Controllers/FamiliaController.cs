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
    public class FamiliaController : Controller
    {
        private readonly IFamiliaRepository familiaRepository;

        public FamiliaController (IFamiliaRepository familiaRepository)
        {
            this.familiaRepository = familiaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodasLasFamilias()
        {
            return Ok(await familiaRepository.ObtenerTodasLasFamilias());
        }
    }
}
