using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Transaccion;
using WSfinanceperson.Domain.Models.Transferencias;

namespace WSfinanceperson.Domain.Repositories
{
    public interface ITransferenciaRepository : IRepository<Transferencia, Guid>
    {
        Task UpdateAsync(Transferencia transaccion);
    }
}
