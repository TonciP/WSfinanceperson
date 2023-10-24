using WSfinanceperson.Domain.Models.Transacciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Application.Dto
{
    public class TransferenciaDto
    {
        public Guid Id { get;  set; }
        public DateTime FechaTransferencia { get;  set; }
        public CuentaDto CuentaOrigen { get; set; }
        public Guid CuentaOrigenId { get; set; }

        public CuentaDto CuentaDestino { get; set; }
        public Guid CuentaDestinoId { get; set; }
        public decimal Monto { get;  set; }
        public string Tipo { get;  set; }
        public string Estado { get;  set; }
    }
}
