namespace ReservationSystem.Apis.Reservation.v1.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
        public int ReservedPeople { get; set; }
        public int RessourceId { get; set; }
    }

    public static class ReservationExtensions
    {
        public static Reservation AsReservationResponseObject(this Shared.Interfaces.RoomManagement.Models.Reservation room)
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
    }
}
