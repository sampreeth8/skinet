
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext( DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasConversion<double>();
            //if (Database.ProviderName == "Microsoft.EntityFrameworkCore.SqlServer")
            //{
            //    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //    {
            //        var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));
            //        //var dateTimeProperties = entityType.ClrType.GetProperties()
            //        //    .Where(p => p.PropertyType == typeof(DateTimeOffset));

            //        foreach (var property in properties)
            //        {
            //            modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
            //        }

            //        //foreach (var property in dateTimeProperties)
            //        //{
            //        //    modelBuilder.Entity(entityType.Name).Property(property.Name)
            //        //        .HasConversion(new DateTimeOffsetToBinaryConverter());
            //        //}

            //    }
        }
        }
    }

