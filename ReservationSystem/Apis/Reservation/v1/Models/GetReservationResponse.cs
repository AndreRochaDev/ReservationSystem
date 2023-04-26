namespace ReservationSystem.Apis.Reservation.v1.Models
{
    public class GetRoomReservationsResponse
    {
        public List<Reservation>? Reservations { get; set; }

        public GetRoomReservationsResponse()
        {

        }

        public GetRoomReservationsResponse(IEnumerable<Shared.Interfaces.RoomManagement.Models.Reservation> reservations)
        {
            Reservations = reservations.Select(r => r.AsReservationResponseObject()).ToList();
        }
    }
}
