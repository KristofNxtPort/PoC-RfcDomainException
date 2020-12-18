using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            services.AddControllers();

            services.AddDbContext<CarDbContext>(options => options.UseInMemoryDatabase("CarDb"));

            services.AddDatabaseRepositories();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

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