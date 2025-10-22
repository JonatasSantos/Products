using api.Application.MappingInterface;
using api.Application.UseCaseImplementation;
using api.Application.UseCaseInterface;
using api.Domain.RepositoryInterface;
using api.Infrastructure.DatabaseContext;
using api.Infrastructure.RepositoryImplementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(o => o.UseSqlite(config.GetConnectionString("Default")));
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
