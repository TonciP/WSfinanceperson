using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Domain.Models.Transaccion
{
    public class Transaccion : AggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public decimal Monto { get; private set; }
        public string Description { get; private set; }
        public Guid CuentaId { get; private set; }
        public Movimiento Tipo { get; private set; }
        public Categoria Categoria { get; private set; }
    }
}
