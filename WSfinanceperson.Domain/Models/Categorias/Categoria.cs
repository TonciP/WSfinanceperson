using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Domain.Models.Categorias
{
    public class Categoria : AggregateRoot<Guid>
    {
        //public Guid Id { get; private set; }
        public Guid CuentaId { get; private set; }
        public string Nombre { get; private set; }

        public Categoria(Guid cuentaId, string nombre)
        {
            Id = Guid.NewGuid();
            CuentaId = cuentaId;
            Nombre = nombre;
        }

    }
}
