using EF_Book_SportsStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Book_SportsStore.Controllers
{
    [Route("api/products")]
    public class ProductValuesController : ControllerBase
    {
        private IWebServiceRepository repository;
        public ProductValuesController(IWebServiceRepository repository) => this.repository = repository;

        [HttpGet("{productId}")]
        public object GetProduct(Guid productId) => repository.GetProduct(productId) ?? NotFound();

        [HttpGet("{skip}/{take}")]
        public object GetProducts(int skip, int take) => repository.GetProducts(skip, take) ?? NotFound();

        [HttpPost]
        public Guid StoreProduct([FromBody] Product product) => repository.StoreProduct(product);

        [HttpPut]
        public void UpdateProduct([FromBody] Product product) => repository.UpdateProduct(product);

        [HttpDelete("{productId}")]
        public void DeleteProduct(Guid productId) => repository.DeleteProduct(productId);
    }
}
