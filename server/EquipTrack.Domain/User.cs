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
        public required string Email { get; init; }
        public required string FirstName { get; init; }
        public required int Id { get; init; }
        public required string LastName { get; init; }
    }
}