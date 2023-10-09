using Inventario.Domain.Models.Transacciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Models.Transaccion;
using WSfinanceperson.Domain.Models.Transferencias;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WSfinanceperson.Domain.Factories
{
    public class TransferenciaFactory : ITransferenciaFactory
    {
        public Transferencia Create(DateTime fechaTransaferencia, Guid cuentaOrigenId, Guid cuentaDestinoId, decimal monto, Movimiento tipo, EstadoTransaccion estadoTransaccion)
        {
            var obj = new Transferencia(fechaTransaferencia, cuentaOrigenId, cuentaDestinoId, monto, tipo, estadoTransaccion);
            return obj;
        }
    }
}
