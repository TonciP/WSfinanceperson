using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Application.UseCases.Command.Cuentas.CrearCuenta
{
    public class CrearCuentaCommand : IRequest<Guid>
    {
        public string NombreCuenta { get; set; }    
        public Guid PersonaId { get; set; }

        public CrearCuentaCommand(string nombreCuenta, Guid personaId)
        {
            NombreCuenta = nombreCuenta;
            PersonaId = personaId;
        }

        public CrearCuentaCommand()
        {
        }

    }
}
