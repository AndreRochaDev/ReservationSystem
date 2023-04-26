using ReservationSystem.Shared.Interface.RoomManagement;
using ReservationSystem.Shared.Interfaces.RoomManagement.Models;
using SharedRoom = ReservationSystem.Shared.Interfaces.RoomManagement.Models.Room;
using SharedReservation = ReservationSystem.Shared.Interfaces.RoomManagement.Models.Reservation;
using ReservationSystem.RoomManagement.Data.SQLite.Data.DbContext;
using ReservationSystem.RoomManagement.Data.SQLite.Converters;
using Microsoft.EntityFrameworkCore;

namespace ReservationSystem.RoomManagement.Data.SQLite.Services
{
    public class RoomManagementSQLiteService : IRoomManagement
    {
        private RoomManagementDbContext _dbContext;

        public RoomManagementSQLiteService(RoomManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<SharedReservation>> GetReservations(GetReservationsParameters parameters)
        {
            return await _dbContext.Reservations
                .Select(r => r.AsSharedReservationeObject())
                .ToListAsync();
        }

        public async Task<IEnumerable<SharedReservation>> GetRoomReservations(GetRoomReservationsParameters parameters)
        {
            return await _dbContext.Reservations
                .Where(r => r.RessourceId == parameters.RoomId)
                .Select(r => r.AsSharedReservationeObject())
                .ToListAsync();
        }

        public async Task<IEnumerable<SharedReservation>> GetConflictReservations(GetConflictReservationsParameters parameters)
        {
            var reservations = await _dbContext.Reservations
                .Where(
                    r => r.RessourceId == parameters.RoomId &&
                    ((parameters.DateFrom == r.DateFrom && parameters.DateFrom <= r.DateTo) ||
                    (parameters.DateTo >= r.DateFrom && parameters.DateTo <= r.DateTo) ||
                    (parameters.DateFrom <= r.DateFrom && parameters.DateTo >= r.DateTo)))
                .ToListAsync();
            return reservations
                .Select(r => r.AsSharedReservationeObject());
        }

        public async Task<SharedRoom?> GetRoom(int roomId)
        {
           var room = await _dbContext.Rooms.FirstOrDefaultAsync(r => r.Id == roomId);
           if (room == null)
               return null;
           return room.AsSharedRoomResponseObject();
        }

        public async Task<IEnumerable<SharedRoom?>> GetRooms()
        {
            return await _dbContext.Rooms.Select(r => r.AsSharedRoomResponseObject()).ToListAsync();
        }               
    }
}
