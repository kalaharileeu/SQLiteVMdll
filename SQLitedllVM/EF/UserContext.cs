using Microsoft.EntityFrameworkCore;

namespace SQLitedllVM.Models
{
    public class UserContext : DbContext
    {
        public DbSet<Userdetail> Users { get; set; }
        public DbSet<Point> UserPoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=userpoints.db");
        }
    }
}
