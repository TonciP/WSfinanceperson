using ShareKernel.Core;
using WSfinanceperson.Domain.Models.Cuentas;

namespace WSfinanceperson.Domain.Repositories
{
    public interface ICuentaRepository: IRepository<Cuenta, Guid>
    {
        Task UpdateAsync(Cuenta obj);
    }
}
