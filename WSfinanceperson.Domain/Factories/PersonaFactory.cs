using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Personas;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WSfinanceperson.Domain.Factories
{
    public class PersonaFactory : IPersonaFactory
    {
        public Persona Create(string correo, string contrasena)
        {
            var obj = new Persona(correo, contrasena);
            //var domainEvent = new ArticuloCreado(obj.Id, nombre, precioVenta, DateTime.Now);

            //obj.AddDomainEvent(domainEvent);

            return obj;
        }
    }
}
