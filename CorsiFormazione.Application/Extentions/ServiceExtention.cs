using CorsiFormazione.Application.Abstractions.Services;
using CorsiFormazione.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Application.Extentions
{
    public static class ServiceExtention
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.GetAssemblies()
                .SingleOrDefault(assembly => assembly.GetName().Name == "CorsiFormazione.Application"));
            services.AddScoped<IUtenteService, UtenteService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICorsoService, CorsoService>();
            services.AddScoped<IPresenzaService, PresenzaService>();

            return services;
        }
    }
}
