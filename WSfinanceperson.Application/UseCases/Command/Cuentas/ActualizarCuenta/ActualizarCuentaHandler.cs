using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Cuentas.ActualizarCuenta
{
    public class ActualizarCuentaHandler : IRequestHandler<ActualizarCuentaCommand, Guid>
    {
        private readonly ICuentaFactory _cuentaFactory;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ActualizarCuentaHandler(ICuentaFactory cuentaFactory, ICuentaRepository cuentaRepository, IUnitOfWork unitOfWork)
        {
            _cuentaFactory = cuentaFactory;
            _cuentaRepository = cuentaRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(ActualizarCuentaCommand request, CancellationToken cancellationToken)
        {
            Cuenta cuenta = await _cuentaRepository.FindByIdAsync(request.Id);
            cuenta.ActualizarCuenta(request.Nombre, (decimal)request.saldoInicial);
            await _cuentaRepository.UpdateAsync(cuenta);

            await _unitOfWork.Commit();

            return cuenta.Id;
        }
    }
}
