using ReservationSystem.Shared.Interfaces.RoomBooking.Models;

namespace ReservationSystem.Shared.Interfaces.RoomBooking
{
    public interface IRoomBooking
    {
        Task<RoomBookingResult> BookRoom(BookRoomParameters parameters);
    }
}
