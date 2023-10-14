using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;

namespace WSfinanceperson.Application.UseCases.Query.Categoria.GetCategorias
{
    public class GetCategoriasByCuentaIdQuery : IRequest<ICollection<CategoriaDto>>
    {
    }
}
