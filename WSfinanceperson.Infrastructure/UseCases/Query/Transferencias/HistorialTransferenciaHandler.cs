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
                            .Where(
                x => x.CuentaOrigenId.ToString().Contains(request.CuentaOrigenId.ToString()) ||
                x.CuentaDestinoId.ToString().Contains(request.CuentaDestinoId.ToString()) ||
                x.FechaTransferencia.ToString().Contains(request.FechaTransaferencia.ToString())
                ).ToListAsync();
            //.Include(x => x.Categoria).ToListAsync();
            //.Where(x => 
            //x.CuentaId.ToString().Contains(request.CuentaId.ToString())  || 
            //x.FechaRegistro == request.FechaRegistro || x.CategoriaId.ToString().Contains(request.CategoriaId.ToString()))
            //.ToListAsync();

            var result = new List<TransferenciaDto>();

            foreach (var t in transaccionList)
            {
                var transaccion = new TransferenciaDto
                {
                    Monto = t.Monto,
                    CuentaDestinoId = t.CuentaDestinoId,
                    CuentaOrigenId = t.CuentaOrigenId,
                    //CuentaOrigen = new CuentaDto
                    //{
                    //    Id = t.CuentaOrigen.Id,
                    //    Nombre = t.CuentaOrigen.Nombre,
                    //    SaldoInicial = t.CuentaOrigen.SaldoInicial,
                    //},
                    //CuentaDestino = new CuentaDto
                    //{
                    //    Id = t.CuentaDestino.Id,
                    //    Nombre = t.CuentaDestino.Nombre,
                    //    SaldoInicial = t.CuentaDestino.SaldoInicial,
                    //},
                    Tipo = t.Tipo,
                    Estado = t.Estado,
                };
                result.Add(transaccion);
            }

            return result;
        }
    }
}
