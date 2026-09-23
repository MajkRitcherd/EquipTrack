namespace EquipTrack.Application.DTOs
{
    /// <summary>
    /// Representation of a device as Data-Transfer Object (DTO).
    /// </summary>
    /// <param name="Id">Device's ID.</param>
    /// <param name="Manufacturer">Manufacturer of a device.</param>
    /// <param name="Model">Device model.</param>
    /// <param name="DisplayName">Device's display name.</param>
    /// <param name="SerialNumber">Device's serial number.</param>
    /// <param name="State">Device's state (as string).</param>
    /// <param name="UserId">Device's user ID, if is assigned.</param>
    /// <param name="Cpu">Device's CPU, if any.</param>
    /// <param name="IntegratedGpu">Device's integrated GPU, if any.</param>
    /// <param name="DedicatedGpu">Device's dedicated GPU, if any.</param>
    /// <param name="RamStorageInGB">Device's RAM storage in GB.</param>
    /// <param name="StorageInGB">Device's total storage in GB.</param>
    public record DeviceResponseDto(
        Guid Id,
        string Manufacturer,
        string Model,
        string DisplayName,
        string SerialNumber,
        string State,
        int? UserId,
        string? Cpu,
        string? IntegratedGpu,
        string? DedicatedGpu,
        int? RamStorageInGB,
        int? StorageInGB
    );
}