using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
namespace WebApplication2.Models.data
{
    public class appDbContext:DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base(options) { }
        public DbSet<Category> categories { set; get; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category{ Id = "ACT".toId(),Name = "action", abb = "ACT", Description = "" },
                new Category{ Id="ADV".toId(),Name = "adventure", abb = "ADV", Description = "" }
                );
        }
    }
}
