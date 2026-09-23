namespace EquipTrack.Application.DTOs
{
    /// <summary>
    /// Represents the Data-Transfer Object (DTO) used for creating a new device in the system.
    /// </summary>
    /// <remarks>
    /// This record is used to safely transport data from the API endpoint to the application layer.
    /// Hardware properties (CPU, GPU, RAM, Storage) are optional to support non-compute devices like monitors.
    /// </remarks>
    /// <param name="ManufacturerName">The name of the manufacturer (e.g. Apple, Dell).</param>
    /// <param name="ModelName">The specific model name of the device.</param>
    /// <param name="SerialNumber">The unique serial number identifying the hardware.</param>
    /// <param name="Cpu">The processor name, if applicable.</param>
    /// <param name="IntegratedGpu">The integrated graphics unit name, if applicable.</param>
    /// <param name="DedicatedGpu">The dedicated graphics unit name, if applicable.</param>
    /// <param name="RamStorageInGB">The amount of RAM in GB, if applicable.</param>
    /// <param name="StorageInGB">The total storage capacity in GB, if applicable.</param>
    public record CreateDeviceRequest(
        string ManufacturerName,
        string ModelName,
        string SerialNumber,
        string? Cpu,
        string? IntegratedGpu,
        string? DedicatedGpu,
        int? RamStorageInGB,
        int? StorageInGB
    );
}