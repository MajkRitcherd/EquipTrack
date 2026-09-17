namespace EquipTrack.Domain
{
    /// <summary>
    /// Holds basic hardware informace of the device.
    /// </summary>
    /// <param name="Cpu">Name of the CPU.</param>
    /// <param name="IntegratedGpu">Name of integrated GPU.</param>
    /// <param name="DedicatedGpu">Name of dedicated GPU.</param>
    /// <param name="RamStorageInGB">RAM storage in GBs.</param>
    /// <param name="StorageInGB">Storage in GBs.</param>
    public record DeviceHardwareInfo(
        string Cpu,
        string? IntegratedGpu,
        string? DedicatedGpu,
        int RamStorageInGB,
        int StorageInGB
    );
}