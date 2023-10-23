
using WSfinanceperson.Domain.Models.Transaccion;
using WSfinanceperson.Domain.Models.Transacciones;
using WSfinanceperson.Domain.Models.Transferencias;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WSfinanceperson.Domain.Factories
{
    public class TransferenciaFactory : ITransferenciaFactory
    {
        public Transferencia Create(Guid cuentaOrigenId, Guid cuentaDestinoId, decimal monto, Movimiento tipo, EstadoTransaccion estadoTransaccion)
        {
            var obj = new Transferencia(cuentaOrigenId, cuentaDestinoId, monto, tipo, estadoTransaccion);
            return obj;
        }
        public Transferencia CrearTransaccionEgreso()
        {
            return new Transferencia(Movimiento.Egreso);
        }

        public Transferencia CrearTransaccionIngreso()
        {
            return new Transferencia(Movimiento.Ingreso);
        }
    }
}
