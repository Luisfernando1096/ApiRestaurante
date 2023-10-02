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
    public class SalonController : ControllerBase
    {
        private readonly ISalonRepository salonRepository;

        public SalonController(ISalonRepository salonRepository)
        {
            this.salonRepository = salonRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodosLosSalones()
        {
            return Ok(await salonRepository.ObtenerTodosLosSalones());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerSalonPorId(int id)
        {
            return Ok(await salonRepository.ObtenerSalonPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertarSalon([FromBody] Salon salon)
        {
            if(salon == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var crear = await salonRepository.InsertarSalon(salon);

            return Created("created", crear);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarSalon([FromBody] Salon salon)
        {
            if (salon == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await salonRepository.ActualizarSalon(salon);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarSalon(int id)
        {
            await salonRepository.EliminarSalon(new Salon { IdSalon = id });

            return NoContent();
        }
    }
}
