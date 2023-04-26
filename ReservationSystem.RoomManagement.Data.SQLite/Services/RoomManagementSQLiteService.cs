using ReservationSystem.RoomManagement.Data.SQLite.Data.Models;
using ReservationSystem.Shared.Interface.RoomManagement;
using ReservationSystem.Shared.Interfaces.RoomManagement.Models;
using SharedRoom = ReservationSystem.Shared.Interfaces.RoomManagement.Models.Room;
using SharedReservation = ReservationSystem.Shared.Interfaces.RoomManagement.Models.Reservation;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ReservationSystem.RoomManagement.Data.SQLite.Services
{
    public class RoomManagementSQLiteService : IRoomManagement
    {
        private List<SharedRoom> _rooms = new();
        private List<SharedReservation> _reservations = new();

        public RoomManagementSQLiteService()
        {
            InitializeDummyRooms();
            InitializeDummyReservations();
        }


        public Task<IEnumerable<SharedReservation>> GetReservations(GetReservationsParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SharedReservation>> GetRoomReservations(GetRoomReservationsParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SharedReservation>> GetConflictReservations(GetConflictReservationsParameters parameters)
        {
            return _reservations.Where(
            r => r.RessourceId == parameters.RoomId &&
            ((parameters.DateFrom == r.DateFrom && parameters.DateFrom <= r.DateTo) || 
            (parameters.DateTo >= r.DateFrom && parameters.DateTo <= r.DateTo) ||
            (parameters.DateFrom <= r.DateFrom && parameters.DateTo >= r.DateTo)));
        }

        public async Task<SharedRoom?> GetRoom(int roomId)
        {
           return _rooms.FirstOrDefault(r => r.Id == roomId);
        }

        public async Task<IEnumerable<SharedRoom>> GetRooms()
        {
            return _rooms.AsEnumerable();
        }

        

        private void InitializeDummyRooms()
        {
            _rooms.Clear();

            _rooms.Add(new SharedRoom { Id = 1, Name = "Single Bedroom", NumberOfPeople = 1 });
            _rooms.Add(new SharedRoom { Id = 2, Name = "Double Bedroom", NumberOfPeople = 2 });
            _rooms.Add(new SharedRoom { Id = 3, Name = "Family Bedroom", NumberOfPeople = 4 });
        }

        private void InitializeDummyReservations()
        {
            _reservations.Clear();

            _reservations.Add(new SharedReservation { Id = 1, DateFrom = new DateTime(2023, 05, 01), DateTo = new DateTime(2023, 05, 05), ReservedPeople = 1, RessourceId = 3 });
            _reservations.Add(new SharedReservation { Id = 2, DateFrom = new DateTime(2023, 05, 04), DateTo = new DateTime(2023, 05, 05), ReservedPeople = 3, RessourceId = 3 });
        }
    }
}
