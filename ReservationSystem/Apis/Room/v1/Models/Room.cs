namespace ReservationSystem.Apis.Room.v1.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberOfPeople { get; set; }
    }

    public static class RoomExtensions
    {
        public static Room? AsRoomResponseObject(this Shared.Interfaces.RoomManagement.Models.Room room)
        {
            if (room == null) return null;
            return new()
            {
                Id = room.Id,
                Name = room.Name,
                NumberOfPeople = room.NumberOfPeople
            };
        }
    }
}
