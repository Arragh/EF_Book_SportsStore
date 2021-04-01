using System;
using System.Collections.Generic;

namespace EF_Book_SportsStore.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }

        Product GetProduct(Guid productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void UpdateAll(Product[] products);
        void Delete(Product product);
    }
}
