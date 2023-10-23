using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Transacciones.EliminarTransaccion
{
    public class EliminarTransaccionHandler : IRequestHandler<EliminarTransaccionCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransaccionFactory _transaccionFactory;
        private readonly ITransaccionRepository _transaccionRepository;
        private readonly ICuentaRepository _cuentaRepository;

        public EliminarTransaccionHandler(IUnitOfWork unitOfWork, ITransaccionFactory transaccionFactory, ITransaccionRepository transaccionRepository, ICuentaRepository cuentaRepository)
        {
            _unitOfWork = unitOfWork;
            _transaccionFactory = transaccionFactory;
            _transaccionRepository = transaccionRepository;
            _cuentaRepository = cuentaRepository;
        }

        public Task<Guid> Handle(EliminarTransaccionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
