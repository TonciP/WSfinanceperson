using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;

namespace WSfinanceperson.Domain.Factories
{
    public interface ICategoriaFactory
    {
        Categoria Create(Guid cuentaId, string nombre);
        //Categoria CreateRange(Categoria[] categorias);
    }
}
