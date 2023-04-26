using Microsoft.EntityFrameworkCore;
using Room = ReservationSystem.RoomManagement.Data.SQLite.Data.Models.Room;
using Reservation = ReservationSystem.RoomManagement.Data.SQLite.Data.Models.Reservation;

namespace ReservationSystem.RoomManagement.Data.SQLite.Data.DbContext
{
    public class RoomManagementDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public RoomManagementDbContext(DbContextOptions<RoomManagementDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasKey(r => r.Id);
            modelBuilder.Entity<Reservation>().HasKey(r => r.Id);
            modelBuilder.Entity<Room>().HasData(
                    new Room { Id = 1, Name = "Single Bedroom", NumberOfPeople = 1 },
                    new Room { Id = 2, Name = "Double Bedroom", NumberOfPeople = 2 },
                    new Room { Id = 3, Name = "Family Bedroom", NumberOfPeople = 3 }
                    );
            modelBuilder.Entity<Reservation>().HasData(
                    new Reservation { Id = 1, DateFrom = new DateTime(2023, 05, 01), DateTo = new DateTime(2023, 05, 05), ReservedPeople = 1, RessourceId = 3 },
                    new Reservation { Id = 2, DateFrom = new DateTime(2023, 05, 04), DateTo = new DateTime(2023, 05, 05), ReservedPeople = 3, RessourceId = 3 }
                    );

            base.OnModelCreating(modelBuilder);
        }
    }
}