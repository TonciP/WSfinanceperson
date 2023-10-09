using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Events;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.DomainEventHandler.Cuenta
{
    public class UpdateSaldoWhenTransaccionCreate :
        INotificationHandler<TransaccionCreada>
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly ICuentaFactory _cuentaFactory;
        public UpdateSaldoWhenTransaccionCreate(ICuentaRepository cuentaRepository, ICuentaFactory cuentaFactory)
        {
            _cuentaRepository = cuentaRepository;
            _cuentaFactory = cuentaFactory;
        }
        public async Task Handle(TransaccionCreada notification, CancellationToken cancellationToken)
        {
            var cuenta = await _cuentaRepository.FindByIdAsync(notification.CuentaId);
            decimal monto = notification.Tipo == Domain.Models.Transaccion.Movimiento.Ingreso ? notification.Monto : (-1) * notification.Monto;
            cuenta.ActualizarSaldoTransaccion(monto);

            await _cuentaRepository.UpdateAsync(cuenta);

        }
    }
}
