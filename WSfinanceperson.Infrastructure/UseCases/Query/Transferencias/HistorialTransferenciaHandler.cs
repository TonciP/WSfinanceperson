using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Application.UseCases.Query.Transacciones.Historial;
using WSfinanceperson.Infrastructure.EF.Contexts;
using WSfinanceperson.Infrastructure.EF.ReadModel;

namespace WSfinanceperson.Infrastructure.UseCases.Query.Transferencias
{
    public class HistorialTransferenciaHandler:
        IRequestHandler<HistorialTransferenciaQuery, ICollection<TransferenciaDto>>
    {
        private readonly DbSet<TransferenciaReadModel> _transferencia;
        private readonly DbSet<CuentaReadModel> _cuenta;

        public HistorialTransferenciaHandler(ReadDbContext context)
        {
            _transferencia = context.Transferencia;
            _cuenta = context.Cuenta;

        }
        public async Task<ICollection<TransferenciaDto>> Handle(HistorialTransferenciaQuery request, CancellationToken cancellationToken)
        {
            var transaccionList = await _transferencia
                            .AsNoTracking()
                            .Include(x => x.CuentaOrigen)
                            .Include(x => x.CuentaDestino)
                            .Where(
                x => x.CuentaOrigenId == request.CuentaOrigenId ||
                x.CuentaDestinoId == request.CuentaDestinoId ||
                x.FechaTransferencia == request.FechaTransferencia
                ).ToListAsync();


            var result = new List<TransferenciaDto>();

            foreach (var t in transaccionList)
            {
                var transaccion = new TransferenciaDto
                {
                    Id = t.Id,
                    Monto = t.Monto,
                    CuentaDestinoId = t.CuentaDestinoId,
                    CuentaOrigenId = t.CuentaOrigenId,
                    FechaTransferencia = t.FechaTransferencia,
                    CuentaOrigen = new CuentaDto
                    {
                        Id = t.CuentaOrigen.Id,
                        Nombre = t.CuentaOrigen.Nombre,
                        SaldoInicial = t.CuentaOrigen.SaldoInicial,
                    },
                    CuentaDestino = new CuentaDto
                    {
                        Id = t.CuentaDestino.Id,
                        Nombre = t.CuentaDestino.Nombre,
                        SaldoInicial = t.CuentaDestino.SaldoInicial,
                    },
                    Tipo = t.Tipo,
                    Estado = t.Estado,
                };
                result.Add(transaccion);
            }

            return result;
        }
    }
}
