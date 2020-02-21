using _04_CRUD.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04_CRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var shop1 = new Shop
            {
                ShopId = 1,
                Name = "Super Grocery",
                Created = DateTime.Now
            };
            var item1 = new Item
            {
                ItemId = Guid.NewGuid(),
                Name = "Milk 500ml",
                Cost = 2.32m,
                ShopId = 1,
            };
            modelBuilder.Entity<Shop>().HasData(shop1);
            modelBuilder.Entity<Item>().HasData(item1);
        }
    }
}
