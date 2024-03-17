using BeckTech.Data.Context;
using BeckTech.Data.Repositories.Abtractions;
using BeckTech.Data.Repositories.Concretes;
using BeckTech.Data.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Data.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtensions(this IServiceCollection services, IConfiguration config )
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); //Dependency Injection
            services.AddDbContext<BeckTechDbContext>(opts => opts.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();   //Dependency Injection
            return services;
        }
    }
}
