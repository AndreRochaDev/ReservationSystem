using FluentValidation;
using ReservationSystem.Apis.Booking.v1.Models;

namespace ReservationSystem.Apis.Booking.v1.Validators
{
    public class BookRoomRequestValidator : AbstractValidator<BookRoomRequest>
    {
        public BookRoomRequestValidator()
        {
            RuleFor(x => x.RoomId)
                .GreaterThan(0)
                .WithMessage("RoomId must be greater than 0.");

            RuleFor(x => x.DateFrom)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("DateFrom must be greater than or equal to the current date and time.");

            RuleFor(x => x.DateTo)
                .NotEmpty()
                .GreaterThan(x => x.DateFrom)
                .WithMessage("DateTo must be greater than DateFrom.");

            RuleFor(x => x.NumberOfPeople)
                .GreaterThan(0)
                .WithMessage("NumberOfPeople must be greater than 0.");
        }
    }
}
