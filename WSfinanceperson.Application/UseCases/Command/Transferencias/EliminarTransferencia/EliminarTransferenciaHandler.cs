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
        private readonly ITransferenciaFactory _transaccionFactory;
        private readonly ITransferenciaRepository _transaccionRepository;
        private readonly ICuentaRepository _cuentaRepository;

        public EliminarTransferenciaHandler(IUnitOfWork unitOfWork, ITransferenciaFactory transaccionFactory, ITransferenciaRepository transaccionRepository, ICuentaRepository cuentaRepository)
        {
            _unitOfWork = unitOfWork;
            _transaccionFactory = transaccionFactory;
            _transaccionRepository = transaccionRepository;
            _cuentaRepository = cuentaRepository;
        }

        public Task<Guid> Handle(EliminarTransferenciaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
