using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;

namespace IO.Swagger {
    public class MyDbContext : DbContext {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
        }
    }
}
