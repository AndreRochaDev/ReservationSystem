using Microsoft.EntityFrameworkCore;
using ReservationSystem.RoomManagement.SQLite.Data.Models;

namespace ReservationSystem.RoomManagement.SQLite.Data.DbContext
{
    public class RoomManagementDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasKey(r => r.Id);
            modelBuilder.Entity<Reservation>().HasKey(r => r.Id);
        }
    }
}
