using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Application.UseCases.Command.Categorias.CrearCategoria;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Categorias.CrearCategorias
{
    public class CrearCategoriasHandler
        : IRequestHandler<CrearCategoriasCommand, List<CategoriaDto>>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoriaFactory _categoriaFactory;

        public CrearCategoriasHandler(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork, ICategoriaFactory categoriaFactory)
        {
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
            _categoriaFactory = categoriaFactory;
        }
        public async Task<List<CategoriaDto>> Handle(CrearCategoriasCommand request, CancellationToken cancellationToken)
        {
            //List<Categoria> categorias = new List<Categoria>();
            foreach (var item in request.Categorias)
            {
                var categoria = _categoriaFactory.Create(cuentaId: item.CuentaId, nombre: item.Nombre);
                await _categoriaRepository.CreateAsync(categoria);
            }

            await _unitOfWork.Commit();

            return request.Categorias.ToList();
        }

    }
}
