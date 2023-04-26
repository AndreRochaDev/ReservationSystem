namespace ReservationSystem.Shared.Interfaces.RoomManagement.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberOfPeople { get; set; }
    }
}
