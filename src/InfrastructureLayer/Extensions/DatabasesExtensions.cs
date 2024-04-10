using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Extensions
{
    public static class DatabasesExtensions
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string connectionString) 
        {
            services.AddDbContext<ContratAutoDbContext>(options =>
            {
                options.UseSqlServer(connectionString, 
                    assembly => assembly.MigrationsAssembly(typeof(ContratAutoDbContext).Assembly.FullName));
            });
            return services;
        }
    }
}
