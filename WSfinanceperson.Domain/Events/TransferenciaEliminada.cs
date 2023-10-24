using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Domain.Events
{
    public record TransferenciaEliminada : DomainEvent
    {
        public Guid CuentaOrigenId { get; }
        public Guid CuentaDestinoId { get; }
        public decimal Monto { get; }
        public Movimiento Tipo { get; }
        public TransferenciaEliminada(Guid cuentaOrigenId, Guid cuentaDestinoId, decimal monto, DateTime occuredOn) : base(occuredOn)
        {
            CuentaOrigenId = cuentaOrigenId;
            Monto = monto;
            CuentaDestinoId = cuentaDestinoId;
        }
    }
}
