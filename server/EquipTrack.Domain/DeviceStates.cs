namespace EquipTrack.Domain
{
    /// <summary>
    /// States in which a device can be.
    /// </summary>
    public enum DeviceState
    {
        /// <summary>
        /// Device is assigned to a user.
        /// </summary>
        Assigned,

        /// <summary>
        /// Device is available in stock and can be assigned.
        /// </summary>
        InStock,

        /// <summary>
        /// Device is in repair.
        /// </summary>
        InRepair,
    }
}