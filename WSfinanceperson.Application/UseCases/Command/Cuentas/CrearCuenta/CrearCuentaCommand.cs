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
        public decimal saldoInicial { get; set; }
        public Guid PersonaId { get; set; }

        public CrearCuentaCommand(string nombreCuenta, decimal saldoInicial, Guid personaId)
        {
            NombreCuenta = nombreCuenta;
            this.saldoInicial = saldoInicial;
            PersonaId = personaId;
        }

        public CrearCuentaCommand()
        {
        }

    }
}
