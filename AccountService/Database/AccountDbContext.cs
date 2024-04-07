using AccountService.Model;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Database
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
    }
}
