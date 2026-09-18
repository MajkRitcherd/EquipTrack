namespace EquipTrack.Domain
{
    /// <summary>
    /// Information about device, such as its state, names, serial number, hardware information.
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Gets device's hardware information such as CPU, GPU, RAM, ...
        /// </summary>
        public DeviceHardwareInfo? HardwareInfo { get; init; }

        /// <summary>
        /// Gets unique ID of a device.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// Gets manufacturer's name (e.g.: Acer, Lenovo, ...).
        /// </summary>
        public required string ManufacturerName { get; init; }

        /// <summary>
        /// Gets model name (e.g.: Nitro 5, IdeaPad, ...).
        /// </summary>
        public required string ModelName { get; init; }

        /// <summary>
        /// Gets a device's unique serial number.
        /// </summary>
        public required string SerialNumber { get; init; }

        /// <summary>
        /// Gets a state of a device (e.g.: In stock, Assigned, ...)
        /// </summary>
        public DeviceState State { get; private set; } = DeviceState.InStock;

        /// <summary>
        /// Gets ID of a user to whom the device is assigned.
        /// </summary>
        public int? UserId { get; private set; }

        /// <summary>
        /// Assigns a device to a user.
        /// </summary>
        /// <param name="userId">User's ID.</param>
        /// <exception cref="InvalidOperationException">Thrown if device is not in required state.</exception>
        public void AssignToUser(int userId)
        {
            if (State == DeviceState.Assigned || State == DeviceState.InRepair)
                throw new InvalidOperationException($"Device is not in stock, Device's state: '{State}'");

            UserId = userId;
            State = DeviceState.Assigned;
        }

        /// <summary>
        /// Returns device to stock (unassigns from a user).
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if device is not in required state.</exception>
        public void ReturnToStock()
        {
            if (State == DeviceState.InStock)
                throw new InvalidOperationException("Device is already in stock");

            if (State != DeviceState.Assigned)
                throw new InvalidOperationException($"Device is not in required state '{nameof(DeviceState.Assigned)}', Device's state: '{State}'");

            UserId = null;
            State = DeviceState.InStock;
        }

        /// <summary>
        /// Send the device to repair.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if device is not in required state (in repair).</exception>
        public void SendToRepair()
        {
            if (State == DeviceState.InRepair)
                throw new InvalidOperationException($"Device is already in repair");

            UserId = null;
            State = DeviceState.InRepair;
        }
    }
}