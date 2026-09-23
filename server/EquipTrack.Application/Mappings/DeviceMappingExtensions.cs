using EquipTrack.Application.DTOs;
using EquipTrack.Domain;

namespace EquipTrack.Application.Mappings
{
    /// <summary>
    /// Extensions methods related to device class.
    /// </summary>
    public static class DeviceMappingExtensions
    {
        /// <summary>
        /// Converts device class into DeviceResponse Data-Transfer Object.
        /// </summary>
        /// <param name="device">Specific device we want to convert.</param>
        /// <returns>DTO representation of a device.</returns>
        public static DeviceResponseDto ToResponseDto(this Device device)
        {
            return new DeviceResponseDto(
                device.Id,
                device.ManufacturerName,
                device.ModelName,
                $"{device.ManufacturerName} {device.ModelName}",
                device.SerialNumber,
                device.State.ToString(),
                device.UserId,
                device.HardwareInfo?.Cpu,
                device.HardwareInfo?.IntegratedGpu,
                device.HardwareInfo?.DedicatedGpu,
                device.HardwareInfo?.RamStorageInGB,
                device.HardwareInfo?.StorageInGB
            );
        }
    }
}