using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using JGQZ.ArqLimpia.EN.Interfaces;
using JGQZ.ArqLimpia.EN;
using JGQZ.ArqLimpia.DAL;
using JGQZ.ArqLimpia.BL;
using Microsoft.Extensions.Options;

namespace JGQZ.ArqLimpia.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddProyectDEpendecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDALDependecies(configuration);
            services.AddBLDependecies();
            return services;
        }
    }
}
