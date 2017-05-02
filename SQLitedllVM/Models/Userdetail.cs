using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLitedllVM.Models
{
    public class UserContext : DbContext
    {
        public DbSet<Userdetail> Users { get; set; }
        public DbSet<Point> Data { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=userpoints.db");
        }
    }

    public class Userdetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Username { get; set; }
        [StringLength(15, MinimumLength = 6)]
        public string Password { get; set; }
        public string BusinessName { get; set; }
        public string ContactNumber { get; set; }

        public virtual ICollection<Point> Data { get; set; } = new HashSet<Point>();
    }


}
