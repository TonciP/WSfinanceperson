using ShareKernel.Core;
using WSfinanceperson.Domain.Events;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Personas;
using WSfinanceperson.Domain.Models.Transferencias;
using WSfinanceperson.Domain.ValueObjects;

namespace WSfinanceperson.Domain.Models.Cuentas
{
    public class Cuenta: AggregateRoot<Guid>
    {
        //public Guid Id { get; set; }
        public string Nombre {get; private set; }
        //public decimal SaldoInicial { get; private set; }
        public SaldoCuenta SaldoInicial { get; private set; }
        public Guid PersonaId { get; private set; }

        public Cuenta() { }

        public Cuenta(string nombre, decimal saldoInicial, Guid personaId)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            SaldoInicial = saldoInicial;
            PersonaId = personaId;
            //this._persona.Id = personaId;
            AddDomainEvent(new CuentaCreada(Id, DateTime.Now));
        }

        public void ActualizarCuenta(string nombre, decimal saldoInicial)
        {
            this.Nombre = nombre;
            this.SaldoInicial = saldoInicial;
            //AddDomainEvent(new CuentaCreada(this.Id, DateTime.Now));
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
