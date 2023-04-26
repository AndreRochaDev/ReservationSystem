using ReservationSystem.Shared.Interfaces.Notification.Email.Models;

namespace ReservationSystem.Shared.Interfaces.Notification.Email
{
    public interface IEmailService
    {
        Task SendEmail(SendEmailParameters parameters);
    }
}
