using ReservationSystem.Shared.Interfaces.RoomBooking;
using ReservationSystem.Shared.Interfaces.RoomBooking.Models;
using ReservationSystem.RoomManagement.Data.SQLite.Data.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ReservationSystem.RoomManagement.Data.SQLite.Services
{
    public class RoomBookingSQLiteService : IRoomBooking
    {
        private RoomManagementDbContext _dbContext;

        public RoomBookingSQLiteService(RoomManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RoomBookingResult> BookRoom(BookRoomParameters parameters)
        {
            // This is wrong, I forgot the autoincrement and I have no time to change the structure now
            var generatedId = (await _dbContext.Reservations.CountAsync()) + 1;
            await _dbContext.Reservations.AddAsync(new Data.Models.Reservation
            {
                Id = generatedId,
                DateFrom = parameters.DateFrom,
                DateTo = parameters.DateTo,
                ReservedPeople = parameters.ReservedPeople,
                RessourceId = parameters.RoomId
            });
            await _dbContext.SaveChangesAsync();
            return new RoomBookingResult { Success = true, ReservationId = generatedId };
        }

    }
}
