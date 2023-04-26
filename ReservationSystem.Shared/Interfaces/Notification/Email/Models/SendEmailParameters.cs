namespace ReservationSystem.Shared.Interfaces.Notification.Email.Models
{
    public class SendEmailParameters
    {
        public string? From { get; set; }
        public List<string> To { get; set; } = new();
        public List<string> Cc { get; set; } = new();
        public List<string> Bcc { get; set; } = new();
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
