using Inventario.Domain.Models.Transacciones;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Personas;

namespace WSfinanceperson.Domain.Models.Transaccion
{
    public class Transaccion : AggregateRoot<Guid>
    {
        public Guid Id { get; private set; }
        public decimal Monto { get; private set; }
        public string Descripcion { get; private set; }
        public Guid CuentaId { get; private set; }
        public Movimiento Tipo { get; private set; }
        public EstadoTransaccion Estado { get; private set; }
        public Guid CateogriaId { get; private set; }
        public DateTime FechaRegistro { get; private set; }

        private readonly Categoria _categoria;

        public Categoria Categoria
        {
            get
            {
                return _categoria;
            }
        }
        public Transaccion() { }
        public Transaccion(Movimiento tipo)
        {
            Id = Guid.NewGuid();
            FechaRegistro = DateTime.Now;
            Estado = EstadoTransaccion.Registrado;
            Tipo = tipo;
            //_detalle = new List<DetalleTransaccion>();
        }

        public Transaccion(decimal monto, string descripcion, Guid cuentaId, Movimiento tipo, Guid categoriaId)
        {
            Id = Guid.NewGuid();
            Monto = monto;
            Descripcion = descripcion;
            CuentaId = cuentaId;
            Tipo = tipo;
            CateogriaId = categoriaId;
        }
    }
}
