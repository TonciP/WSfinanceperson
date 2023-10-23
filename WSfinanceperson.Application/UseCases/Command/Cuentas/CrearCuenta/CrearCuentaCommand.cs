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
        public string Nombre { get; set; }    
        public decimal saldoInicial { get; set; }
        public Guid PersonaId { get; set; }

        public CrearCuentaCommand(string nombre, decimal saldoInicial, Guid personaId)
        {
            Nombre = nombre;
            this.saldoInicial = saldoInicial;
            PersonaId = personaId;
        }

        public CrearCuentaCommand()
        {
        }

    }
}
