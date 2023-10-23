using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Models.Personas;
using WSfinanceperson.Domain.Models.Transaccion;
using WSfinanceperson.Domain.Repositories;
using WSfinanceperson.Infrastructure.EF.Contexts;

namespace WSfinanceperson.Infrastructure.EF.Repository
{
    public class TransaccionRepository : ITransaccionRepository
    {
        public readonly DbSet<Transaccion> _transaccion;

        public TransaccionRepository(WriteDbContext context)
        {
            _transaccion = context.Transaccion;
        }
        public async Task CreateAsync(Transaccion obj)
        {
            await _transaccion.AddAsync(obj);
        }

        public async Task<Transaccion> FindByIdAsync(Guid id)
        {
            return await Task.FromResult(_transaccion.Find(id));
        }

        public async Task UpdateAsync(Transaccion transaccion)
        {
            await Task.FromResult(_transaccion.Update(transaccion));
        }

        public Task DeleteAsync(Transaccion obj)
        {
            _transaccion.Remove(obj);

            return Task.CompletedTask;
        }
    }
}
