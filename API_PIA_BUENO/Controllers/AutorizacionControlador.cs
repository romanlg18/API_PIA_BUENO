using API_PIA_BUENO.API_PROG.data.Repositorios;
using API_PIA_BUENO.API_PROG.model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
namespace API_PIA_BUENO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizacionController : ControllerBase
    {
        private readonly string secretkey;
        private readonly string connection;

        public AutorizacionController(IConfiguration config)
        {
            secretkey = config.GetSection("settings").GetSection("secretkey").ToString();
            connection = config.GetConnectionString("MySqlConnection");
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult validate([FromBody] login request)
        {
            List<string> validationList = AutorizacionRepositorio.getToken(connection, request);

            if (validationList[0] == "00")
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretkey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.User));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature),

                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string createdToken = tokenHandler.WriteToken(tokenConfig);
                return StatusCode(StatusCodes.Status200OK, new { access_token = createdToken });

            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { access_token = "" });
            }

        }

    }
}
