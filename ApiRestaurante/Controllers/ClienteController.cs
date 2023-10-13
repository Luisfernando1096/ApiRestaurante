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
    public class ClienteController : Controller
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        [HttpGet("obtenerclientes")]
        public async Task<IActionResult> ObtenerTodosLosClientes()
        {
            return Ok(await clienteRepository.ObtenerTodosLosClientes());
        }
    }
}
