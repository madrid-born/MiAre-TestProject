using System.Data.Entity;

namespace MiAre_TestProject.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base(@"Server=158.58.187.131\MSSQLSERVER2022;Database=MiAreTest;User ID=ali;Password=oR_9l3f00;") { }

        public DbSet<User> Users { get; set; }
    }
}