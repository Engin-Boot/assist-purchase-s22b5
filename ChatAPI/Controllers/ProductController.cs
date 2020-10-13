using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ChatAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManagement _product;
        public ProductController(IProductManagement product)
        {
            _product = product;
           
        }
        // GET: api/product
        [HttpGet]
        public IEnumerable<ProductDataModel> Get()
        {
            Console.WriteLine(_product.GetAllProducts());
            return _product.GetAllProducts();
        }
        [HttpPost]
        public bool AddProduct([FromBody ] ProductDataModel product)
        {
            
            return _product.AddProduct(product);
        }

        [HttpPut]
        public bool UpdateProduct([FromBody] ProductDataModel product)
        {
            return _product.UpdateProduct(product);
        }

        [HttpDelete]
        public bool RemoveProduct([FromBody] ProductDataModel product)
        {
            return _product.RemoveProduct(product);
        }
    }
    
}
