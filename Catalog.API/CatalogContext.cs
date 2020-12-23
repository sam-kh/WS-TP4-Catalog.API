using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API
{
    public class CatalogContext:DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        { }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<CatalogBrand>().HasData(
                  new CatalogBrand { Id = 1, Brand = "Azure"},
                  new CatalogBrand { Id = 2, Brand = ".NET"},
                  new CatalogBrand { Id = 3, Brand = "Visual Studio"},
                  new CatalogBrand { Id = 4, Brand = "SQL Server"},
                  new CatalogBrand { Id = 5, Brand = "Other"}
            );
            modelBuilder.Entity<CatalogType>().HasData(
                new CatalogType { Id = 1, Type = "Mug" },
                new CatalogType { Id = 2, Type = "T-Shirt" },
                new CatalogType { Id = 3, Type = "Sheet" },
                new CatalogType { Id = 4, Type = "USB Memory Stick" }  
            );
        }
    }
}
