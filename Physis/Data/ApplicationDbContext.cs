using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Physis.Models;

namespace Physis.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole 
            { 
                Id = "6793de18-a3fb-4d2e-bcdd-2b4568f9d936",
                ConcurrencyStamp = "f24c7eeb-fd57-47d2-9d34-e746b1801b7e",
                Name = "Tree Planter", 
                NormalizedName = "TREE PLANTER" 
            });

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "eafe5073-a58d-48e0-9cad-0380ec8ac8cd",
                ConcurrencyStamp = "f2204c01-202b-49fd-baaf-3129b52c54c6",
                Name = "Vendor",
                NormalizedName = "VENDOR"
            });
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Tree> Tree { get; set; }
        public DbSet<TreePlanter> TreePlanter { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
    }
}
