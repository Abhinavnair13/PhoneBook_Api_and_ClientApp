using Microsoft.EntityFrameworkCore;
using PhoneBookAppApi.Models;
using System.Collections.Generic;

namespace PhoneBookAppApi.Data
{

        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            //appdbcontext
        }

            public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>();

        }
    }
    
}
