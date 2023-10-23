using MediatR;
using WSfinanceperson.Application.Dto;

namespace WSfinanceperson.Application.UseCases.Command.Transferencias.CrearTransferencia
{
    public class CrearTransferenciaCommand : IRequest<Guid> 
    {
        //public DateTime FechaTransaferencia { get;  set; }
        public Guid CuentaOrigenId { get;  set; }
        public Guid CuentaDestinoId { get;  set; }
        public decimal Monto { get;  set; }
        public Movimiento Tipo { get;  set; }
        public EstadoTransaccion Estado { get;  set; }
    }
}
