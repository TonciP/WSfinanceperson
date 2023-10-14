using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Application.UseCases.Query.Cuentas.SaldoTotal;
using WSfinanceperson.Application.Utils;
using WSfinanceperson.Infrastructure.EF.Contexts;
using WSfinanceperson.Infrastructure.EF.ReadModel;

namespace WSfinanceperson.Infrastructure.UseCases.Query.Cuenta
{
    public class SaldoTotalHandler : IRequestHandler<SaldoTotalQuery, Result<decimal>>
    {
        private DbSet<CuentaReadModel> _cuenta;
        public SaldoTotalHandler(ReadDbContext context)
        {
            _cuenta = context.Cuenta;
        }
        public async Task<Result<decimal>> Handle(SaldoTotalQuery request, CancellationToken cancellationToken)
        {
            //var result = _cuenta.Sum(x => x.SaldoInicial);
            decimal sumaSaldoTotal =  _cuenta
                .AsNoTracking()
                .Where(x => x.PersonaId == request.PersonaId)
                .Sum(x => x.SaldoInicial);

            return new Result<decimal>(sumaSaldoTotal, true, "Saldo Total");
        }
    }
}
