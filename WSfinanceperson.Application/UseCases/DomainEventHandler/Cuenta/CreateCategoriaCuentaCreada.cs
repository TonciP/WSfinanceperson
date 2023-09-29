using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Events;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.DomainEventHandler.Cuenta
{
    public class CreateCategoriaCuentaCreada : INotificationHandler<CuentaCreada>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        //private readonly IPublishEndpoint _publishEndpoint;

        public CreateCategoriaCuentaCreada(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
            //_publishEndpoint = publishEndpoint;
        }
        public async Task Handle(CuentaCreada notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
