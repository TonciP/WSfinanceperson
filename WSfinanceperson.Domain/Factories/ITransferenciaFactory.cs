
using WSfinanceperson.Domain.Models.Transaccion;
using WSfinanceperson.Domain.Models.Transacciones;
using WSfinanceperson.Domain.Models.Transferencias;

namespace WSfinanceperson.Domain.Factories
{
    public interface ITransferenciaFactory
    {
        Transferencia Create(Guid cuentaOrigenId, Guid cuentaDestinoId, decimal monto, Movimiento tipo, EstadoTransaccion estadoTransaccion);
        Transferencia CrearTransaccionEgreso();
        Transferencia CrearTransaccionIngreso();
    }
}
