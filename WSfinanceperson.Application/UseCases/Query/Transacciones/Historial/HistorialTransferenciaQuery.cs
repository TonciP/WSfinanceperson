using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;

namespace WSfinanceperson.Application.UseCases.Query.Transacciones.Historial
{
    public class HistorialTransferenciaQuery: IRequest<ICollection<TransferenciaDto>>
    {
        public DateTime? FechaTransaferencia { get; set; }

        public Guid? CuentaOrigenId { get; set; }

        public Guid? CuentaDestinoId { get; set; }
        public string? Tipo { get; set; }
        //public Guid? TransferenciaId { get; set; }
    }
}
