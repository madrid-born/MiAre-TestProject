using System.Data.Entity;
using System.Linq;

namespace MiAre_TestProject.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base(@"Server=158.58.187.131\MSSQLSERVER2022;Database=MiAreTest;User ID=ali;Password=oR_9l3f00;") { }

        public DbSet<User> Users { get; set; }

        public User GetUserById(int id)
        {
            return Users.SingleOrDefault(u => u.Id == id);
        }
        
        public User GetUserByUsername(string username)
        {
            return Users.SingleOrDefault(u => u.Username == username);
        }
    }
}