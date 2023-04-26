namespace ReservationSystem.Shared.Interfaces.RoomManagement.Models
{
    public record GetRoomReservationsParameters
    {
        public int RoomId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
