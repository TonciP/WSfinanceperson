using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Application.UseCases.Command.Transacciones.EliminarTransaccion
{
    public class EliminarTransaccionCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public EliminarTransaccionCommand(Guid id)
        {
            this.Id = id;
        }
        public EliminarTransaccionCommand() { }
    }
}
