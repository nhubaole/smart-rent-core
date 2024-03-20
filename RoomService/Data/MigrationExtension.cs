using Microsoft.EntityFrameworkCore;

namespace RoomService.Data
{
    public static class MigrationExtension
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using RoomDbContext dbContext = scope.ServiceProvider.GetRequiredService<RoomDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
