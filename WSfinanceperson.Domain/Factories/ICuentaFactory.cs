using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Cuentas;

namespace WSfinanceperson.Domain.Factories
{
    public interface ICuentaFactory
    {
        Cuenta Create(string nombre, Guid personaId);
    }
}
