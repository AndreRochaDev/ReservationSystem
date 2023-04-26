using ReservationSystem.Shared.Interfaces.Notification.Email;
using ReservationSystem.Shared.Interfaces.Notification.Email.Models;

namespace ReservationSystem.Services.Notification
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public Task SendEmail(SendEmailParameters parameters)
        {
            return Task.Run(() => _logger.LogInformation($"{parameters.Body}"));
        }
    }
}
