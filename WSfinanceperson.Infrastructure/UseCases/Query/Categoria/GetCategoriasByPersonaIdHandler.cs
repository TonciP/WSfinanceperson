using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Application.UseCases.Query.Categoria.GetCategorias;
using WSfinanceperson.Infrastructure.EF.Contexts;
using WSfinanceperson.Infrastructure.EF.ReadModel;

namespace WSfinanceperson.Infrastructure.UseCases.Query.Categoria
{
    public class GetCategoriasByPersonaIdHandler : IRequestHandler<GetCategoriasByCuentaIdQuery, ICollection<CategoriaDto>>
    {
        private readonly DbSet<CategoriaReadModel> _categoria;
        public GetCategoriasByPersonaIdHandler(ReadDbContext context)
        {
            _categoria = context.Categoria;
        }

        public async Task<ICollection<CategoriaDto>> Handle(GetCategoriasByCuentaIdQuery request, CancellationToken cancellationToken)
        {
            List<CategoriaDto> categoria = await _categoria
                .AsNoTracking()
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
