using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;

namespace WSfinanceperson.Domain.Factories
{
    public class CategoriaFactory : ICategoriaFactory
    {

        public Categoria Create(Guid cuentaId, string nombre)
        {
            var obj = new Categoria(cuentaId, nombre);
            return obj;
        }
    }
}
