using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;

namespace WSfinanceperson.Application.UseCases.Query.Cuentas.GetCuentaBy
{
    public class GetCuentaByIdQuery : IRequest<CuentaDto>
    {
        public Guid Id { get; set; }
        public GetCuentaByIdQuery(Guid id)
        {
            Id = id;
        }
        public GetCuentaByIdQuery()
        { }
    }
}
