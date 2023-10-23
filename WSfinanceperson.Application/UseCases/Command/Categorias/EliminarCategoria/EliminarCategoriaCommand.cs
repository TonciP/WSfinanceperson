using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Application.UseCases.Command.Categorias.EliminarCategoria
{
    public class EliminarCategoriaCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public EliminarCategoriaCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
