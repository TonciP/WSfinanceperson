using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Application.UseCases.Command.Cuentas.EliminarCuenta
{
    public class EliminarCuentaCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public EliminarCuentaCommand(Guid id)
        {
            this.Id = id;
        }
        public EliminarCuentaCommand()
        {
        }
    }
}
