using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Infrastructure.EF.ReadModel
{
    public class PersonaReadModel
    {
        public Guid Id { get; private set; }
        public string Correo { get; private set; }
        public string Contrasena { get; private set; }
    }
}
