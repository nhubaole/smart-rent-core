using FluentValidation;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;


namespace RoomService.Database
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
    public class RoomValidator : AbstractValidator<CreateRoomReq>
    {
        public RoomValidator()
        {
            RuleFor(r => r.RoomType).NotEmpty().NotNull();
            RuleFor(r => r.Price).NotEmpty().NotNull();
            RuleFor(r => r.Title).NotEmpty().NotNull();
            RuleFor(r => r.Capacity).NotEmpty().NotNull();
            RuleFor(r => r.Area).NotEmpty().NotNull();
            RuleFor(r => r.Deposit).NotEmpty().NotNull();
            RuleFor(r => r.ElectricityCost).NotEmpty().NotNull();
            RuleFor(r => r.WaterCost).NotEmpty().NotNull();
            RuleFor(r => r.Location).NotEmpty().NotNull();
        }
    }
}
