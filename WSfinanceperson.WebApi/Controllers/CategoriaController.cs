using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WSfinanceperson.Application.UseCases.Command.Categorias.ActualizarCategoria;
using WSfinanceperson.Application.UseCases.Command.Categorias.CrearCategoria;
using WSfinanceperson.Application.UseCases.Command.Categorias.EliminarCategoria;
using WSfinanceperson.Application.UseCases.Command.Cuentas.CrearCuenta;
using WSfinanceperson.Application.UseCases.Query.Categoria.CategoriaByCuentaId;
using WSfinanceperson.Application.UseCases.Query.Categoria.GetCategoriaById;
using WSfinanceperson.Application.UseCases.Query.Categoria.GetCategoriasByPersonaId;
using WSfinanceperson.Application.UseCases.Query.Cuentas.GetCuentaBy;
using WSfinanceperson.Application.UseCases.Query.Cuentas.GetCuentasByPersonaId;

namespace WSfinanceperson.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;

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

        [HttpPut]
        public async Task<IActionResult> ActualizarCategoria([FromBody] ActualizarCategoriaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[HttpDelete]
        //public async Task<IActionResult> EliminarCategoria([FromBody] EliminarCategoriaCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}


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

        [Route("GetCategoriaByPersona")]
        [HttpGet]
        public async Task<IActionResult> GetCategoriaByPersonaId()
        {
            var result = await _mediator.Send(new GetCategoriasByPersonaIdQuery
            {
                PersonaId = new Guid(GetName())
            });
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
