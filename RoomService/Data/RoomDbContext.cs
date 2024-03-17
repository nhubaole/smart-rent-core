using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using RoomService.Model;

namespace RoomService.Data
{
    public class RoomDbContext : DbContext
    {
        public RoomDbContext(DbContextOptions<RoomDbContext> options) : base(options)
        {

        }

        public DbSet<Room> Rooms { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("User ID =roomdb;Password=roomdb;Server=localhost, 5432;Database=rooms; Integrated Security=true;");
    }
}
