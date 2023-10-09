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
            var transaccionList = await _transaccion
                            .AsNoTracking()
                            .Include(x => x.Cuenta)
                            .Include(x => x.Categoria)
                            .Where(
                                x => x.FechaRegistro.ToString().Contains(request.FechaRegistro.ToString()) ||
                                x.Cuenta.Id.ToString().Contains(request.CuentaId.ToString()) ||
                                x.Categoria.Id.ToString().Contains(request.CategoriaId.ToString())
                                ).
                            Include(x => x.Cuenta)
                            .Include(x => x.Categoria).ToListAsync();
                            //.Include(x => x.Categoria).ToListAsync();
                            //.Where(x => 
                            //x.CuentaId.ToString().Contains(request.CuentaId.ToString())  || 
                            //x.FechaRegistro == request.FechaRegistro || x.CategoriaId.ToString().Contains(request.CategoriaId.ToString()))
                            //.ToListAsync();

            var result = new List<TransaccionDto>();

            foreach(var t in transaccionList)
            {
                var transaccion = new TransaccionDto
                {
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

            return result;
        }
    }
}
