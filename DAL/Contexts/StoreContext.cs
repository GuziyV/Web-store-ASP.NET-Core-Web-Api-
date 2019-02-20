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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Keys
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
            #endregion

            #region DDDFields
            modelBuilder.Entity<Category>().Metadata
                .FindNavigation(nameof(Category.Products))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            modelBuilder.Entity<Customer>().Metadata
                .FindNavigation(nameof(Customer.Orders))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            modelBuilder.Entity<Order>().Metadata
                .FindNavigation(nameof(Order.ProductOrders))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            modelBuilder.Entity<Producer>().Metadata
                .FindNavigation(nameof(Producer.Products))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            modelBuilder.Entity<Product>().Metadata
                .FindNavigation(nameof(Product.ProductOrders))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            modelBuilder.Entity<Product>().Metadata
                .FindNavigation(nameof(Product.Options))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            modelBuilder.Entity<Product>().Metadata
                .FindNavigation(nameof(Product.ProductImages))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            #endregion
        }
    }
}
