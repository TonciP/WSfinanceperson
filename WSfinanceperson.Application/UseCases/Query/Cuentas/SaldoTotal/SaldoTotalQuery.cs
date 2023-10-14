using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Utils;

namespace WSfinanceperson.Application.UseCases.Query.Cuentas.SaldoTotal
{
    public class SaldoTotalQuery: IRequest<Result<decimal>>
    {
        public Guid PersonaId  { get; set; }
    }
}
