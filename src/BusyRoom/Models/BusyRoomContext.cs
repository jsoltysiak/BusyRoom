﻿using Microsoft.Data.Entity;

namespace BusyRoom.Models
{
    public class BusyRoomContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<OccupyState> OccupyStates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Startup.Configuration["Data:ConnectionString"];
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}