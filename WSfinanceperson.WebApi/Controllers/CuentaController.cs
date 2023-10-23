using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WSfinanceperson.Application.UseCases.Command.Cuentas.ActualizarCuenta;
using WSfinanceperson.Application.UseCases.Command.Cuentas.CrearCuenta;
using WSfinanceperson.Application.UseCases.Command.Cuentas.EliminarCuenta;
using WSfinanceperson.Application.UseCases.Query.Cuentas.GetCuentaBy;
using WSfinanceperson.Application.UseCases.Query.Cuentas.GetCuentasByPersonaId;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WSfinanceperson.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CuentaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public static string tipo { get { return "CuentaController"; } }

        public CuentaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCuenta([FromBody] CrearCuentaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarCuenta([FromBody] EliminarCuentaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Route("CrearCuentaPersona")]
        [HttpPost]
        public async Task<IActionResult> CrearCuentaPersona([FromBody] CrearCuentaCommand command)
        {
            var result = await _mediator.Send(new CrearCuentaCommand
            {
                Nombre = command.Nombre,
                saldoInicial = command.saldoInicial,
                PersonaId = new Guid(GetName())
            });
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCuenta([FromBody] ActualizarCuentaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Route("{Id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetCuentaById([FromRoute] GetCuentaByIdQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[Route("Persona/{PersonaId:guid}")]
        [Route("Persona")]
        [HttpGet]
        public async Task<IActionResult> GetCuentaByPersonaId(
        //[FromRoute] GetCuentasByPersonaIdQuery command
            )
        {
            var query = new GetCuentasByPersonaIdQuery
            {
                PersonaId = new Guid(GetName())
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [NonAction]
        protected string GetName()
        {
            string token = Request.Headers["Authorization"];
            token = token.Replace("Bearer ", "").Trim();
            string secret = "WSFINANCE3T3N6PSJKWM";
            var key = Encoding.ASCII.GetBytes(secret);
            var handler = new JwtSecurityTokenHandler();
            var tokenSecure = handler.ReadToken(token) as SecurityToken;
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            try
            {
                var claims = handler.ValidateToken(token, validations, out tokenSecure);
                return claims.Identity.Name;
            }
            catch (Exception)
            { }
            return "";
        }

    }
}
