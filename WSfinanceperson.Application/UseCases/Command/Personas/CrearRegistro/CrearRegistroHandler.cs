using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Services;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Personas.CrearRegistro
{
    public class CrearRegistroHandler : IRequestHandler<CrearRegistroCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonaFactory _personaFactory;
        private readonly IPersonaRepository _personaRepository;
        private readonly ISecurityService _securityService;

        public CrearRegistroHandler(IUnitOfWork unitOfWork, IPersonaFactory personaFactory, IPersonaRepository personaRepository 
            //ISecurityService securityService
            )
        {
            _unitOfWork = unitOfWork;
            _personaFactory = personaFactory;
            _personaRepository = personaRepository;
            //_securityService = securityService;
        }
        public async Task<Guid> Handle(CrearRegistroCommand request, CancellationToken cancellationToken)
        {
            string hash = hashSecutiry(request.Contrasena);
            //Devolvemos la cadena con el hash en mayúsculas para que quede más chuli :)

            var persona = _personaFactory.Create(request.Correo, hash);

            await _personaRepository.CreateAsync(persona);
            await _unitOfWork.Commit();

            return persona.Id;
        }

        private string hashSecutiry(string contrasena)
        {
            #region hash password
            byte[] data = Encoding.ASCII.GetBytes(contrasena);
            byte[] resultbyte = new SHA256Managed().ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < resultbyte.Length; i++)
            {

                // Convertimos los valores en hexadecimal
                // cuando tiene una cifra hay que rellenarlo con cero
                // para que siempre ocupen dos dígitos.
                if (resultbyte[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(resultbyte[i].ToString("x"));
            }

            #endregion hash password

            return sb.ToString();
        }
    }
}
