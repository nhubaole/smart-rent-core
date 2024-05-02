using Microsoft.EntityFrameworkCore;

namespace ReviewService.Database
{
    public static class ReviewMigration
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using ReviewDBContext dbContext = scope.ServiceProvider.GetRequiredService<ReviewDBContext>();
            dbContext.Database.Migrate();
        }
    }
}
