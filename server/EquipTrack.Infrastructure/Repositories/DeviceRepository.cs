using EquipTrack.Application.Interfaces;
using EquipTrack.Domain;
using Microsoft.EntityFrameworkCore;

namespace EquipTrack.Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of the device repository using Entity Framework Core.
    /// </summary>
    /// <param name="appDbContext">Application's database context.</param>
    public class DeviceRepository(AppDbContext appDbContext) : IDeviceRepository
    {
        /// <inheritdoc/>
        public async Task AddAsync(Device device, CancellationToken cancellationToken = default)
        {
            appDbContext.Devices.Add(device);
            await appDbContext.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<List<Device>> GetAllDevicesAsync(CancellationToken cancellationToken = default)
        {
            return appDbContext.Devices
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<Device?> GetDeviceByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return appDbContext.Devices
                .FirstOrDefaultAsync(device => device.Id == id, cancellationToken);
        }
    }
}