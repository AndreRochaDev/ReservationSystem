namespace ReservationSystem.Shared.Interfaces.RoomBooking.Models
{
    public record BookRoomParameters
    {
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
        public int ReservedPeople { get; set; }
        public int RoomId { get; set; }
    }
}
