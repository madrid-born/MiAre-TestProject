using System.Data.Entity;

namespace MiAre_TestProject.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=MyDbContext") { }

        public DbSet<User> Users { get; set; }
    }
}