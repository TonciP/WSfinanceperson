﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Infrastructure.EF.ReadModel
{
    public class CategoriaReadModel
    {
        public Guid Id { get; set; }
        public Guid CuentaId { get;  set; }
        public string Nombre { get;  set; }
    }
}
