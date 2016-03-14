using Microsoft.Data.Entity;

namespace BusyRoom.Models
{
    public class BusyRoomContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Startup.Configuration["Data:ConnectionString"];
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasAlternateKey(r => r.Name).HasName("AlternateKey_Name");
            base.OnModelCreating(modelBuilder);
        }
    }
}