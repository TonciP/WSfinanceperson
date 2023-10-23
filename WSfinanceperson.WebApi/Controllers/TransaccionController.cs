using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSfinanceperson.Application.UseCases.Command.Categorias.CrearCategoria;
using WSfinanceperson.Application.UseCases.Command.Transacciones.CrearTransaccion;
using WSfinanceperson.Application.UseCases.Command.Transacciones.EliminarTransaccion;

namespace WSfinanceperson.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransaccionController : ControllerBase
    {
        private readonly IMediator _mediator;

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

        [HttpDelete]
        public async Task<IActionResult> EliminarTransaccion([FromBody] EliminarTransaccionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
