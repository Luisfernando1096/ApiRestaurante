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
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoRepository empleadoRepository;

        public EmpleadoController(IEmpleadoRepository empleadoRepository)
        {
            this.empleadoRepository = empleadoRepository;
        }

        [HttpGet("obtenerempleados")]
        public async Task<IActionResult> ObtenerEmpleados()
        {
            return Ok(await empleadoRepository.ObtenerEmpleados());
        }
    }
}
