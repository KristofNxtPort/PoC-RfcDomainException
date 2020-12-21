using Microsoft.Extensions.DependencyInjection;
using PoC_RfcDomainException.ApiHost.Mappers;
using PoC_RfcDomainException.ApiHost.Mappers.Interfaces;
using PoC_RfcDomainException.Database.Commands;
using PoC_RfcDomainException.Database.Contract.Commands;
using PoC_RfcDomainException.Database.Contract.Queries;
using PoC_RfcDomainException.Database.Queries;
using PoC_RfcDomainException.Domain.Contract.Services;
using PoC_RfcDomainException.Domain.Services;

namespace PoC_RfcDomainException.ApiHost
{
    internal static class ServiceCollectionConfiguration
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddTransient<ICarMapper, CarMapper>();

            return services;
        }

        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<ICarService, CarService>();

            return services;
        }

        public static IServiceCollection AddDomainMappers(this IServiceCollection services)
        {
            services.AddTransient<Domain.Mappers.Interfaces.ICarMapper, Domain.Mappers.CarMapper>();

            return services;
        }

        public static IServiceCollection AddDatabaseRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICarQueryRepository, CarQueryRepository>();

            services.AddTransient<ICarCommandRepository, CarCommandRepository>();

            return services;
        }
    }
}