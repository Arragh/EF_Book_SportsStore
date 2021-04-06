using EF_Book_SportsStore.Models.Pages;
using System;
using System.Collections.Generic;

namespace EF_Book_SportsStore.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }
        PagedList<Product> GetProducts(QueryOptions options);
        Product GetProduct(Guid productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void UpdateAll(Product[] products);
        void Delete(Product product);
    }
}
