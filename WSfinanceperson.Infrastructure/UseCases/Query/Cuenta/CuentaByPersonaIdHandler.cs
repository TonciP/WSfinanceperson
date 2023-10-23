using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Application.UseCases.Query.Cuentas.GetCuentasByPersonaId;
using WSfinanceperson.Infrastructure.EF.Contexts;
using WSfinanceperson.Infrastructure.EF.ReadModel;

namespace WSfinanceperson.Infrastructure.UseCases.Query.Cuenta
{
    public class CuentaByPersonaIdHandler
        : IRequestHandler<GetCuentasByPersonaIdQuery, List<CuentaDto>>
    {
        private readonly DbSet<CuentaReadModel> _cuenta;

        public CuentaByPersonaIdHandler(ReadDbContext context)
        {
            _cuenta = context.Cuenta;
        }
        public async Task<List<CuentaDto>> Handle(GetCuentasByPersonaIdQuery request, CancellationToken cancellationToken)
        {
            var cuentas = await _cuenta
                .AsNoTracking()
                .Where(x => x.PersonaId == request.PersonaId)
                .Select(x => new CuentaDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    SaldoInicial = x.SaldoInicial
                }).ToListAsync();


            return cuentas;
            //return Task.FromResult(new List<CuentaDto>()).Result;
        }
    }
}
