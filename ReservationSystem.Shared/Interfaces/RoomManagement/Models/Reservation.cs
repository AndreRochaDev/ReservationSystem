namespace ReservationSystem.Shared.Interfaces.RoomManagement.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
        public int ReservedPeople { get; set; }
        public int RessourceId { get; set; }
    }
}
