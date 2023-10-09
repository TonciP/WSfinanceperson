using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.UseCases.Command.Transacciones.CrearTransaccion;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Transferencia.CrearTransferencia
{
    public class CrearTransferenciaHandler
        : IRequestHandler<CrearTransferenciaCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransferenciaFactory _transaccionFactory;
        private readonly ITransferenciaRepository _transaccionRepository;

        public CrearTransferenciaHandler(IUnitOfWork unitOfWork, ITransferenciaFactory transaccionFactory, ITransferenciaRepository transaccionRepository)
        {
            _unitOfWork = unitOfWork;
            _transaccionFactory = transaccionFactory;
            _transaccionRepository = transaccionRepository;
        }
        public async Task<Guid> Handle(CrearTransferenciaCommand request, CancellationToken cancellationToken)
        {
            var transferencia = _transaccionFactory.Create(request.FechaTransaferencia, request.CuentaOrigenId, 
                request.CuentaDestinoId, request.Monto, Domain.Models.Transaccion.Movimiento.Ingreso, 
                Inventario.Domain.Models.Transacciones.EstadoTransaccion.Confirmado);

            await _transaccionRepository.CreateAsync(transferencia);
            await _unitOfWork.Commit();

            return transferencia.Id;
        }
    }
}
