using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MYShop.DAL.EF.Configuration;
using MYShop.Domain.Entities;
using System;

namespace MYShop.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products {get;set;}
        public DbSet<Order> Order { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<ProductProperties> ProductProperties { get; set; }
        public DbSet<NewsUsers> NewsUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<ProductProperties>().HasKey(c => new { c.ProductId, c.PropertyId });
            modelBuilder.Entity<Brand>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(c => !c.IsDeleted);

            modelBuilder.ApplyConfiguration(new ProductConfig());
           
            base.OnModelCreating(modelBuilder); 
        }

    }
}
