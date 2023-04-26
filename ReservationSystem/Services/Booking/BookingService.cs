using ReservationSystem.Services.Booking.Models;
using ReservationSystem.Shared.Interface.RoomManagement;
using ReservationSystem.Shared.Interfaces.Notification.Email;
using ReservationSystem.Shared.Interfaces.RoomBooking;
using ReservationSystem.Shared.Interfaces.RoomManagement.Models;

namespace ReservationSystem.Services.Booking
{
    public interface IBookingService
    {
        Task<IEnumerable<string>> BookRoom(BookRoomParameters parameters);
    }

    public class BookingService : IBookingService
    {
        private readonly IRoomManagement _roomManagement;
        private readonly IRoomBooking _roomBooking;
        private readonly ILogger<BookingService> _logger;
        private readonly IEmailService _emailService;

        public BookingService(IRoomManagement roomManagement, ILogger<BookingService> logger, IRoomBooking roomBooking, IEmailService emailService)
        {
            _roomManagement = roomManagement;
            _logger = logger;
            _roomBooking = roomBooking;
            _emailService = emailService;
        }

        public async Task<IEnumerable<string>> BookRoom(BookRoomParameters parameters)
        {
            var errors = new List<string>();
            var room = await _roomManagement.GetRoom(parameters.RoomId);

            if(room == null)
            {
                var message = $"Room with id {parameters.RoomId} not found";
                _logger.LogInformation(message);
                errors.Add(message);
                return errors;
            }

            if(room.NumberOfPeople < parameters.NumberOfPeople)
            {
                var message = $"Room with id {room.Id} can only house {room.NumberOfPeople}.";
                _logger.LogInformation($"Room with id {room.Id} can only house {room.NumberOfPeople}.");
                errors.Add(message);
                return errors;
            }

            var roomReservations = await _roomManagement.GetConflictReservations(
                new GetConflictReservationsParameters { 
                    RoomId = parameters.RoomId,
                    DateFrom = parameters.DateFrom,
                    DateTo = parameters.DateTo});

            for (DateTime currentDate = parameters.DateFrom.Date; currentDate <= parameters.DateTo.Date; currentDate = currentDate.AddDays(1))
            {
                int occupiedSlots = roomReservations
                    .Where(b => currentDate >= b.DateFrom && currentDate <= b.DateTo)
                    .Sum(b => b.ReservedPeople);

                if ((room.NumberOfPeople - occupiedSlots - parameters.NumberOfPeople) < 0)
                {
                    errors.Add($"There is a conflict in allocation on day {currentDate.ToShortDateString()}");
                }         
            }

            if (!errors.Any())
            {
                var bookRoom = await _roomBooking.BookRoom(new Shared.Interfaces.RoomBooking.Models.BookRoomParameters()
                {
                    DateFrom = parameters.DateFrom,
                    DateTo = parameters.DateTo,
                    ReservedPeople = parameters.NumberOfPeople,
                    RoomId = parameters.RoomId,
                });
                await _emailService.SendEmail(new Shared.Interfaces.Notification.Email.Models.SendEmailParameters { 
                    Body = $"EMAIL SENT TO test@admin.com FOR CREATED Reservation WITH ID {bookRoom.ReservationId}" });
            }

            return errors;
        }
    }
}
