using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Repositories;
using WSfinanceperson.Infrastructure.EF.Contexts;

namespace WSfinanceperson.Infrastructure.EF.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public readonly DbSet<Categoria> _categorias;

        public CategoriaRepository(WriteDbContext context)
        {
            _categorias = context.Categoria;
        }
        public async Task CreateAsync(Categoria obj)
        {
            await _categorias.AddAsync(obj);
        }

        public Task<Categoria> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Categoria obj)
        {
            throw new NotImplementedException();
        }
    }
}
