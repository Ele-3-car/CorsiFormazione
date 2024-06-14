using CorsiFormazione.Models.Context;
using CorsiFormazione.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Models.Extentions
{
    public static class ServiceExtention
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });
            services.AddScoped<UtenteRepository>();
            services.AddScoped<CorsoRepository>();
            services.AddScoped<PresenzaRepository>();

            return services;
        }
    }
}
