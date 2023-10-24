using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WSfinanceperson.Application.UseCases.Query.Cuentas.SaldoTotal;
using WSfinanceperson.Application.UseCases.Query.Transacciones.Historial;

namespace WSfinanceperson.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsultasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("historialMovimientoTransaccion")]
        [HttpGet]
        public async Task<IActionResult> HistorialMovimientoTransaccion([FromQuery] HistorialTransaccionesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [Route("resumenFinanzas")]
        [HttpGet]
        public async Task<IActionResult> ResumenFinanzas([FromQuery] HistorialTransferenciaQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Route("saldoTotal")]
        [HttpGet]
        public async Task<IActionResult> SaldoTotal()
        {
            var query = new SaldoTotalQuery
            {
                PersonaId = new Guid(GetName())
            };  
            var result = await _mediator.Send(query);
            return Ok(result);
        }

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
