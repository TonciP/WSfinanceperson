using Inventario.Domain.Models.Transacciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Application.UseCases.Command.Transacciones.CrearTransaccion
{
    public class CrearTransaccionCommand : IRequest<Guid>
    {
        //public Guid Id { get; private set; }
        public decimal Monto { get;  set; }
        public string Descripcion { get;  set; }
        public Guid CuentaId { get;  set; }
        //private readonly Cuenta _cuenta;

        //public Cuenta Cuenta
        //{
        //    get
        //    {
        //        return _cuenta;
        //    }
        //}
        public Movimiento Tipo { get;  set; }
        public EstadoTransaccion Estado { get;  set; }
        public Guid CateogriaId { get;  set; }
        public DateTime FechaRegistro { get;  set; }

        //private readonly Categoria _categoria;

        //public Categoria Categoria
        //{
        //    get
        //    {
        //        return _categoria;
        //    }
        //}

        public CrearTransaccionCommand(decimal monto, string descripcion, Guid cuentaId, Movimiento tipo, EstadoTransaccion estado, Guid cateogriaId, DateTime fechaRegistro)
        {
            //this.Id = Guid.NewGuid();
            this.Monto = monto;
            this.Descripcion = descripcion;
            this.CuentaId = cuentaId;
            //this._cuenta.Id = cuentaId;
            this.Tipo = tipo;
            this.Estado = estado;
            this.CateogriaId = cateogriaId;
            //this._categoria.Id = cateogriaId;
            this.FechaRegistro = fechaRegistro;
        }   
    }
}
