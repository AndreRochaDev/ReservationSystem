using ReservationSystem.Shared.Interface.RoomManagement;
using ReservationSystem.Shared.Interfaces.RoomManagement.Models;

namespace ReservationSystem.RoomManagement.SQLite.Services
{
    public class RoomManagementSQLiteService : IRoomManagement
    {
        private List<Room> _rooms = new();
        private List<Reservation> _reservations = new();

        public RoomManagementSQLiteService()
        {
            InitializeDummyRooms();
        }


        public Task<IEnumerable<Reservation>> GetReservations(GetReservationsParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetRoomReservations(GetRoomReservationsParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<Room?> GetRoom(int roomId)
        {
           return _rooms.FirstOrDefault(r => r.Id == roomId);
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            return _rooms.AsEnumerable();
        }

        private void InitializeDummyRooms()
        {
            _rooms.Clear();

            _rooms.Add(new Room { Id = 1, Name = "Single Bedroom", NumberOfPeople = 1 });
            _rooms.Add(new Room { Id = 2, Name = "Double Bedroom", NumberOfPeople = 2 });
            _rooms.Add(new Room { Id = 3, Name = "Family Bedroom", NumberOfPeople = 4 });
        }
    }
}
