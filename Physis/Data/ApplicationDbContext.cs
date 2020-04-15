using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "872c4215-ba53-4399-9b3a-ccf186d11b17",
                ConcurrencyStamp = "43e75581-d2b4-4f5d-b5dc-201673334a5d",
                Name = "Donator",
                NormalizedName = "DONATOR"
            });
        }
    }
}
