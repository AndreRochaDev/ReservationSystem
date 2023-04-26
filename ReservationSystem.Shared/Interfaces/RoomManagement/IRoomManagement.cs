using ReservationSystem.Shared.Interfaces.RoomManagement.Models;

namespace ReservationSystem.Shared.Interface.RoomManagement
{
    public interface IRoomManagement
    {
        Task<IEnumerable<Room>> GetRooms();
        Task<Room?> GetRoom(int roomId);
        Task<IEnumerable<Reservation>> GetReservations(GetReservationsParameters parameters);
        Task<IEnumerable<Reservation>> GetRoomReservations(GetRoomReservationsParameters parameters);
        Task<IEnumerable<Reservation>> GetConflictReservations(GetConflictReservationsParameters parameters);
    }

}
