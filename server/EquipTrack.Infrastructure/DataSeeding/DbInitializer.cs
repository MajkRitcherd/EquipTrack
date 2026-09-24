using EquipTrack.Domain;
using Microsoft.EntityFrameworkCore;

namespace EquipTrack.Infrastructure.DataSeeding
{
    /// <summary>
    /// Initializes the SQLite database with initial test data upon application startup if the database is empty.
    /// </summary>
    /// <remarks>
    /// This initializer is typically executed during the application bootstrapping phase.
    /// </remarks>
    public class DbInitializer(AppDbContext appDbContext)
    {
        /// <summary>
        /// Checks if the database contains any devices and, if empty, seeds it with initial sample data.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests during databse operations.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SeedDataAsync(CancellationToken cancellationToken = default)
        {
            await appDbContext.Database.EnsureCreatedAsync(cancellationToken);

            if (await appDbContext.Devices.AnyAsync(cancellationToken))
                return;

            var macBook = new Device()
            {
                 Id = Guid.NewGuid(),
                 ManufacturerName = "Apple",
                 ModelName = "MacBook",
                 SerialNumber = "AM123",
                 HardwareInfo = new DeviceHardwareInfo("M1", "M1 Gpu", string.Empty, 32, 2000)
            };
            var gamingNtb = new Device()
            {
                 Id = Guid.NewGuid(),
                 ManufacturerName = "Acer",
                 ModelName = "Nitro 5",
                 SerialNumber = "AN5123",
                 HardwareInfo = new DeviceHardwareInfo("Ryzen 5 7500H", "Ryzen Integrated Gpu", "Radeon 9070 XT", 64, 4000)
            };

            await appDbContext.Devices.AddRangeAsync([macBook, gamingNtb], cancellationToken);
            await appDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}