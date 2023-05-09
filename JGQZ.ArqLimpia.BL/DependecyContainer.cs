using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using JGQZ.ArqLimpia.BL.Interfaces;
using JGQZ.ArqLimpia.EN.Interfaces;
using JGQZ.ArqLimpia.EN;

namespace JGQZ.ArqLimpia.BL
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddBLDependecies(this IServiceCollection services)
        {
            services.AddTransient<IStudentBL, StudentBL>();
            return services;
        }
    }
}
