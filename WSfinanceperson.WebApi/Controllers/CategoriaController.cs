using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSfinanceperson.Application.UseCases.Command.Categorias.CrearCategoria;
using WSfinanceperson.Application.UseCases.Command.Cuentas.CrearCuenta;
using WSfinanceperson.Application.UseCases.Query.Categoria.CategoriaByCuentaId;
using WSfinanceperson.Application.UseCases.Query.Categoria.GetCategoriaById;
using WSfinanceperson.Application.UseCases.Query.Cuentas.GetCuentaBy;
using WSfinanceperson.Application.UseCases.Query.Cuentas.GetCuentasByPersonaId;

namespace WSfinanceperson.WebApi.Controllers
{

    [Route("api/[controller]")]
    //[Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public static string tipo { get { return "CategoriaController"; } }
        public static string secret { get { return "WSFINANCE3T3N6PSJKWM"; } }

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCategoria([FromBody] CrearCategoriaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [Route("{Id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetCategoriaById([FromRoute] GetCategoriaByIdQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Route("Cuenta/{CuentaId:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetCategoriaByCuentaId([FromRoute] CategoriaByCuentaIdQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
