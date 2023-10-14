using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;

namespace WSfinanceperson.Application.UseCases.Query.Categoria.GetCategoriaById
{
    public class GetCategoriaByIdQuery : IRequest<CategoriaDto>
    {
        public Guid Id { get; set; }
        public GetCategoriaByIdQuery(Guid id)
        {
            Id = id;
        }

        public GetCategoriaByIdQuery() { }
    }
}
