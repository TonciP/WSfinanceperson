using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Task<Cuenta> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Cuenta obj)
        {
            throw new NotImplementedException();
        }
    }
}
