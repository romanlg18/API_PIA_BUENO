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
    public class SeguroControlador : ControllerBase
    {
        private readonly ISegurosRepository _SeguroRepository;
        public SeguroControlador(ISegurosRepository SeguroRepository)
        {
            _SeguroRepository = SeguroRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllClient()
        {
            return Ok(await _SeguroRepository.GetAllClient());
        }

        [HttpGet]
        [Route("seguros")]
        public async Task<IActionResult> GetSeguros()
        {
            return Ok(await _SeguroRepository.GetSeguros());
        }

        [HttpGet]
        [Route("GetIDSeguros")]
        public async Task<IActionResult> GetSegurosID(int idSeguros)
        {
            var result = await _SeguroRepository.GetSegurosID(idSeguros);
            Console.Write(result.Count());
            if (result.Count() < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { error = "No se encontró el seguro indicado" });
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPut]
        [Route("UpdateSeguros")]
        public async Task<IActionResult> UpdateSeguros(int idSeguros, UpdateSeguros seguros)
        {
            if (seguros == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _SeguroRepository.UpdateSeguros(idSeguros, seguros);
            return Ok();
        }


        [HttpPost]
        [Route("InsertSeguros")]
        public async Task<IActionResult> SegurosInsertar(SegurosInsertar seguros)
        {
            if (seguros == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _SeguroRepository.InsertSeguros(seguros);
            return Created("created", created);
        }


        [HttpDelete]
        [Route("DeleteSeguros")]
        public async Task<IActionResult> BorrarCliente(int idSeguros, DeleteSeguros seguros)
        {
            await _SeguroRepository.BorrarSeguros(idSeguros, seguros);
            return Ok();
        }
    }


}
