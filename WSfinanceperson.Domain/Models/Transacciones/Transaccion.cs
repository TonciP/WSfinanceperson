using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;

namespace WSfinanceperson.Domain.Models.Transaccion
{
    public class Transaccion : AggregateRoot<Guid>
    {
        public Guid Id { get; private set; }
        public decimal Monto { get; private set; }
        public string Descripcion { get; private set; }
        public Guid CuentaId { get; private set; }
        public Movimiento Tipo { get; private set; }
        public Categoria Categoria { get; private set; }

        public Transaccion() { }

        public Transaccion(decimal monto, string descripcion, Guid cuentaId, Movimiento tipo, Categoria categoria)
        {
            Id = Guid.NewGuid();
            Monto = monto;
            Descripcion = descripcion;
            CuentaId = cuentaId;
            Tipo = tipo;
            Categoria = categoria;
        }
    }
}
