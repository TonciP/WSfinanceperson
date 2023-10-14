using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Application.UseCases.Command.Cuentas.CrearCuentaToken
{
    public class CrearCuentaTokenCommand : IRequest<Guid>
    {
        public string NombreCuenta { get; set; }
        public decimal saldoInicial { get; set; }
        public Guid PersonaId { get; set; }

        public CrearCuentaTokenCommand(string nombreCuenta,  decimal saldoInicial
            , Guid personaId
            )
        {
            this.NombreCuenta = nombreCuenta;
            this.saldoInicial = saldoInicial;
            this.PersonaId = personaId;
        }

        public CrearCuentaTokenCommand()
        {
        }
    }
}
