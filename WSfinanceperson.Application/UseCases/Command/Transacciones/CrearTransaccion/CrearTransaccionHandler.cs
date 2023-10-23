using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.UseCases.Command.Personas.CrearRegistro;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Models.Transaccion;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Command.Transacciones.CrearTransaccion
{
    public class CrearTransaccionHandler : IRequestHandler<CrearTransaccionCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransaccionFactory _transaccionFactory;
        private readonly ITransaccionRepository _transaccionRepository;
        private readonly ICuentaRepository _cuentaRepository;

        public CrearTransaccionHandler(IUnitOfWork unitOfWork, 
            ITransaccionFactory transaccionFactory, 
            ITransaccionRepository transaccionRepository,
            ICuentaRepository cuentaRepository)
        {
            _unitOfWork = unitOfWork;
            _transaccionFactory = transaccionFactory;
            _transaccionRepository = transaccionRepository;
            _cuentaRepository = cuentaRepository;
        }
        public async Task<Guid> Handle(CrearTransaccionCommand request, CancellationToken cancellationToken)
        {
            var cuenta = await _cuentaRepository.FindByIdAsync(request.CuentaId);
            if (cuenta == null)
            {
                throw new Exception("La cuenta no existe");
            }

            decimal saldoCuenta = cuenta.SaldoInicial;

            if (saldoCuenta == 0 || saldoCuenta < request.Monto)
                throw new Exception("La cuenta no tiene suficiente fondo");

            Transaccion transaccion = request.Tipo == Dto.Movimiento.Egreso ?
                _transaccionFactory.CrearTransaccionEgreso() :
                _transaccionFactory.CrearTransaccionIngreso();

            transaccion.agregarDatos(request.Monto, request.Descripcion, request.CuentaId, request.CategoriaId);

            //var transaccion = _transaccionFactory.Create(request.Monto, request.Descripcion, request.CuentaId, transaccion.Tipo, Wsfinanceperson.Domain.Models.Transacciones.EstadoTransaccion.Registrado, request.CategoriaId);

            await _transaccionRepository.CreateAsync(transaccion);
            await _unitOfWork.Commit();

            return transaccion.Id;
        }
    }
}
