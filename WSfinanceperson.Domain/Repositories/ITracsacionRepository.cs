using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Domain.Repositories
{
    public interface ITracsacionRepository : IRepository<Transaccion, Guid>
    {
        Task UpdateAsync(Transaccion transaccion);
    }
}
