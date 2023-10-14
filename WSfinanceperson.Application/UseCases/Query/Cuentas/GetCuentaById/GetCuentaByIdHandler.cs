using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Application.UseCases.Query.Cuentas.GetCuentaBy;
using WSfinanceperson.Domain.Factories;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Query.Cuentas.GetCuentaById
{
    public class GetCuentaByIdHandler : IRequestHandler<GetCuentaByIdQuery, CuentaDto>
    {
        private readonly ICuentaRepository _cuentaRepository;
        //private readonly ICuentaFactory _cuentaFactory;

        public GetCuentaByIdHandler(ICuentaRepository cuentaRepository, ICuentaFactory cuentaFactory)
        {
            _cuentaRepository = cuentaRepository;
            //_cuentaFactory = cuentaFactory;
        }
        public async Task<CuentaDto> Handle(GetCuentaByIdQuery request, CancellationToken cancellationToken)
        {
            CuentaDto cuentaDto = null;
            try
            {
                Cuenta cuenta = await _cuentaRepository.FindByIdAsync(request.Id);
                if (cuenta != null)
                {
                    cuentaDto = new CuentaDto()
                    {
                        Id = cuenta.Id,
                        Nombre = cuenta.Nombre,
                        SaldoInicial = cuenta.SaldoInicial
                    };
                    return cuentaDto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
            
        }
    }
}
