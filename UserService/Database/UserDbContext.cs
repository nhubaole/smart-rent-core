using Microsoft.EntityFrameworkCore;

namespace UserService.Database
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public DbSet<Model.User> Users { get; set; }

    }
}
