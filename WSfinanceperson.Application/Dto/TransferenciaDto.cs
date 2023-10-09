using Inventario.Domain.Models.Transacciones;
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
        public DateTime FechaTransaferencia { get;  set; }
        //public CuentaDto CuentaOrigen;
        public Guid CuentaOrigenId;

        //public CuentaDto CuentaDestino;
        public Guid CuentaDestinoId;
        public decimal Monto { get;  set; }
        public string Tipo { get;  set; }
        public string Estado { get;  set; }
    }
}
