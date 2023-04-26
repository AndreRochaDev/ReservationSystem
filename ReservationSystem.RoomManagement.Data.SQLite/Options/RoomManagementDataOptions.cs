using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.RoomManagement.Data.SQLite.Options
{
    public class RoomManagementDataOptions
    {
        public const string ConfigurationPosition = "SQLite:ConnectionStrings";
        public const string ConfigurationConnectionStringPosition = "SQLite:ConnectionStrings:RoomManagement";
        [Required]
        public string? RoomManagement { get; set; }
    }
}
