using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

    }
}
