using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservationSystem.RoomManagement.SQLite.Options;
using ReservationSystem.RoomManagement.SQLite.Services;
using ReservationSystem.Shared.Interface.RoomManagement;
namespace ReservationSystem.RoomManagement.SQLite.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRoomManagementSQLite(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration[RoomManagementDataOptions.ConfigurationConnectionStringPosition];
            services.Configure<RoomManagementDataOptions>(options => configuration.GetSection(RoomManagementDataOptions.ConfigurationPosition).Bind(options));
            services.AddSingleton<IRoomManagement, RoomManagementSQLiteService>();
            //services.AddDbContext<RoomManagementDbContext>(options => options.UseSqlite(connection));
            return services;
        }
    }
}
