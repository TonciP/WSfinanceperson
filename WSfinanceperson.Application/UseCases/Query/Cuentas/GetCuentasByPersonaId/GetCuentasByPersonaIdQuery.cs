﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Cuentas;

namespace WSfinanceperson.Application.UseCases.Query.Cuentas.GetCuentasByPersonaId
{
    public class GetCuentasByPersonaIdQuery : IRequest<Cuenta>
    {
    }
}
