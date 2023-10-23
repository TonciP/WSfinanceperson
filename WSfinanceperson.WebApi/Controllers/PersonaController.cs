using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Application.UseCases.Auth.Personas;
using WSfinanceperson.Application.UseCases.Command.Categorias.CrearCategoria;
using WSfinanceperson.Application.UseCases.Command.Personas.ActualizarPersona;
using WSfinanceperson.Application.UseCases.Command.Personas.CrearRegistro;

namespace WSfinanceperson.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                //return Ok(result.Value.ToString());
                return Ok(new
                {
                    jwt = result.Value,
                });
            }
            else
            {
                return Unauthorized();
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CrearRegistro([FromBody] CrearRegistroCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> ActualizarRegistro([FromBody] ActualizarPersonaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
