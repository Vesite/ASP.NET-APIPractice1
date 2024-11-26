using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    // Object that allows us to specify what tables we want in the SQL database
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        // Our Tables
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }



        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            // Setting up Many-to-many here i guess?
            builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId}));
            builder.Entity<Portfolio>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.PortFolios)
                .HasForeignKey(p => p.AppUserId);
            builder.Entity<Portfolio>()
                .HasOne(u => u.Stock)
                .WithMany(u => u.PortFolios)
                .HasForeignKey(p => p.StockId);

            List<IdentityRole> roles =
            [
                new IdentityRole {
                    Name = "User",
                    NormalizedName = "USER",
                },
                new IdentityRole {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                }
            ];
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}