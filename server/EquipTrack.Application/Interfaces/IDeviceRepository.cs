using EquipTrack.Domain;

namespace EquipTrack.Application.Interfaces
{
    /// <summary>
    /// Defines the data access contract for Device entities.
    /// </summary>
    public interface IDeviceRepository
    {
        /// <summary>
        /// Retrieves all devices from the database asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A list containing all devices.</returns>
        Task<List<Device>> GetAllDevicesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a specific device by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the device to retrieve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The matching device if found; otherwise, null.</returns>
        Task<Device?> GetDeviceByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}