using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<AccountEntity> Account { get; set; } = null;

    }
}
