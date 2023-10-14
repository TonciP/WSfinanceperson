using Inventario.Domain.Models.Transacciones;
using ShareKernel.Core;
using WSfinanceperson.Domain.Events;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Models.Transaccion;
using WSfinanceperson.Domain.ValueObjects;

namespace WSfinanceperson.Domain.Models.Transferencias
{
    public class Transferencia: AggregateRoot<Guid>
    {
        //public Guid Id { get; private set; }
        public DateTime FechaTransaferencia { get; private set; }
        public Guid CuentaOrigenId { get; private set; }
        private readonly Cuenta cuentaorigen;

        public Cuenta CuentaOrigen
        {
            get
            {
                return cuentaorigen;
            }
        }
        public Guid CuentaDestinoId { get; private set; }
        private readonly Cuenta cuentadestino;

        public Cuenta CuentaDestino
        {
            get
            {
                return cuentadestino;
            }
        }
        //public decimal Monto { get; private set; }
        public MontoTransferencia Monto { get; private set; }
        public Movimiento Tipo { get; private set; }
        public EstadoTransaccion Estado { get; private set; }
        //public Guid CateogriaId { get; private set; }
        //private readonly Categoria _categoria;

        //public Categoria Categoria
        //{
        //    get
        //    {
        //        return _categoria;
        //    }
        //}
        public Transferencia() { }

        public Transferencia(DateTime fechaTransaferencia, Guid cuentaOrigen, Guid cuentaDestino, decimal monto)
        {
            Id = Guid.NewGuid();
            FechaTransaferencia = fechaTransaferencia;
            CuentaOrigenId = cuentaOrigen;
            CuentaDestinoId = cuentaDestino;
            Monto = monto;
        }

        public Transferencia(DateTime fechaTransaferencia, Guid cuentaOrigen, Guid cuentaDestino, decimal monto, Movimiento movimiento, EstadoTransaccion estadoTransaccion)
        {
            Id = Guid.NewGuid();
            FechaTransaferencia = fechaTransaferencia;
            CuentaOrigenId = cuentaOrigen;
            CuentaDestinoId = cuentaDestino;
            Monto = monto;
            Tipo = movimiento;
            Estado = estadoTransaccion;
            AddDomainEvent(new TransferenciaCreada(cuentaOrigen, cuentaDestino, monto, DateTime.Now));
        }
    }
}
