using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Application.UseCases.Command.Categorias.ActualizarCategoria
{
    public class ActualizarCategoriaCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public ActualizarCategoriaCommand(Guid id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
