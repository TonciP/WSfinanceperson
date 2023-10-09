using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;

namespace WSfinanceperson.Application.UseCases.Query.Transacciones.Historial
{
    public class HistorialTransaccionesQuery : IRequest<ICollection<TransaccionDto>>
    {
        public Guid? CategoriaId { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public Guid? CuentaId { get; set; }
        //public Guid? TransaccionId { get;  set; }

        //public HistorialTransaccionesQuery(Guid? categoriaId, DateTime? fechaRegistro, Guid? cuentaId)
        //{
        //    CategoriaId = categoriaId;
        //    FechaRegistro = fechaRegistro;
        //    CuentaId = cuentaId;
        //}
    }
}
