using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSfinanceperson.Application.UseCases.Query.Transacciones.Historial;

namespace WSfinanceperson.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ConsultasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public static string tipo { get { return "PersonaController"; } }
        public static string secret { get { return "WSFINANCE3T3N6PSJKWM"; } }

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
            return Ok();
        }
    }
}
