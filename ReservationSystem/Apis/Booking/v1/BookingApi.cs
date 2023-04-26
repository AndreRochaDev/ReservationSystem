using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Apis.Booking.v1.Models;
using ReservationSystem.Services.Booking;
using ReservationSystem.Services.Booking.Models;
using ReservationSystem.Shared.Interface.RoomManagement;

namespace ReservationSystem.Apis.RoomBooking.v1
{
    public static class BookingApi
    {
        public static RouteGroupBuilder MapBookingApi(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/v1/booking");

            group.WithTags("Booking API V1");

            group.MapPost("/", async Task<Results<Ok<List<string>>, ValidationProblem>> 
                ([FromBody]BookRoomRequest request, 
                IValidator<BookRoomRequest> validator,  
                IRoomManagement roomManagement,
                IBookingService bookingService) =>
            {
                var validationResult = await validator.ValidateAsync(request);
                if (!validationResult.IsValid) 
                {
                    return TypedResults.ValidationProblem(validationResult.ToDictionary());
                }
                var result = await bookingService.BookRoom(new BookRoomParameters
                {
                    DateFrom = request.DateFrom,
                    DateTo = request.DateTo,
                    NumberOfPeople = request.NumberOfPeople,
                    RoomId = request.RoomId
                });
                return TypedResults.Ok(result.ToList());
            })
            .WithName("BookRoom")
            .WithOpenApi();

            return group;
        }
    }
}
