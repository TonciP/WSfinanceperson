using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Cuentas.EliminarCuenta
{
    public class EliminarCuentaHandler : IRequestHandler<EliminarCuentaCommand, Guid>
    {
        private readonly ICuentaFactory _cuentaFactory;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EliminarCuentaHandler(ICuentaFactory cuentaFactory, ICuentaRepository cuentaRepository, IUnitOfWork unitOfWork)
        {
            _cuentaFactory = cuentaFactory;
            _cuentaRepository = cuentaRepository;
            _unitOfWork = unitOfWork;
        }
        public Task<Guid> Handle(EliminarCuentaCommand request, CancellationToken cancellationToken)
        {

            return Task.FromResult(Guid.Empty);
        }
    }
}
