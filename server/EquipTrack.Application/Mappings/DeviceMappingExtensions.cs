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

        /// <summary>
        /// Converts DTO create device request to Device class.
        /// </summary>
        /// <param name="request">Data-Transfer Object (DTO) used to create a new device in a system.</param>
        /// <returns>New device created from request DTO.</returns>
        public static Device ToDevice(this CreateDeviceRequest request)
        {
            DeviceHardwareInfo? hardwareInfo = null;
            if (!string.IsNullOrEmpty(request.Cpu)
                && request.RamStorageInGB is {} ramStorage
                && request.StorageInGB is {} storage)
            {
                hardwareInfo = new DeviceHardwareInfo(
                    request.Cpu,
                    request.IntegratedGpu,
                    request.DedicatedGpu,
                    ramStorage,
                    storage);
            }

            var device = new Device
            {
                Id = Guid.NewGuid(),
                ManufacturerName = request.ManufacturerName,
                ModelName = request.ModelName,
                SerialNumber = request.SerialNumber,
                HardwareInfo = hardwareInfo
            };

            return device;
        }
    }
}