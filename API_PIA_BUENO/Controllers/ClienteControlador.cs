using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_PROG.data.Repositorios;
using API_PROG.model;
using Microsoft.AspNetCore.Authorization;


namespace API_PIA_BUENO.Controllers
{
    [Route("api/[controller]")]
    [Authorize] 
    [ApiController]
    public class ClienteControlador : ControllerBase
    {
        private readonly IClienteRepository _ClienteRepository;
        public ClienteControlador(IClienteRepository ClienteRepository)
        {
            _ClienteRepository = ClienteRepository;
        }


        [HttpGet]
        [Route("ObtenerClientes")]
        [Authorize]

        public async Task<IActionResult> GetAllClient()
        {
            return Ok(await _ClienteRepository.GetAllClient());
        }

        [HttpGet]
        [Route("ObtenerCredenciales")]
        public async Task<IActionResult> GetCredentials()
        {
            return Ok(await _ClienteRepository.GetCredentials());
        }

        [HttpGet]
        [Route("ObtenerBuzon")]
        public async Task<IActionResult> GetDudas()
        {
            return Ok(await _ClienteRepository.GetDudas());
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


        [HttpPut]
        [Route("UpdateDatos")]
        public async Task<IActionResult> UpdateClienteAdmin(UpdateClienteAdmin clientes)
        {
            if (clientes == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _ClienteRepository.UpdateClienteAdmin(clientes);
            return Created("created", created);
        }
    }


}
