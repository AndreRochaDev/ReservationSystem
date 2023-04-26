using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.RoomManagement.Data.SQLite.Data.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
        public int ReservedPeople { get; set; }
        public int RessourceId { get; set; }
    }
}
