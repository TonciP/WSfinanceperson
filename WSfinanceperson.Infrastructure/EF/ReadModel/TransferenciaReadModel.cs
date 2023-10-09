using Inventario.Domain.Models.Transacciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Infrastructure.EF.ReadModel
{
    public class TransferenciaReadModel
    {
        public Guid Id { get; set; }
        public DateTime FechaTransferencia { get; set; }
        public Guid CuentaOrigenId { get; set; }
        ////public CuentaReadModel CuentaOrigen;

        public Guid CuentaDestinoId { get; set; }
        //public CuentaReadModel CuentaDestino;
        public decimal Monto { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
    }
}
