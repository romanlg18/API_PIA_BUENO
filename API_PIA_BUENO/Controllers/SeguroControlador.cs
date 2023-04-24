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
    }


}
