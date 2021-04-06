using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Book_SportsStore.Models
{
    public interface IWebServiceRepository
    {
        object GetProduct(Guid productId);
        object GetProducts(int skip, int take);

        Guid StoreProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Guid productId);
    }
}
