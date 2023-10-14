using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;

namespace WSfinanceperson.Application.UseCases.Query.Categoria.CategoriaByCuentaId
{
    public class CategoriaByCuentaIdQuery : IRequest<ICollection<CategoriaDto>>
    {
        public Guid CuentaId { get; set; }
        public CategoriaByCuentaIdQuery(Guid cuentaId)
        {
            CuentaId = cuentaId;
        }

        public CategoriaByCuentaIdQuery() { }
    }
}
