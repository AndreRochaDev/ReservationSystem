namespace ReservationSystem.Shared.Interfaces.RoomManagement.Models
{
    public record GetConflictReservationsParameters
    {
        public int RoomId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
