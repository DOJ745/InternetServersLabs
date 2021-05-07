using System.Data.Entity;

namespace LB4.Models
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<PhoneBookContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}