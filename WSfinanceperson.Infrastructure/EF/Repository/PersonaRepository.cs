﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Personas;
using WSfinanceperson.Domain.Repositories;
using WSfinanceperson.Infrastructure.EF.Contexts;

namespace WSfinanceperson.Infrastructure.EF.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        public readonly DbSet<Persona> _persona;

        public PersonaRepository(WriteDbContext context)
        {
            _persona = context.Persona;
        }
        public Task CreateAsync(Persona obj)
        {
            throw new NotImplementedException();
        }

        public async Task<Persona> FindByIdAsync(Guid id)
        {
            return await _persona.SingleOrDefaultAsync(x => x.Id == id);
        }



        public Task UpdateAsync(Persona obj)
        {
            throw new NotImplementedException();
        }
    }
}