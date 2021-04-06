using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Book_SportsStore.Models
{
    public class WebServiceRepository : IWebServiceRepository
    {
        private DataContext context;
        public WebServiceRepository(DataContext context) => this.context = context;

        //public object GetProduct(Guid productId) => context.Products.FirstOrDefault(p => p.ProductId == productId);

        //public object GetProduct(Guid productId) => context.Products.Select(p => new { ProductId = p.ProductId,
        //                                                                               Name = p.Name,
        //                                                                               PurchasePrice = p.PurchasePrice,
        //                                                                               RetailPrice = p.RetailPrice }).FirstOrDefault(p => p.ProductId == productId);

        //public object GetProduct(Guid productId) => context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == productId);

        public object GetProduct(Guid productId) => context.Products.Include(p => p.Category).Select(p => new { ProductId = p.ProductId,
                                                                                                                Name = p.Name,
                                                                                                                PurchasePrice = p.PurchasePrice,
                                                                                                                RetailPrice = p.RetailPrice,
                                                                                                                CategoryId = p.CategoryId,
                                                                                                                    Category = new { CategoryId = p.CategoryId,
                                                                                                                    Name = p.Category.Name,
                                                                                                                    Description = p.Category.Description }}).FirstOrDefault(p => p.ProductId == productId);

        public object GetProducts(int skip, int take) => context.Products.OrderBy(p => p.Name).Skip(skip).Take(take).Select(p => new { ProductId = p.ProductId,
                                                                                                                                       Name = p.Name,
                                                                                                                                       PurchasePrice = p.PurchasePrice,
                                                                                                                                       RetailPrice = p.RetailPrice,
                                                                                                                                       CategoryId = p.CategoryId,
                                                                                                                                       Category = new { CategoryId = p.CategoryId,
                                                                                                                                                        Name = p.Category.Name,
                                                                                                                                                        Description = p.Category.Description }});

        public Guid StoreProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product.ProductId;
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Guid productId)
        {
            context.Products.Remove(new Product { ProductId = productId });
            context.SaveChanges();
        }
    }
}
