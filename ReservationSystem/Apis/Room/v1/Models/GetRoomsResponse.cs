namespace ReservationSystem.Apis.Room.v1.Models
{
    public class GetRoomsResponse
    {
        public List<Room?> Rooms { get; set; } = new();

        public GetRoomsResponse()
        {
            
        }

        public GetRoomsResponse(IEnumerable<Shared.Interfaces.RoomManagement.Models.Room> rooms)
        {
            Rooms = rooms.Select(r => r?.AsRoomResponseObject()).ToList();
        }
    }
}
