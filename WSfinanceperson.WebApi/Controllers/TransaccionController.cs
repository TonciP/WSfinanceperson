using MediatR;
using Microsoft.AspNetCore.Mvc;
using WSfinanceperson.Application.UseCases.Command.Categorias.CrearCategoria;
using WSfinanceperson.Application.UseCases.Command.Transacciones.CrearTransaccion;

namespace WSfinanceperson.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TransaccionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public static string tipo { get { return "TransaccionController"; } }
        public static string secret { get { return "WSFINANCE3T3N6PSJKWM"; } }

        public TransaccionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CrearTransaccion([FromBody] CrearTransaccionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[Route("CrearCategoria")]
    }
}
