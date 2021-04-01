using System;

namespace EF_Book_SportsStore.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
