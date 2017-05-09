using Microsoft.EntityFrameworkCore;

namespace SQLitedllVM.Models
{
	///The context instance gets past around, for the repo pattern to get entry to the data
    public class UserContext : DbContext
    {
		
        public DbSet<User> Users { get; set; }
        public DbSet<Point> UserPoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=userpoints.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(b => b.Data)
                .WithOne()
                .HasForeignKey(p => p.UserForeignKey);
        }
    }
}
