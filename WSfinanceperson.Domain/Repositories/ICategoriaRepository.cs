using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;

namespace WSfinanceperson.Domain.Repositories
{
    public interface ICategoriaRepository
        : IRepository<Categoria, Guid>
    {
        Task UpdateAsync(Categoria obj);
    }
}
