using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Application.UseCases.Query.Categoria.CategoriaByCuentaId;
using WSfinanceperson.Infrastructure.EF.Contexts;
using WSfinanceperson.Infrastructure.EF.ReadModel;

namespace WSfinanceperson.Infrastructure.UseCases.Query.Categoria
{
    public class CategoriaByCuentaIdHandler : IRequestHandler<CategoriaByCuentaIdQuery, ICollection<CategoriaDto>>
    {
        private readonly DbSet<CategoriaReadModel> _categoria;

        public CategoriaByCuentaIdHandler(ReadDbContext context)
        {
            _categoria = context.Categoria;
        }
        public async Task<ICollection<CategoriaDto>> Handle(CategoriaByCuentaIdQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _categoria
                .AsNoTracking()
                .Where(x => x.CuentaId == request.CuentaId)
                .Select(x => new CategoriaDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    CuentaId = x.CuentaId
                }).ToListAsync();

            return categoria;
        }
    }
}
