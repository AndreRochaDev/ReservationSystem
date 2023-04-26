using ReservationSystem.Apis.RoomBooking.v1;
using ReservationSystem.Apis.Room.v1;
using ReservationSystem.Bootstrap;
using ReservationSystem.Apis.Reservation.v1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRequiredServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapRoomApi();
app.MapBookingApi();
app.MapReservationApi();

app.Run();

