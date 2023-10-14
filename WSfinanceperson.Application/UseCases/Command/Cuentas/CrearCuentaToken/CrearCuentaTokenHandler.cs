using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.UseCases.Command.Cuentas.CrearCuenta;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Cuentas.CrearCuentaToken
{
    public class CrearCuentaTokenHandler : IRequestHandler<CrearCuentaTokenCommand, Guid>
    {
        private readonly ICuentaFactory _cuentaFactory;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CrearCuentaTokenHandler(ICuentaFactory cuentaFactory, ICuentaRepository cuentaRepository, IUnitOfWork unitOfWork)
        {
            _cuentaFactory = cuentaFactory;
            _cuentaRepository = cuentaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearCuentaTokenCommand request, CancellationToken cancellationToken)
        {
            var cuenta = _cuentaFactory.Create(request.NombreCuenta, request.saldoInicial, request.PersonaId);
            //cuenta.AdicionarCategoriaDefault(cuentaId: cuenta.Id);

            await _cuentaRepository.CreateAsync(cuenta);
            await _unitOfWork.Commit();


            return cuenta.Id;
        }
    }
}
