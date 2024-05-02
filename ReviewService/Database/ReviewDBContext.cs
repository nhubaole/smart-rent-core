using Microsoft.EntityFrameworkCore;

namespace ReviewService.Database
{
    public class ReviewDBContext :DbContext
    {
        public ReviewDBContext(DbContextOptions<ReviewDBContext> options) : base(options)
        {
        }

        public DbSet<Model.Review> Reviews { get; set; }
    }
}
