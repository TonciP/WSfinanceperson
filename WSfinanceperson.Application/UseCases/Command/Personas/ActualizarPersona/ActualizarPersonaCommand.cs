using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Application.UseCases.Command.Personas.ActualizarPersona
{
    public class ActualizarPersonaCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Correo { get; set; }
        public ActualizarPersonaCommand() { }
        public ActualizarPersonaCommand(string correo)
        {
            this.Correo = correo;
        }
    }
}
