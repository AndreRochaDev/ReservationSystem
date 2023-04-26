namespace ReservationSystem.Apis.Booking.v1.Models
{
    public record BookRoomRequest
    {
        public int RoomId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int NumberOfPeople { get; set; }
    }
}
