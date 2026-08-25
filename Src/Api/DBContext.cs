using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<AccountEntity> Account { get; set; } = null;
        public DbSet<ContributorEntity> Contributor { get; set; } = null;
        public DbSet<BoardEntity> Board { get; set; } = null;
        public DbSet<LaneEntity> Lane { get; set; } = null;

    }
}
