using SharedRoom = ReservationSystem.Shared.Interfaces.RoomManagement.Models.Room;
using SharedReservation = ReservationSystem.Shared.Interfaces.RoomManagement.Models.Reservation;
using ReservationSystem.RoomManagement.Data.SQLite.Data.Models;

namespace ReservationSystem.RoomManagement.Data.SQLite.Converters
{
    internal static class DbToDomainConverter
    {
        public static SharedReservation AsSharedReservationeObject(this Reservation room)
        {
            return new()
            {
                Id = room.Id,
                DateTo = room.DateTo,
                DateFrom = room.DateFrom,
                ReservedPeople = room.ReservedPeople,
                RessourceId = room.RessourceId,
            };
        }

        public static SharedRoom? AsSharedRoomResponseObject(this Room room)
        {
            if(room == null) return null;
            return new()
            {
                Id = room.Id,
                Name = room.Name,
                NumberOfPeople = room.NumberOfPeople
            };
        }
    }
}
