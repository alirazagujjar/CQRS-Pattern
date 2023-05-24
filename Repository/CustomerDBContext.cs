using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerDBContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ContactAddress> ContactAddresses { get; set; }
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Admin)
                .WithOne(a => a.Customer)
                .HasForeignKey<Admin>(a => a.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.ContactAddresses)
                .WithOne(ca => ca.Customer)
                .HasForeignKey(ca => ca.CustomerId);
        }

    }
}
