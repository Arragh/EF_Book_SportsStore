using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Book_SportsStore.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Добавление категорий
            List<Category> categories = new List<Category>();
            for (int i = 0; i < 10; i++)
            {
                Category category = new Category
                {
                    CategoryId = Guid.NewGuid(),
                    Name = "Категория-" + i,
                    Description = "Описание категории-" + i
                };
                categories.Add(category);
            }
            #endregion

            #region Добавление товаров
            List<Product> products = new List<Product>();
            for (int i = 0; i < 100; i++)
            {
                Random rnd = new Random();
                Product product = new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Товар-" + i,
                    PurchasePrice = rnd.Next(30, 300),
                    RetailPrice = rnd.Next(50, 500),
                    CategoryId = categories[rnd.Next(0, 9)].CategoryId

                };
                products.Add(product);
            }
            #endregion

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);

            //modelBuilder.Entity<Product>().HasIndex(p => p.Name);
            //modelBuilder.Entity<Product>().HasIndex(p => p.PurchasePrice);
            //modelBuilder.Entity<Product>().HasIndex(p => p.RetailPrice);
            //modelBuilder.Entity<Category>().HasIndex(c => c.Name);
            //modelBuilder.Entity<Category>().HasIndex(c => c.Description);

            base.OnModelCreating(modelBuilder);
        }
    }
}
