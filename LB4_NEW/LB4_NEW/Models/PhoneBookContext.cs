using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LB4_NEW.Models
{
    public class PhoneBookContext: DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<PhoneBookContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}