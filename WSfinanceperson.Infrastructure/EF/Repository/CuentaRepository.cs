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
    public class CuentaRepository : ICuentaRepository
    {
        public readonly DbSet<Cuenta> _cuentas;

        public CuentaRepository(WriteDbContext context)
        {
            _cuentas = context.Cuenta;
        }
        public async Task CreateAsync(Cuenta obj)
        {
            await _cuentas.AddAsync(obj);
        }

        public async Task<Cuenta> FindByIdAsync(Guid id)
        {
            return await _cuentas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Cuenta obj)
        {
            _cuentas.Update(obj);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Cuenta obj)
        {
            _cuentas.Remove(obj);

            return Task.CompletedTask;
        }
    }
}
