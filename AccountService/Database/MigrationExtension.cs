using Microsoft.EntityFrameworkCore;

namespace AccountService.Database
{
    public static class MigrationExtension
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using AccountDbContext dbContext = scope.ServiceProvider.GetRequiredService<AccountDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
