using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.RoomManagement.Data.SQLite.Data.Models 
{ 
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberOfPeople { get; set; }
    }
}
