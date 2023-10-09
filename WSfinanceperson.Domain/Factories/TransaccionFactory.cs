using Inventario.Domain.Models.Transacciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Domain.Factories
{
    public class TransaccionFactory : ITransaccionFactory
    {
        public Transaccion CrearTransaccionEgreso()
        {
            return new Transaccion(Movimiento.Egreso);
        }

        public Transaccion CrearTransaccionIngreso()
        {
            return new Transaccion(Movimiento.Ingreso);
        }

        public Transaccion Create(decimal monto, string descripcion, Guid cuentaId, Movimiento movimiento, EstadoTransaccion estadoTransaccion, Guid categoriaId)
        {
            return new Transaccion(monto, descripcion,cuentaId, movimiento, estadoTransaccion, categoriaId);
        }
    }
}
