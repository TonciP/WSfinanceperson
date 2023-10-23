using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Events;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Models.Personas;
using WSfinanceperson.Domain.Models.Transacciones;
using WSfinanceperson.Domain.ValueObjects;

namespace WSfinanceperson.Domain.Models.Transaccion
{
    public class Transaccion : AggregateRoot<Guid>
    {
        //public Guid Id { get; private set; }
        //public decimal Monto { get; private set; }
        public MontoTransferencia Monto { get; private set; }
        public string Descripcion { get; private set; }
        public Guid CuentaId { get; private set; }
        public Movimiento Tipo { get; private set; }
        public EstadoTransaccion Estado { get; private set; }
        public Guid CategoriaId { get; private set; }
        //public DateTime FechaRegistro { get; private set; }
        public FechaTransaccion FechaRegistro { get; private set; }

        public Transaccion() { }
        public Transaccion(Movimiento tipo)
        {
            Estado = EstadoTransaccion.Registrado;
            Tipo = tipo;
        }

        public Transaccion(decimal monto, string descripcion, Guid cuentaId, Movimiento tipo, Guid categoriaId)
        {
            Id = Guid.NewGuid();
            Monto = monto;
            Descripcion = descripcion;
            CuentaId = cuentaId;
            Tipo = tipo;
            CategoriaId = categoriaId;
            FechaRegistro = DateTime.Now;
        }
        public Transaccion(decimal monto, string descripcion, Guid cuentaId, Movimiento tipo, EstadoTransaccion estadoTransaccion, Guid categoriaId)
        {
            Id = Guid.NewGuid();
            Monto = monto;
            Descripcion = descripcion;
            CuentaId = cuentaId;
            Tipo = tipo;
            Estado = estadoTransaccion;
            CategoriaId = categoriaId;
            FechaRegistro = DateTime.Now;
            AddDomainEvent(new TransaccionCreada(cuentaId, monto, DateTime.Now));
        }

        public void agregarDatos(decimal monto, string descripcion, Guid cuentaId, Guid categoriaId)
        {
            Id = Guid.NewGuid();
            Monto = monto;
            Descripcion = descripcion;
            CuentaId = cuentaId;
            CategoriaId = categoriaId;
            FechaRegistro = DateTime.Now;
            AddDomainEvent(new TransaccionCreada(cuentaId, monto, DateTime.Now));
        }
    }
}
