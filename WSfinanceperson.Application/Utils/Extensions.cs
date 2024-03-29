﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Factories;

namespace Reserva.Aplication.Utils
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IPersonaFactory, PersonaFactory>();
            services.AddScoped<ICuentaFactory, CuentaFactory>();
            services.AddScoped<ICategoriaFactory, CategoriaFactory>();
            services.AddScoped<ITransaccionFactory, TransaccionFactory>();
            services.AddScoped<ITransferenciaFactory, TransferenciaFactory>();
            //services.AddScoped<IReservaFactory, ReservaFactory>();
            //services.AddScoped<ITipoHabitacionFactory, TipoHabitacionFactory>();

            return services;
        }
    }
}
