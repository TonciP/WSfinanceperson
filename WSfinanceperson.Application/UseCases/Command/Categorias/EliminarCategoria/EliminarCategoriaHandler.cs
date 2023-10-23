using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Categorias.EliminarCategoria
{
    public class EliminarCategoriaHandler : IRequestHandler<EliminarCategoriaCommand, Guid>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoriaFactory _categoriaFactory;

        public EliminarCategoriaHandler(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork, ICategoriaFactory categoriaFactory)
        {
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
            _categoriaFactory = categoriaFactory;
        }
        public async Task<Guid> Handle(EliminarCategoriaCommand request, CancellationToken cancellationToken)
        {
            Categoria categoria = await _categoriaRepository.FindByIdAsync(request.Id);
            if (categoria == null)
            {
                throw new Exception("No se encontro la categoria");
            }
            await _categoriaRepository.DeleteAsync(categoria);
            await _unitOfWork.Commit();

            return request.Id;
        }
    }
}
