using MediatR;

using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Models.Transferencias;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Transferencias.CrearTransferencia
{
    public class CrearTransferenciaHandler
        : IRequestHandler<CrearTransferenciaCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransferenciaFactory _transferenciaFactory;
        private readonly ITransferenciaRepository _transferenciaRepository;
        private readonly ICuentaRepository _cuentaRepository;

        public CrearTransferenciaHandler(IUnitOfWork unitOfWork, 
            ITransferenciaFactory transferenciaFactory, 
            ITransferenciaRepository transferenciaRepository,
            ICuentaRepository cuentaRepository
            )
        {
            _unitOfWork = unitOfWork;
            _transferenciaFactory = transferenciaFactory;
            _transferenciaRepository = transferenciaRepository;
            _cuentaRepository = cuentaRepository;
        }
        public async Task<Guid> Handle(CrearTransferenciaCommand request, CancellationToken cancellationToken)
        {
            var cuenta = await _cuentaRepository.FindByIdAsync(request.CuentaOrigenId);
            if (cuenta == null)
            {
                throw new Exception("La cuenta no existe");
            }

            decimal saldoCuenta = cuenta.SaldoInicial;

            if (saldoCuenta == 0 || saldoCuenta < request.Monto)
                throw new Exception("La cuenta no cuenta con suficiente fondo");

            Transferencia transferencia = request.Tipo == Dto.Movimiento.Egreso ?
                _transferenciaFactory.CrearTransaccionEgreso() :
                _transferenciaFactory.CrearTransaccionIngreso();

            transferencia.agregarDatos(request.CuentaOrigenId,
                request.CuentaDestinoId, request.Monto);

            await _transferenciaRepository.CreateAsync(transferencia);
            await _unitOfWork.Commit();

            return transferencia.Id;
        }
    }
}
