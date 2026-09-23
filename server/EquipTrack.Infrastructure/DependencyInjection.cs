using EquipTrack.Application.Interfaces;
using EquipTrack.Infrastructure.DataSeeding;
using EquipTrack.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EquipTrack.Infrastructure
{
    /// <summary>
    /// Provides extension methods to register infrastructure dependencies.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds infrastructure services (database contexts, repositories) to the dependency injection container.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param></param>
        /// <returns>The same service collection so that multiple calls can be chained.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite("Data Source=equiptrack.db");
            });

            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<DbInitializer>();

            return services;
        }        
    }
}