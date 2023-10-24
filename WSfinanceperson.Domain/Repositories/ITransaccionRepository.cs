using ShareKernel.Core;

using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Domain.Repositories
{
    public interface ITransaccionRepository : IRepository<Transaccion, Guid>
    {
        Task UpdateAsync(Transaccion transaccion);
        Task DeleteAsync(Transaccion categoria);
    }
}
