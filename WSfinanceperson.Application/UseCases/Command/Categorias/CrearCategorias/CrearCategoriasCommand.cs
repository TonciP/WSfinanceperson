using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Domain.Models.Categorias;

namespace WSfinanceperson.Application.UseCases.Command.Categorias.CrearCategorias
{
    public class CrearCategoriasCommand : IRequest<List<CategoriaDto>>
    {
        public CategoriaDto[] Categorias { get; set; }
        public CrearCategoriasCommand() { }
        public CrearCategoriasCommand(CategoriaDto[] categorias)
        {
            this.Categorias = categorias;
        }
    }
}
