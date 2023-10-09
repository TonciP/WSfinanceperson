using MediatR;
using Microsoft.AspNetCore.Mvc;
using WSfinanceperson.Application.UseCases.Command.Transacciones.CrearTransaccion;
using WSfinanceperson.Application.UseCases.Command.Transferencia.CrearTransferencia;

namespace WSfinanceperson.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TransferenciaController : ControllerBase
    {

        private readonly IMediator _mediator;
        public static string tipo { get { return "TransferenciaController"; } }
        public static string secret { get { return "WSFINANCE3T3N6PSJKWM"; } }

        public TransferenciaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CrearTransferencia([FromBody] CrearTransferenciaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
