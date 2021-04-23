using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VimaruAsset.Models;

namespace VimaruAsset.Data
{
    public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<Department> Department { get; set; }

        public DbSet<WareHouse> WareHouse { get; set; }

        public DbSet<AssetGroups> AssetGroups { get; set; }
        public DbSet<AssetTypes> AssetTypes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Unit> Units { get; set; }

        public DbSet<Assets> Assets { get; set; }
        public DbSet<ShoppingPlan> ShoppingPlan { get; set; }
        public DbSet<PlanAssets> PlanAsset { get; set; }

        public DbSet<ReductionHistory> ReductionHistories { get; set; }
        public DbSet<Exploit> Exploits { get; set; }
     }
}
