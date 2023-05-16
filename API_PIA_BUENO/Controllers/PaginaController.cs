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
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

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
            try
            {
                var accountSid = "ACcaa3498f42a49bd9a4399398bf62f31d";
                var authToken = "554a0208b72aa1d9c09e1e85b8fea010";
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                  new PhoneNumber("whatsapp:+5218120741152"));
                messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
                messageOptions.Body = "¡Tienes un nuevo buzon de duda! " + clientes.Nombre+"." + 
                    " Su duda: " + clientes.Mensaje;



                var message = MessageResource.Create(messageOptions);
                return Created("created", created);
            }
            catch
            {
                return Created("created", created);
            }


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


            try
            {
                var accountSid = "ACcaa3498f42a49bd9a4399398bf62f31d";
                var authToken = "554a0208b72aa1d9c09e1e85b8fea010";
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                  new PhoneNumber("whatsapp:+5218120741152"));
                messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
                messageOptions.Body = "¡Solicito asesoría un cliente nuevo!: " + clientes.CL_NOMBRES;


                var message = MessageResource.Create(messageOptions);
                return Created("created", created);
            }
            catch
            {
                return Created("created", created);
            }

        }
    }
}
