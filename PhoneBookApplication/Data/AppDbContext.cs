using Microsoft.EntityFrameworkCore;
using PhoneBookApplication.Models;
using System.Collections.Generic;

namespace PhoneBookApplication.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<PhoneBook> PhoneBooks { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneBook>();
                
        }
    }
}
