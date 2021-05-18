using LT.EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LT.EFCoreDemo.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options): base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ProductWarehouse> ProductWarehouseCollection { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<ProductWarehouse>()
                .HasOne(pw => pw.Product)
                .WithMany(p => p.ProductWarehouseMappings)
                .HasForeignKey(pw => pw.ProductId);

            modelBuilder
                .Entity<ProductWarehouse>()
                .HasOne(pw => pw.Warehouse)
                .WithMany(w => w.ProductWarehouseMappings)
                .HasForeignKey(pw => pw.WarehouseId);

            modelBuilder
                .Entity<ProductWarehouse>()
                .HasKey(pw => new { pw.ProductId, pw.WarehouseId });
        }
    }
}
