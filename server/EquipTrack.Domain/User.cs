namespace EquipTrack.Domain
{
    /// <summary>
    /// Basic information about user.
    /// </summary>
    /// <param name="Id">User's unique ID.</param>
    /// <param name="FirstName">User's first name.</param>
    /// <param name="LastName">User's last name.</param>
    /// <param name="Email">User's email.</param>
    public class User
    {
        /// <summary>
        /// Gets user's email.
        /// </summary>
        public required string Email { get; init; }

        /// <summary>
        /// Gets user's first name.
        /// </summary>
        public required string FirstName { get; init; }

        /// <summary>
        /// Gets user's ID.
        /// </summary>
        public required int Id { get; init; }

        /// <summary>
        /// Gets user's last name.
        /// </summary>
        public required string LastName { get; init; }
    }
}