using ShareKernel.Core;
using System.Threading;
using WSfinanceperson.Domain.Events;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Models.Transaccion;
using WSfinanceperson.Domain.Models.Transacciones;
using WSfinanceperson.Domain.ValueObjects;

namespace WSfinanceperson.Domain.Models.Transferencias
{
    public class Transferencia: AggregateRoot<Guid>
    {
        //public Guid Id { get; private set; }
        public FechaTransaccion FechaTransaferencia { get; private set; }
        public Guid CuentaOrigenId { get; private set; }
        public Guid CuentaDestinoId { get; private set; }

        //public decimal Monto { get; private set; }
        public MontoTransferencia Monto { get; private set; }
        public Movimiento Tipo { get; private set; }
        public EstadoTransaccion Estado { get; private set; }

        public Transferencia() { }
        public Transferencia(Movimiento tipo) 
        {
            Tipo = tipo;
            Estado = EstadoTransaccion.Registrado;
        }

        //public Transferencia(DateTime fechaTransaferencia, Guid cuentaOrigen, Guid cuentaDestino, decimal monto)
        //{
        //    Id = Guid.NewGuid();
        //    FechaTransaferencia = fechaTransaferencia;
        //    CuentaOrigenId = cuentaOrigen;
        //    CuentaDestinoId = cuentaDestino;
        //    Monto = monto;
        //}

        //public Transferencia(DateTime fechaTransaferencia, Guid cuentaOrigen, Guid cuentaDestino, decimal monto, Movimiento movimiento, EstadoTransaccion estadoTransaccion)
        //{
        //    Id = Guid.NewGuid();
        //    FechaTransaferencia = fechaTransaferencia;
        //    CuentaOrigenId = cuentaOrigen;
        //    CuentaDestinoId = cuentaDestino;
        //    Monto = monto;
        //    Tipo = movimiento;
        //    Estado = estadoTransaccion;
        //    AddDomainEvent(new TransferenciaCreada(cuentaOrigen, cuentaDestino, monto, DateTime.Now));
        //}
        public Transferencia(Guid cuentaOrigen, Guid cuentaDestino, decimal monto, Movimiento movimiento, EstadoTransaccion estadoTransaccion)
        {
            Id = Guid.NewGuid();
            FechaTransaferencia = DateTime.Now;
            CuentaOrigenId = cuentaOrigen;
            CuentaDestinoId = cuentaDestino;
            Monto = monto;
            Tipo = movimiento;
            Estado = estadoTransaccion;
            AddDomainEvent(new TransferenciaCreada(cuentaOrigen, cuentaDestino, monto, DateTime.Now));
        }
        public void agregarDatos(Guid cuentaOrigen, Guid cuentaDestino, decimal monto)
        {
            Id = Guid.NewGuid();
            FechaTransaferencia = DateTime.Now;
            CuentaOrigenId = cuentaOrigen;
            CuentaDestinoId = cuentaDestino;
            Monto = monto;
            AddDomainEvent(new TransferenciaCreada(cuentaOrigen, cuentaDestino, monto, DateTime.Now));
        }
        public void eliminarTransferencia()
        {
            AddDomainEvent(new TransferenciaEliminada(this.CuentaOrigenId, this.CuentaDestinoId, this.Monto, DateTime.Now));
        }
    }
}
