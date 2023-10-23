using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Transaccion;
using WSfinanceperson.Domain.Models.Transacciones;

namespace WSfinanceperson.Domain.Factories
{
    public interface ITransaccionFactory
    {
        Transaccion Create(decimal Monto, string descripcion, Guid cuentaId, Movimiento movimiento, EstadoTransaccion estadoTransaccion, Guid categoriaId);

        Transaccion CrearTransaccionIngreso();
        Transaccion CrearTransaccionEgreso();
    }
}
