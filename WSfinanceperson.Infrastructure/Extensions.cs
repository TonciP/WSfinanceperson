using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Repositories;
using WSfinanceperson.Infrastructure.EF.Contexts;
using WSfinanceperson.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Reserva.Aplication.Utils;
using MediatR;

namespace WSfinanceperson.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddApplication();

            services.AddDbContext<ReadDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ReservaConnectionString"));
            });
            services.AddDbContext<WriteDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ReservaConnectionString"));
            });
            //Scoped: se crea una instancia por cada request
            //Transient: se crea una instancia por cada uso
            //Singleton: se crea una instancia por cada aplicación
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IClienteRepository, ClienteRepository>();
            //services.AddScoped<ITrackingRepository, TrackingRepository>();
            ////services.AddScoped<IHabitacionRepository, HabitacionRepository>();
            //services.AddScoped<ITipoHabitacionRepository, TipoHabitacionRepository>();
            //services.AddScoped<IReservarRepository, ReservaRepository>();
            //services.AddScoped<IEstadiaRepository, EstadiaRepository>();

            return services;
        }
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
        //public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        //    IConfiguration configuration)
        //{
        //    services.AddApplication();
        //    services.AddMediatR(Assembly.GetExecutingAssembly());

        //    var connectionString =
        //        configuration.GetConnectionString("InventarioDbConnectionString");

        //    services.AddDbContext<ReadDbContext>(context =>
        //        context.UseSqlServer(connectionString));
        //    services.AddDbContext<WriteDbContext>(context =>
        //        context.UseSqlServer(connectionString));

        //    services.AddScoped<IUnitOfWork, UnitOfWork>();
        //    services.AddScoped<IArticuloRepository, ArticuloRepository>();
        //    services.AddScoped<ITransaccionRepository, TransaccionRepository>();

        //    AddRabbitMq(services, configuration);

        //    return services;
        //}


        //private static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var rabbitMqHost = configuration["RabbitMq:Host"];
        //    var rabbitMqPort = configuration["RabbitMq:Port"];
        //    var rabbitMqUserName = configuration["RabbitMq:UserName"];
        //    var rabbitMqPassword = configuration["RabbitMq:Password"];

        //    services.AddMassTransit(config =>
        //    {
        //        config.UsingRabbitMq((context, cfg) =>
        //        {
        //            var uri = string.Format("amqp://{0}:{1}@{2}:{3}", rabbitMqUserName, rabbitMqPassword, rabbitMqHost, rabbitMqPort);
        //            cfg.Host(uri);
        //        });
        //    });
        //}

    }
}
