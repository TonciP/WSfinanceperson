using ShareKernel.Core;
using WSfinanceperson.Domain.Events;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Personas;
using WSfinanceperson.Domain.Models.Transferencias;

namespace WSfinanceperson.Domain.Models.Cuentas
{
    public class Cuenta: AggregateRoot<Guid>
    {
        //public Guid Id { get; set; }
        public string Nombre {get; private set; }
        public decimal SaldoInicial { get; private set; }
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
            AddDomainEvent(new CuentaCreada(this.Id, DateTime.Now));
        }
        public void ActualizarSaldoTransaccion(decimal monto)
        {
            this.SaldoInicial -= monto;
        }
        public void ActualizarSaldoTransferencia(decimal monto)
        {
            this.SaldoInicial += monto;
        }
    }
}
