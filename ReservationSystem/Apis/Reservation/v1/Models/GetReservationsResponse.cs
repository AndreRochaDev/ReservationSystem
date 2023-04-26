namespace ReservationSystem.Apis.Reservation.v1.Models
{
    public class GetReservationsResponse
    {
        public List<Reservation>? Reservations { get; set; }

        public GetReservationsResponse()
        {
            
        }

        public GetReservationsResponse(IEnumerable<Shared.Interfaces.RoomManagement.Models.Reservation> reservations)
        {
            Reservations = reservations.Select(r => r.AsReservationResponseObject()).ToList();
        }
    }
}
