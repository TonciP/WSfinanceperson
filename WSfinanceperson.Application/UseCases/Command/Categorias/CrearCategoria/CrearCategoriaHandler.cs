using MediatR;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Categorias.CrearCategoria
{
    public class CrearCategoriaHandler
        : IRequestHandler<CrearCategoriaCommand, Guid>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoriaFactory _categoriaFactory;

        public CrearCategoriaHandler(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork, ICategoriaFactory categoriaFactory)
        {
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
            _categoriaFactory = categoriaFactory;
        }
        public async Task<Guid> Handle(CrearCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = _categoriaFactory.Create(request.CuentaId, request.Nombre);

            await _categoriaRepository.CreateAsync(categoria);

            await _unitOfWork.Commit();

            return categoria.Id;
        }

    }
}
