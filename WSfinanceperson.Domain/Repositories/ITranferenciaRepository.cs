using ShareKernel.Core;
using WSfinanceperson.Domain.Models.Transferencias;

namespace WSfinanceperson.Domain.Repositories
{
    public interface ITransferenciaRepository : IRepository<Transferencia, Guid>
    {
        Task UpdateAsync(Transferencia transaccion);
        Task DeleteAsync(Transferencia categoria);
    }
}
