using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSfinanceperson.Application.UseCases.Command.Transacciones.CrearTransaccion;
using WSfinanceperson.Application.UseCases.Command.Transferencias.CrearTransferencia;
using WSfinanceperson.Application.UseCases.Command.Transferencias.EliminarTransferencia;

namespace WSfinanceperson.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransferenciaController : ControllerBase
    {

        private readonly IMediator _mediator;

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

        [HttpDelete("{Id:Guid}")]
        public async Task<IActionResult> EliminarTransferencia(Guid Id)
        {
            var result = await _mediator.Send(new EliminarTransferenciaCommand
            {
                Id = Id
            });
            return Ok(result);
        }

    }
}
