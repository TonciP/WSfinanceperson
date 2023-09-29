using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Application.Dto
{
    public class PersonaDto
    {
        public Guid Id { get;  set; }
        public string Correo { get;  set; }
        public string Contrasena { get;  set; }
    }
}
