namespace ReservationSystem.Services.Booking.Models
{
    public class BookRoomParameters
    {
        public int RoomId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int NumberOfPeople { get; set; }
    }
}
