using Inventario.Domain.Models.Transacciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Application.UseCases.Command.Transferencia.CrearTransferencia
{
    public class CrearTransferenciaCommand : IRequest<Guid> 
    {
        public DateTime FechaTransaferencia { get;  set; }
        public Guid CuentaOrigenId { get;  set; }
        public Guid CuentaDestinoId { get;  set; }
        public decimal Monto { get;  set; }
        public Movimiento Tipo { get;  set; }
        public EstadoTransaccion Estado { get;  set; }
    }
}
