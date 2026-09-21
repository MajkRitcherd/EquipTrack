using EquipTrack.Domain;
using Microsoft.EntityFrameworkCore;

namespace EquipTrack.Infrastructure
{
    /// <summary>
    /// Custom application's DB context.
    /// </summary>
    /// <param name="dbContextOptions">DB context options.</param>
    public class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : DbContext(dbContextOptions)
    {
        /// <summary>
        /// Gets or sets a set/table of devices.
        /// </summary>
        public DbSet<Device> Devices { get; set; }

        /// <summary>
        /// Gets or sets a set/table of users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Device>()
                .OwnsOne(device => device.HardwareInfo);
        }
    }
}