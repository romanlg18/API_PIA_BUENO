using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_PROG.data.Repositorios;
using API_PROG.model;
//PRUEBA 1
namespace API_PIA_BUENO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteControlador : ControllerBase
    {
        private readonly IClienteRepository _ClienteRepository;
        public ClienteControlador(IClienteRepository ClienteRepository)
        {
            _ClienteRepository = ClienteRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllClient()
        {
            return Ok(await _ClienteRepository.GetAllClient());
        }


        [HttpPut]
        [Route("DelUpdateCliente")]
        public async Task<IActionResult> BajaClientes(UpDeleteClient clientes)
        {
            if (clientes == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _ClienteRepository.BajaClientes(clientes);
            return Ok();
        }


        [HttpPost]
        [Route("InsertClientes")]
        public async Task<IActionResult> InsertClientes(ClientesInsertar clientes)
        {
            if (clientes == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _ClienteRepository.InsertClientes(clientes);
            return Created("created", created);
        }
    }


}
