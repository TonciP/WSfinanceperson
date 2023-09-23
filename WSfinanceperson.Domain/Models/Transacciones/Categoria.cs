using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Domain.Models.Transaccion
{
    public class Categoria: Entity<Guid>
    {
        public Guid CuentaId { get; private set; }
        public string Nombre { get; private set; }

        public Categoria(Guid cuentaId, string nombre) 
        {
            Id = Guid.NewGuid();
            this.CuentaId = cuentaId;
            this.Nombre = nombre;
        }

    }
}
