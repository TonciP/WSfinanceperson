using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Personas;

namespace WSfinanceperson.Domain.Factories
{
    public interface IPersonaFactory
    {
        Persona Create(string correo, string contrasena);
    }
}
