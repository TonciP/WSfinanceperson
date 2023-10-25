using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Application.UseCases.Command.Transferencias.EliminarTransferencia
{
    public class EliminarTransferenciaCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        //public EliminarTransferenciaCommand(Guid id)
        //{
        //    this.Id = id;
        //}
        //public EliminarTransferenciaCommand() { }
    }
}
