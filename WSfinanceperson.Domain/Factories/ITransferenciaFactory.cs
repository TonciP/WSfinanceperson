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

namespace WSfinanceperson.Domain.Factories
{
    public interface ITransferenciaFactory
    {
        Transferencia Create(DateTime fechaTransaferencia, Guid cuentaOrigenId, Guid cuentaDestinoId, decimal monto, Movimiento tipo, EstadoTransaccion estadoTransaccion);
    }
}
