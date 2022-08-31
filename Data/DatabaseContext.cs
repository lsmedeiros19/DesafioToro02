using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Equity> Equities { get; set; }
        public DbSet<Position> Position { get; set; }

    }
}
