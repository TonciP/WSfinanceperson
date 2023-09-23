using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Personas;

namespace WSfinanceperson.Domain.Repositories
{
    public interface IPersonaRepository : IRepository<Persona, Guid>
    {
        Task UpdateAsync(Persona obj);
    }
}
