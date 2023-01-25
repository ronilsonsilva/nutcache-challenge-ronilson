using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nutcache.Application.AutoMapper;
using Nutcache.Application.Contracts;
using Nutcache.Application.Models;
using Nutcache.Application.Services;
using Nutcache.Domain.Contracts.DomainServices;
using Nutcache.Domain.Contracts.Repositories;
using Nutcache.Domain.DomainServices;
using Nutcache.Infra.Data.Context;
using Nutcache.Infra.Data.Repositories;

namespace Nutcache.Infra.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            #region [Configurations]

            var connection = configuration["CONNECTION_STRING:NutcacheContext"];
            services.AddDbContext<NutcacheContext>
                (options =>
                    options.UseSqlServer(connectionString: connection)
                );
            services.AddScoped<NutcacheContext, NutcacheContext>();

            // Configurar Automapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion

            #region [DI]

            services.AddScoped(typeof(IDomainServices<>), typeof(DomainServices<>));
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));

            services.AddScoped(typeof(IApplicationServices<EmployeeDto, CreateEmployeeDto, UpdateEmployeeDto, ListEmployeeDto>), typeof(ApplicationServices<Domain.Entities.Employee, EmployeeDto, CreateEmployeeDto, UpdateEmployeeDto, ListEmployeeDto>));

            #endregion
        }
    }
}