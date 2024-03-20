using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;


namespace RoomService.Data
{
    public class RoomDbContext : DbContext
    {
        public RoomDbContext(DbContextOptions<RoomDbContext> options) : base(options)
        {

        }

        public DbSet<Model.Room> Rooms { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseNpgsql("User ID =roomdb;Password=roomdb;Server=localhost; Port=5432;Database=rooms;");
    }
}
