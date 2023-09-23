using MediatR;
using Microsoft.AspNetCore.Mvc;
using WSfinanceperson.Application.UseCases.Command.Cuentas.CrearCuenta;

namespace WSfinanceperson.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CuentaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public static string tipo { get { return "CuentaController"; } }
        public static string secret { get { return "WSFINANCE3T3N6PSJKWM"; } }

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

    }
}
