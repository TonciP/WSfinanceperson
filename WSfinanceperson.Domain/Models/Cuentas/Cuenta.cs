using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Personas;
using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Domain.Models.Cuentas
{
    public class Cuenta: AggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public string Nombre {get; private set; }
        public double SaldoInicial { get; private set; }
        public Guid PersonaId { get; private set; }
        private readonly Persona _persona;

        public Persona Persona
        {
            get
            {
                return _persona;
            }
        } 

        private readonly List<Categoria> _categoria;
        public IEnumerable<Categoria> Categorias
        {
            get
            {
                return _categoria;
            }
        }

        public Cuenta() { }

        public Cuenta(string nombre, Guid personaId)
        {
            this.Id = Guid.NewGuid();
            this.Nombre = nombre;
            this.SaldoInicial = 0;
            this.PersonaId = personaId;
            //this._persona.Id = personaId;
            _categoria = new List<Categoria>();
        }
        public void AdicionarCategoriaDefault(Guid cuentaId)
        {
            Categoria Alimentacion = new Categoria(cuentaId, "Alimentacion");
            Categoria Transporte = new Categoria(cuentaId, "Transporte");
            Categoria Entretenimiento = new Categoria(cuentaId, "Entretenimiento");

            _categoria.Add(Alimentacion);
            _categoria.Add(Transporte);
            _categoria.Add(Entretenimiento);
        }
    }
}
