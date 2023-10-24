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
    public class UpdateSaldoWhenTransferenciaEliminada : INotificationHandler<TransferenciaEliminada>
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly ICuentaFactory _cuentaFactory;
        public UpdateSaldoWhenTransferenciaEliminada(ICuentaRepository cuentaRepository, ICuentaFactory cuentaFactory)
        {
            _cuentaRepository = cuentaRepository;
            _cuentaFactory = cuentaFactory;
        }
        public async Task Handle(TransferenciaEliminada notification, CancellationToken cancellationToken)
        {
            var cuentaOrigen = await _cuentaRepository.FindByIdAsync(notification.CuentaOrigenId);
            var cuentaDestino = await _cuentaRepository.FindByIdAsync(notification.CuentaDestinoId);
            decimal monto = notification.Tipo == Domain.Models.Transaccion.Movimiento.Ingreso ? notification.Monto : (-1) * notification.Monto;

            cuentaDestino.ActualizarSaldoTransaccion(monto);
            cuentaOrigen.ActualizarSaldoTransferencia(monto);

            await _cuentaRepository.UpdateAsync(cuentaOrigen);
            await _cuentaRepository.UpdateAsync(cuentaDestino);
        }
    }
}
