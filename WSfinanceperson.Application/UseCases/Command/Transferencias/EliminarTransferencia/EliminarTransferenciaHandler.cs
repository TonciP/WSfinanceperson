using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Transferencias.EliminarTransferencia
{
    public class EliminarTransferenciaHandler : IRequestHandler<EliminarTransferenciaCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransferenciaFactory _transferenciaFactory;
        private readonly ITransferenciaRepository _transferenciaRepository;
        private readonly ICuentaRepository _cuentaRepository;

        public EliminarTransferenciaHandler(IUnitOfWork unitOfWork, ITransferenciaFactory transferenciaFactory, ITransferenciaRepository transferenciaRepository, ICuentaRepository cuentaRepository)
        {
            _unitOfWork = unitOfWork;
            _transferenciaFactory = transferenciaFactory;
            _transferenciaRepository = transferenciaRepository;
            _cuentaRepository = cuentaRepository;
        }

        public async Task<Guid> Handle(EliminarTransferenciaCommand request, CancellationToken cancellationToken)
        {
            var transferencia = await _transferenciaRepository.FindByIdAsync(request.Id);
            transferencia.eliminarTransferencia();

            await _transferenciaRepository.DeleteAsync(transferencia);

            await _unitOfWork.Commit();

            return transferencia.Id;
        }
    }
}
