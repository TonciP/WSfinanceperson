using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Application.UseCases.Query.Categoria.GetCategoriasByPersonaId;
using WSfinanceperson.Infrastructure.EF.Contexts;
using WSfinanceperson.Infrastructure.EF.ReadModel;

namespace WSfinanceperson.Infrastructure.UseCases.Query.Categoria
{
    public class CategoriaByPersonaHandler : IRequestHandler<GetCategoriasByPersonaIdQuery, List<CategoriaDto>>
    {
        private readonly DbSet<CategoriaReadModel> _categoria;
        private readonly DbSet<CuentaReadModel> _cuenta;

        public CategoriaByPersonaHandler(ReadDbContext context)
        {
            _categoria = context.Categoria;
            _cuenta = context.Cuenta;
        }
        public async Task<List<CategoriaDto>> Handle(GetCategoriasByPersonaIdQuery request, CancellationToken cancellationToken)
        {
            var cuenta =  _cuenta.Where(c => c.PersonaId == request.PersonaId);

            List<CategoriaDto> categoria = new List<CategoriaDto>();
            //foreach (var item in cuenta)
            //{
            //    var cate = _categoria.Where(c => c.CuentaId == item.Id);
            //    if (cate != null)
            //    {
            //        categoria.Add(new CategoriaDto
            //        {
            //            Id = cate.Id,
            //            Nombre = cate.Nombre,
            //            CuentaId = cate.CuentaId
            //        });
            //    }
            //}


            return categoria;
        }
    }
}
