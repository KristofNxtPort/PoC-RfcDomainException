using Microsoft.Extensions.DependencyInjection;
using PoC_RfcDomainException.Database.Contract.Queries;
using PoC_RfcDomainException.Database.Queries;

namespace PoC_RfcDomainException.ApiHost
{
    internal static class DependencyInjectionCollection
    {
        public static IServiceCollection AddDatabaseRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICarQueryRepository, CarQueryRepository>();

            return services;
        }
    }
}