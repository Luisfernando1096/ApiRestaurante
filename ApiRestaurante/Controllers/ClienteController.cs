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

        [HttpPost("insertarcliente")]
        public async Task<IActionResult> InsertarPedidoDetalle([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var crear = await clienteRepository.InsertarCliente(cliente);

            return Created("created", crear);
        }
    }
}
