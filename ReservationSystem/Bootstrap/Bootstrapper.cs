using FluentValidation;
using ReservationSystem.Apis.Booking.v1.Models;
using ReservationSystem.Apis.Booking.v1.Validators;
using ReservationSystem.RoomManagement.Data.SQLite.Extensions;
using ReservationSystem.Services.Booking;
using ReservationSystem.Services.Notification;
using ReservationSystem.Shared.Interfaces.Notification.Email;

namespace ReservationSystem.Bootstrap
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddRequiredServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLocalServices();
            services.AddRoomManagementDataSQLite(configuration);
            return services;
        }

        public static IServiceCollection AddLocalServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IValidator<BookRoomRequest>, BookRoomRequestValidator>();
            services.AddScoped<IEmailService, EmailService>();
            return services;
        }

    }
}
