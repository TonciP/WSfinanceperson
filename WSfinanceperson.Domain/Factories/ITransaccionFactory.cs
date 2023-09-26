using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Domain.Factories
{
    public interface ITransaccionFactory
    {
        //public decimal Monto { get; private set; }
        //public string Description { get; private set; }
        //public Guid CuentaId { get; private set; }
        //public Movimiento Tipo { get; private set; }
        //public Categoria Categoria { get; private set; }
        Transaccion Create(decimal Monto, string descripcion, Guid cuentaId, Movimiento movimiento);
    }
}
