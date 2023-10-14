using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Domain.Repositories;

namespace WSfinanceperson.Application.UseCases.Query.Categoria.GetCategoriaById
{
    public class GetCategoriaByIdHandler : IRequestHandler<GetCategoriaByIdQuery, CategoriaDto>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ILogger<GetCategoriaByIdQuery> _logger;

        public GetCategoriaByIdHandler(ICategoriaRepository categoriaRepository, ILogger<GetCategoriaByIdQuery> logger)
        {
            _categoriaRepository = categoriaRepository;
            _logger = logger;
        }
        public async Task<CategoriaDto> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
        {
            CategoriaDto categoriaDto = null;
            try
            {
                var categoria = await _categoriaRepository.FindByIdAsync(request.Id);
                if (categoria != null)
                {
                    categoriaDto = new CategoriaDto()
                    {
                        Id = categoria.Id,
                        Nombre = categoria.Nombre,
                        CuentaId = categoria.CuentaId
                    };
                    return categoriaDto;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }

            return categoriaDto;   
        }
    }
}
