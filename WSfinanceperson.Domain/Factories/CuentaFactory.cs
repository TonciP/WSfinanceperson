using SharedKernel.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Events;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WSfinanceperson.Domain.Factories
{
    public class CuentaFactory : ICuentaFactory
    {
        public Cuenta Create(string nombre,Guid personaId)
        {
            var obj = new Cuenta(nombre, personaId);
            //var domainEvent = new CuentaCreada(obj.Id, nombre, precioVenta, DateTime.Now);

            //obj.AddDomainEvent(domainEvent);

            return obj;
        }

    }
}
