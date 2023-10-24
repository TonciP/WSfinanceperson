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

namespace WSfinanceperson.Infrastructure.UseCases.Query.Transacciones
{
    public class HistorialTransaccionHandler :
        IRequestHandler<HistorialTransaccionesQuery, ICollection<TransaccionDto>>
    {
        private readonly DbSet<TransaccionReadModel> _transaccion;

        public HistorialTransaccionHandler(ReadDbContext context)
        {
            _transaccion = context.Transaccion;

        }
        public async Task<ICollection<TransaccionDto>> Handle(HistorialTransaccionesQuery request, CancellationToken cancellationToken)
        {
            //    var transaccionList = await _transaccion
            //                    .AsNoTracking()
            //                    //.Include(x => x.Cuenta)
            //                    //.Include(x => x.Categoria)
            //                    .Where(
            //                        x => x.FechaRegistro.ToString().Contains(request.FechaRegistro.ToString()) ||
            //                        x.CuentaId.ToString().Contains(request.CuentaId.ToString()) ||
            //                        x.CategoriaId.ToString().Contains(request.CategoriaId.ToString())
            //                        ).ToListAsync();
            var transaccionList = await _transaccion
                           .AsNoTracking()
                           .Include(x => x.Cuenta)
                           .Include(x => x.Categoria)
                           .Where(
                               x => x.FechaRegistro == request.FechaRegistro ||
                               x.CuentaId == request.CuentaId ||
                               x.CategoriaId == request.CategoriaId
                               ).ToListAsync();

            var result = new List<TransaccionDto>();

            if (transaccionList.Any())
            {
                foreach (var t in transaccionList)
                {
                    var transaccion = new TransaccionDto
                    {
                        Id = t.Id,
                        Monto = t.Monto,
                        Descripcion = t.Descripcion,
                        Cuenta = new CuentaDto
                        {
                            Id = t.Cuenta.Id,
                            Nombre = t.Cuenta.Nombre,
                            SaldoInicial = t.Cuenta.SaldoInicial,
                        },
                        Categoria = new CategoriaDto
                        {
                            Id = t.Categoria.Id,
                            CuentaId = t.Categoria.CuentaId,
                            Nombre = t.Categoria.Nombre,
                        },
                        FechaRegistro = t.FechaRegistro,
                        Tipo = t.Tipo,
                        Estado = t.Estado,
                    };
                    result.Add(transaccion);
                }
            }
            

            return result;
        }
    }
}
