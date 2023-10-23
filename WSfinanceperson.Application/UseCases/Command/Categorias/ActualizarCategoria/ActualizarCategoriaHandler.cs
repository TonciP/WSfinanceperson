using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Categorias.ActualizarCategoria
{
    public class ActualizarCategoriaHandler : IRequestHandler<ActualizarCategoriaCommand, Guid>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoriaFactory _categoriaFactory;

        public ActualizarCategoriaHandler(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork, ICategoriaFactory categoriaFactory)
        {
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
            _categoriaFactory = categoriaFactory;
        }
        public async Task<Guid> Handle(ActualizarCategoriaCommand request, CancellationToken cancellationToken)
        {
            Categoria categoria = await _categoriaRepository.FindByIdAsync(request.Id);
            if (categoria == null)
            {
                throw new Exception("No se encontro la categoria");
            }
            else
            {
                categoria.Actualizar(request.Nombre);
                await _categoriaRepository.UpdateAsync(categoria);
                await _unitOfWork.Commit();
                return categoria.Id;
            }
            return Guid.Empty;
        }
    }
}
