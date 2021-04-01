using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_Book_SportsStore.Models
{
    public class DataRepository : IRepository
    {
        private DataContext context;
        public DataRepository(DataContext context) => this.context = context;

        public IEnumerable<Product> Products => context.Products.Include(p => p.Category).ToArray();

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public Product GetProduct(Guid productId) => context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == productId);

        public void UpdateAll(Product[] products)
        {
            Dictionary<Guid, Product> data = products.ToDictionary(p => p.ProductId);
            IEnumerable<Product> baseline = context.Products.Where(p => data.Keys.Contains(p.ProductId));
            foreach (var databaseProduct in baseline)
            {
                Product requestProduct = data[databaseProduct.ProductId];
                databaseProduct.Name = requestProduct.Name;
                databaseProduct.Category = requestProduct.Category;
                databaseProduct.PurchasePrice = requestProduct.PurchasePrice;
                databaseProduct.RetailPrice = requestProduct.RetailPrice;
            }

            context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            Product p = context.Products.Find(product.ProductId);
            p.Name = product.Name;
            p.CategoryId = product.CategoryId;
            p.PurchasePrice = product.PurchasePrice;
            p.RetailPrice = product.RetailPrice;
            context.SaveChanges();
        }
    }
}
