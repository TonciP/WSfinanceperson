using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Events;
using WSfinanceperson.Domain.ValueObjects;

namespace WSfinanceperson.Domain.Models.Personas
{
    public class Persona : AggregateRoot<Guid>
    {
        //public Guid Id { get; private set; }
        public EmailValidValue Correo { get; private set; }
        public Password Contrasena { get; private set; }

        public Persona () { }

        public Persona(string correo, string contrasena)
        {
            this.Id = Guid.NewGuid();
            this.Correo = correo;
            this.Contrasena = contrasena;
            AddDomainEvent(new PersonaCreada(this.Id, DateTime.Now));
        }
    }
}
