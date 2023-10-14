using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Application.UseCases.Auth.Personas;
using WSfinanceperson.Application.UseCases.Command.Categorias.CrearCategoria;
using WSfinanceperson.Application.UseCases.Command.Personas.CrearRegistro;

namespace WSfinanceperson.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonaController : ControllerBase
    {
        private readonly IMediator _mediator;
        //public static string tipo { get { return "PersonaController"; } }
        //public static string secret { get { return "WSFINANCE3T3N6PSJKWM"; } }

        public PersonaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login([FromQuery] string? correo = "", [FromQuery] string? contrasena = "")
        {
            var result = await _mediator.Send(new LoginUserDto(correo, contrasena));
            if (result.Success)
            {
                //return Ok(result.Value.ToString());
                return Ok(new
                {
                    jwt = result.Value,
                });
            }
            else
            {
                return Unauthorized();
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CrearRegistro([FromBody] CrearRegistroCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        //private string GenerateToken(string username)
        //{
        //    var claims = new Claim[]
        //   {
        //    new Claim(ClaimTypes.Name, username),
        //                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
        //    new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
        //            };

        //            var token = new JwtSecurityToken(
        //                new JwtHeader(
        //                    new SigningCredentials(
        //                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
        //                        SecurityAlgorithms.HmacSha256)
        //                        ),
        //                new JwtPayload(claims));
        //            return new JwtSecurityTokenHandler().WriteToken(token);
        //}

    }
}
