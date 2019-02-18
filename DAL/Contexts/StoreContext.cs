using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contexts
{
    public class StoreContext : DbContext
    {
        public DbSet<Category> Blogs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new { po.OrderId, po.ProductId });
            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Order)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(p => p.OrderId);
        }
    }
}
