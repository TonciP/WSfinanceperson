
using MediatR;
using WSfinanceperson.Application.Dto;

namespace WSfinanceperson.Application.UseCases.Command.Transacciones.CrearTransaccion
{
    public class CrearTransaccionCommand : IRequest<Guid>
    {
        //public Guid Id { get; private set; }
        public decimal Monto { get;  set; }
        public string Descripcion { get;  set; }
        public Guid CuentaId { get;  set; }
        public Movimiento Tipo { get;  set; }
        public EstadoTransaccion Estado { get;  set; }
        public Guid CategoriaId { get;  set; }

        public CrearTransaccionCommand(decimal monto, string descripcion, Guid cuentaId, Movimiento tipo, EstadoTransaccion estado, Guid categoriaId)
        {
            this.Monto = monto;
            this.Descripcion = descripcion;
            this.CuentaId = cuentaId;
            this.Tipo = tipo;
            this.Estado = estado;
            this.CategoriaId = categoriaId;
        }   
    }
}
