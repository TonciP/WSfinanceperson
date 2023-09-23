using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Domain.Models.Personas
{
    public class Persona: AggregateRoot<Guid>
    {
        public Guid Id { get; private set; }
        public string Correo { get; private set; }
        public string Contrasena { get; private set; }

        public Persona () { }

        public Persona(string correo, string contrasena)
        {
            this.Id = new Guid();
            this.Correo = correo;
            this.Contrasena = contrasena;
        }
    }
}
