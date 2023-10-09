using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Personas.CrearRegistro
{
    public class CrearRegistroHandler : IRequestHandler<CrearRegistroCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonaFactory _personaFactory;
        private readonly IPersonaRepository _personaRepository;

        public CrearRegistroHandler(IUnitOfWork unitOfWork, IPersonaFactory personaFactory, IPersonaRepository personaRepository)
        {
            _unitOfWork = unitOfWork;
            _personaFactory = personaFactory;
            _personaRepository = personaRepository;
        }
        public async Task<Guid> Handle(CrearRegistroCommand request, CancellationToken cancellationToken)
        {
            var persona = _personaFactory.Create(request.Correo, request.Contrasena);

            await _personaRepository.CreateAsync(persona);
            await _unitOfWork.Commit();

            return persona.Id;
        }
    }
}
