using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_PROG.data.Repositorios;
using API_PROG.model;
using Microsoft.AspNetCore.Authorization;
using API_PIA_BUENO.API_PROG.model;
using API_PIA_BUENO.API_PROG.data.Repositorios;

namespace API_PIA_BUENO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaginaController : Controller
    {
        private readonly IPaginaRepository _PaginaRepository;
        public PaginaController(IPaginaRepository PaginaRepository)
        {
            _PaginaRepository = PaginaRepository;
        }

        [HttpPost]
        [Route("ContactoInsertar")]
        public async Task<IActionResult> ContactoInsertarPagina(ContactoInsertarPagina clientes)
        {
            if (clientes == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _PaginaRepository.ContactoInsertarPagina(clientes);
            return Created("created", created);
        }

        [HttpPost]
        [Route("InsertClientesPage")]
        public async Task<IActionResult> InsertClientes(ClientesInsertar clientes)
        {
            if (clientes == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _PaginaRepository.InsertClientes(clientes);
            return Created("created", created);
        }
    }
}
