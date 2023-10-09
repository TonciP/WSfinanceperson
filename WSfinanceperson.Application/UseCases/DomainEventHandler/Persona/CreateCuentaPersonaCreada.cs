using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Events;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.DomainEventHandler.Persona
{
    public class CreateCuentaPersonaCreada : INotificationHandler<PersonaCreada>
    {
        private readonly ICuentaFactory _cuentaFactory;
        private readonly ICuentaRepository _cuentaRepository;

        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaFactory _categoriaFactory;
        public CreateCuentaPersonaCreada(ICuentaFactory personaFactory, ICuentaRepository personaRepository, ICategoriaRepository categoriaRepository, ICategoriaFactory categoriaFactory)
        {
            _cuentaFactory = personaFactory;
            _cuentaRepository = personaRepository;
            _categoriaRepository = categoriaRepository;
            _categoriaFactory = categoriaFactory;
        }
        public async Task Handle(PersonaCreada notification, CancellationToken cancellationToken)
        {
            var cuenta = _cuentaFactory.Create(
                               nombre: "Cuenta Personal",
                                              personaId: notification.PersonaId
                                                         );

            await _cuentaRepository.CreateAsync(cuenta);

            var Casa = _categoriaFactory.Create(
                cuentaId: cuenta.Id,
                nombre: "Alimentacion"
            );

            var Colchon = _categoriaFactory.Create(
                cuentaId: cuenta.Id,
                nombre: "Transporte"
            );

            var Diario = _categoriaFactory.Create(
                cuentaId: cuenta.Id,
                nombre: "Entretenimiento"
            );

            await _categoriaRepository.CreateAsync(Casa);
            await _categoriaRepository.CreateAsync(Colchon);
            await _categoriaRepository.CreateAsync(Diario);

        }
    }
}
