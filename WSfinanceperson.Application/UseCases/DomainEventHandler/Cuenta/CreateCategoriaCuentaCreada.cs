
using MediatR;
using WSfinanceperson.Domain.Events;
using WSfinanceperson.Domain.Factories;

using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.DomainEventHandler.Cuenta
{
    public class CreateCategoriaCuentaCreada : INotificationHandler<CuentaCreada>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaFactory _categoriaFactory;
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IMediator _mediator;
        //private readonly IPublishEndpoint _publishEndpoint;

        public CreateCategoriaCuentaCreada(ICategoriaRepository categoriaRepository, ICategoriaFactory categoriaFactory)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaFactory = categoriaFactory;
            //_unitOfWork = unitOfWork;
            //_mediator = mediator;
            //_publishEndpoint = publishEndpoint;
        }

        public async Task Handle(CuentaCreada notification, CancellationToken cancellationToken)
        {
            var Casa = _categoriaFactory.Create(
                cuentaId: notification.CuentaId,
                nombre: "Alimentacion"
            );

            var Colchon = _categoriaFactory.Create(
                cuentaId: notification.CuentaId,
                nombre: "Transporte"
            );

            var Diario = _categoriaFactory.Create(
                cuentaId: notification.CuentaId,
                nombre: "Entretenimiento"
            );

            await _categoriaRepository.CreateAsync(Casa);
            await _categoriaRepository.CreateAsync(Colchon);
            await _categoriaRepository.CreateAsync(Diario);

            //await _unitOfWork.Commit();

        }

    }
}
