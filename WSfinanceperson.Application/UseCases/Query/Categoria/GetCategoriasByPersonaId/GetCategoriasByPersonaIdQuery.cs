using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;

namespace WSfinanceperson.Application.UseCases.Query.Categoria.GetCategoriasByPersonaId
{
    public class GetCategoriasByPersonaIdQuery : IRequest<List<CategoriaDto>>
    {
        public Guid PersonaId { get; set; }

        public GetCategoriasByPersonaIdQuery(Guid personaId)
        {
            PersonaId = personaId;
        }

        public GetCategoriasByPersonaIdQuery()
        {
        }
    }
}
