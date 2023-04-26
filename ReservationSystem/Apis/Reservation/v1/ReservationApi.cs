using Microsoft.AspNetCore.Http.HttpResults;
using ReservationSystem.Apis.Reservation.v1.Models;
using ReservationSystem.Apis.Room.v1.Models;
using ReservationSystem.Shared.Interface.RoomManagement;

namespace ReservationSystem.Apis.Reservation.v1
{
    internal static class ReservationApi
    {
        public static RouteGroupBuilder MapReservationApi(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/v1/reservation");

            group.WithTags("Reservation API V1");

            group.MapGet("/reservations", async (IRoomManagement roomManagement) =>
            {
                var reservations = await roomManagement.GetReservations(new Shared.Interfaces.RoomManagement.Models.GetReservationsParameters());

                return TypedResults.Ok(new GetReservationsResponse(reservations));
            })
            .WithName("GetReservations")
            .WithOpenApi();

            group.MapGet("/v1/{id}", async Task<Results<Ok<GetRoomReservationsResponse>, NotFound>> (int id, IRoomManagement roomManagement) =>
            {
                var room = await roomManagement.GetRoom(id);

                if (room == null)
                {
                    return TypedResults.NotFound();
                }

                var reservations = await roomManagement.GetRoomReservations(new Shared.Interfaces.RoomManagement.Models.GetRoomReservationsParameters
                {
                    RoomId = id
                });

                return TypedResults.Ok(new GetRoomReservationsResponse(reservations));
            })
            .WithName("GetRoomReservations")
            .WithOpenApi();

            return group;
        }
    }
}
