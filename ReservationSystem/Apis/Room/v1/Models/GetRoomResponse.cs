namespace ReservationSystem.Apis.Room.v1.Models
{
    public class GetRoomResponse
    {
        public Room? Room { get; set; }

        public GetRoomResponse()
        {
            
        }

        public GetRoomResponse(Shared.Interfaces.RoomManagement.Models.Room room)
        {
            Room = room.AsRoomResponseObject();
        }
    }
}
