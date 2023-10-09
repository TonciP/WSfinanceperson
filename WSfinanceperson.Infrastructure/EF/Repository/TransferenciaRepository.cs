using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Transaccion;
using WSfinanceperson.Domain.Models.Transferencias;
using WSfinanceperson.Domain.Repositories;
using WSfinanceperson.Infrastructure.EF.Contexts;

namespace WSfinanceperson.Infrastructure.EF.Repository
{
    public class TransferenciaRepository : ITransferenciaRepository
    {
        public readonly DbSet<Transferencia> _transferencia;
        public TransferenciaRepository(WriteDbContext context)
        {
            _transferencia = context.Transferencia;
        }
        public async Task CreateAsync(Transferencia obj)
        {
            await _transferencia.AddAsync(obj);
        }

        public Task<Transferencia> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Transferencia transaccion)
        {
            _transferencia.Update(transaccion);
            return Task.CompletedTask;
        }
    }
}
