using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Services;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Personas.ActualizarPersona
{
    public class ActualizarPersonaHandler : IRequestHandler<ActualizarPersonaCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonaFactory _personaFactory;
        private readonly IPersonaRepository _personaRepository;
        //private readonly ISecurityService _securityService;

        public ActualizarPersonaHandler(IUnitOfWork unitOfWork, IPersonaFactory personaFactory, IPersonaRepository personaRepository
                                   //ISecurityService securityService
                                   )
        {
            _unitOfWork = unitOfWork;
            _personaFactory = personaFactory;
            _personaRepository = personaRepository;
            //_securityService = securityService;
        }

        public async Task<Guid> Handle(ActualizarPersonaCommand request, CancellationToken cancellationToken)
        {
            //Devolvemos la cadena con el hash en mayúsculas para que quede más chuli :)
            
            var persona = await  _personaRepository.FindByIdAsync(request.Id);
            _personaRepository.UpdateAsync(persona);
            _unitOfWork.Commit();

            return persona.Id;
        }
    }
}
