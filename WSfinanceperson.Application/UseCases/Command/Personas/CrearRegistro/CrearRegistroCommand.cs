using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Application.UseCases.Command.Personas.CrearRegistro
{
    public class CrearRegistroCommand : IRequest<Guid>
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }

        public CrearRegistroCommand()
        {

        }

        public CrearRegistroCommand(string correo, string contrasena)
        {
            Correo = correo;
            Contrasena = contrasena;
        }
    }
}
