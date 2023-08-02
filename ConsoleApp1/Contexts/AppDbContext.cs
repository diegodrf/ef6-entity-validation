using ConsoleApp1.Models;
using System.Data.Common;
using System.Data.Entity;

namespace ConsoleApp1.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Animal> Animals { get; set; } = default!;

        public AppDbContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        public AppDbContext(DbConnection connection) : base(connection, false) { }
    }
}
