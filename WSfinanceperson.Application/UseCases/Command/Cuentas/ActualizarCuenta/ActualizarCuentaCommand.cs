using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Personas;

namespace WSfinanceperson.Application.UseCases.Command.Cuentas.ActualizarCuenta
{
    public class ActualizarCuentaCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public decimal saldoInicial { get; set; }

        public ActualizarCuentaCommand(Guid id,string nombre, decimal saldoInicial)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.saldoInicial = saldoInicial;

        }

        public ActualizarCuentaCommand()
        {
        }
    }
}
