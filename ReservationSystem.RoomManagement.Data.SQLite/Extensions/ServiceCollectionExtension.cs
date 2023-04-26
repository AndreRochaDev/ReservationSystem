using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservationSystem.RoomManagement.Data.SQLite.Data.DbContext;
using ReservationSystem.RoomManagement.Data.SQLite.Options;
using ReservationSystem.RoomManagement.Data.SQLite.Services;
using ReservationSystem.Shared.Interface.RoomManagement;

namespace ReservationSystem.RoomManagement.Data.SQLite.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRoomManagementDataSQLite(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration[RoomManagementDataOptions.ConfigurationConnectionStringPosition];
            services.Configure<RoomManagementDataOptions>(options => configuration.GetSection(RoomManagementDataOptions.ConfigurationPosition).Bind(options));
            services.AddSingleton<IRoomManagement, RoomManagementSQLiteService>();
            services.AddDbContext<RoomManagementDbContext>(options => 
            options.UseSqlite(connection));
            return services;
        }
    }
}
