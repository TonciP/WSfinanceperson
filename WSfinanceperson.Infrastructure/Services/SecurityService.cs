using Microsoft.Extensions.Logging;
using Security.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Application.Services;
using WSfinanceperson.Application.Utils;
using WSfinanceperson.Domain.Models.Personas;

namespace WSfinanceperson.Infrastructure.Services
{
    internal class SecurityService : ISecurityService
    {
        private readonly Persona _persona;
        private readonly JwtOptions _jwtOptions;
        private readonly ILogger<SecurityService> _logger;

        public SecurityService(Persona persona, JwtOptions jwtOptions,
            ILogger<SecurityService> logger)
        {
            _persona = persona;
            _jwtOptions = jwtOptions;
            _logger = logger;
        }
        public Task<Result<string>> Login(string correo, string contrasena)
        {
            //var user = _persona.
            throw new NotImplementedException();
        }

        public Task<Result> Register(RegisterUserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
