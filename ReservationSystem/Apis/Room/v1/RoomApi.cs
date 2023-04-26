using Microsoft.AspNetCore.Http.HttpResults;
using ReservationSystem.Apis.Room.v1.Models;
using ReservationSystem.Shared.Interface.RoomManagement;

namespace ReservationSystem.Apis.Room.v1
{
    internal static class RoomApi
    {
        public static RouteGroupBuilder MapRoomApi(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/v1/room");

            group.WithTags("Rooms API V1");

            group.MapGet("/rooms", async (IRoomManagement roomManagement) =>
            {
                var rooms = await roomManagement.GetRooms();

                return TypedResults.Ok(new GetRoomsResponse());

            })
            .WithName("GetRooms")
            .WithOpenApi();

            group.MapGet("/v1/{id}", async Task<Results<Ok<GetRoomResponse>, NotFound>> (int id, IRoomManagement roomManagement) =>
            {
                var room = await roomManagement.GetRoom(id);

                if (room == null)
                {
                    return TypedResults.NotFound();
                }

                return TypedResults.Ok(new GetRoomResponse(room));
            })
            .WithName("GetRoomByRoomId")
            .WithOpenApi();

            return group;
        }
    }

}
