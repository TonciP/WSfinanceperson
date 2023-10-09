using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.UseCases.Command.Personas.CrearRegistro;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Transacciones.CrearTransaccion
{
    public class CrearTransaccionHandler : IRequestHandler<CrearTransaccionCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransaccionFactory _transaccionFactory;
        private readonly ITransaccionRepository _transaccionRepository;

        public CrearTransaccionHandler(IUnitOfWork unitOfWork, ITransaccionFactory transaccionFactory, ITransaccionRepository transaccionRepository)
        {
            _unitOfWork = unitOfWork;
            _transaccionFactory = transaccionFactory;
            _transaccionRepository = transaccionRepository;
        }
        public async Task<Guid> Handle(CrearTransaccionCommand request, CancellationToken cancellationToken)
        {
            var persona = _transaccionFactory.Create(request.Monto, request.Descripcion, request.CuentaId, Domain.Models.Transaccion.Movimiento.Egreso, Inventario.Domain.Models.Transacciones.EstadoTransaccion.Registrado, request.CateogriaId);

            await _transaccionRepository.CreateAsync(persona);
            await _unitOfWork.Commit();
            
            return persona.Id;
        }
    }
}
