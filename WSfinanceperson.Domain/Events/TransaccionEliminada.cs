using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Domain.Events
{
    public record TransaccionEliminada : DomainEvent
    {
        public Guid CuentaId { get; }
        public decimal Monto { get; }
        public Movimiento Tipo { get; }
        public TransaccionEliminada(Guid cuentaId, decimal monto,  DateTime occuredOn) : base(occuredOn)
        {
            CuentaId = cuentaId;
            Monto = monto;
        }
    }
}
