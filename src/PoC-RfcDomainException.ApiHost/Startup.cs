using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NxtPort.Lib.ExceptionHandling;
using PoC_RfcDomainException.Database;

namespace PoC_RfcDomainException.ApiHost
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddHealthChecks()
                .AddDbContextCheck<CarDbContext>(tags: new[] { "db" });

            services
                .AddControllers(options =>
                {
                    options.SuppressAsyncSuffixInActionNames = false; // Fix nameof(actionName) for CreatedAtAction
                    options.Filters.Add(new ProducesAttribute("application/json"));
                })
                .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; })
                .AddFluentValidation(configuration =>
                {
                    configuration.RegisterValidatorsFromAssemblyContaining<Startup>();
                    configuration.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    configuration.ImplicitlyValidateChildProperties = true;
                });

            services.AddDbContext<CarDbContext>(options => options.UseInMemoryDatabase("CarDb"));

            services
                .AddMappers()
                .AddDomainServices()
                .AddDomainMappers()
                .AddDatabaseRepositories();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseNxtPortExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health", new HealthCheckOptions { Predicate = registration => registration.Tags.Count == 0 });
                endpoints.MapHealthChecks("/health/db", new HealthCheckOptions { Predicate = registration => registration.Tags.Contains("db") });

                endpoints.MapControllers();
            });
        }
    }
}