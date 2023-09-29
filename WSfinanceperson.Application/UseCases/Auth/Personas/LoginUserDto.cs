using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Application.Utils;

namespace WSfinanceperson.Application.UseCases.Auth.Personas
{
    public class LoginUserDto : IRequest<Result<string>>
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public LoginUserDto(string correo, string contrasena)
        {
            Correo = correo;
            Contrasena = contrasena;
        }
    }
}
