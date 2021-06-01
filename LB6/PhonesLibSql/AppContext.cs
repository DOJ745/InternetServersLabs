using System.Data.Entity;

namespace PhonesLibSql
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("DBConnection")
        { }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
