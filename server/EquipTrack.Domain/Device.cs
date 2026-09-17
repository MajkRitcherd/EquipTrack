namespace EquipTrack.Domain
{
    /// <summary>
    /// Information about device, such as its state, names, serial number, hardware information.
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Gets unique ID of a device.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// Gets a state of a device (e.g.: In stock, Assigned, ...)
        /// </summary>
        public DeviceState State { get; private set; } = DeviceState.InStock;

        /// <summary>
        /// Gets model name (e.g.: Nitro 5, IdeaPad, ...).
        /// </summary>
        public required string ModelName { get; init; }

        /// <summary>
        /// Gets manufacturer's name (e.g.: Acer, Lenovo, ...).
        /// </summary>
        public required string ManufacturerName { get; init; }

        /// <summary>
        /// Gets a device's unique serial number.
        /// </summary>
        public required string SerialNumber { get; init; }

        /// <summary>
        /// Gets device's hardware information such as CPU, GPU, RAM, ...
        /// </summary>
        public DeviceHardwareInfo? HardwareInfo { get; init; }
    }
}